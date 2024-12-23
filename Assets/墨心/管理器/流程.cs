using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;
using static 墨心.GameManager;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace 墨心.Task8 {
    public class 世界设定类 {
        public int 宽度 = 10;
        public int 高度 = 10;
        public int 铜矿尺寸 = 3;
        public int 铜矿数量 = 3;
        public 玩家设定类 玩家设定 = new();
    }
    public class 玩家设定类 {
        public int 玩家移速 = 5;
        public int 玩家转速 = 5;
        public int 玩家血量 = 100;
        public int 玩家饱腹值 = 100;
        public int 背包宽度 = 4;
        public int 背包高度 = 5;
    }
    public class 笔记设定类 {
        public bool 背包是否打开 = false;
    }
    public static partial class GameManager {
        public static void 创建世界流程(世界设定类 X) {
            后台世界 = new();
            后台世界.创建世界(X.宽度, X.高度);
            后台世界.填充沙漠();
            后台世界.填充草地();
            后台世界.种植树木();
            后台世界.洒下几堆铜矿(X.铜矿尺寸, X.铜矿数量);
            后台世界.创建玩家(X.玩家设定);
            //后台世界.Player.背包.创建背包(X.背包宽度, X.背包高度);
        }
        public static void 创建笔记流程(笔记设定类 X) {
            笔记.背包是否打开 = X.背包是否打开;
        }
        public static void 绘制世界流程() {
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    前台世界.创建土质层(i, j, 后台世界.Grid[i, j]);
                    前台世界.创建矿石层(i, j, 后台世界.Grid[i, j]);
                    前台世界.创建建筑层(i, j, 后台世界.Grid[i, j]);
                }
            }
            前台世界.创建玩家(后台世界.Player);
        }
        public static void 绘制UI流程() {
            UI.创建信息面板();
            UI.创建角色面板();
            UI.创建背包面板(后台世界.Player.背包.Width, 后台世界.Player.背包.Height, 笔记.背包是否打开);
            UI.更新背包显示(后台世界.Player.背包);
            OnAppUpdate(() => {
                UI.角色面板.GetComponentInChildren<Text>().text = 后台世界.Player.展示文本();
            });
        }
        public static void 注册指令流程() {
            OnAppUpdate(() => {
                if (Input.GetKey(KeyCode.W)) {
                    Command.帧上移();
                }
                if (Input.GetKey(KeyCode.A)) {
                    Command.帧左移();
                }
                if (Input.GetKey(KeyCode.S)) {
                    Command.帧下移();
                }
                if (Input.GetKey(KeyCode.D)) {
                    Command.帧右移();
                }
                if (Input.GetKeyDown(KeyCode.E)) {
                    Command.切换背包();
                }
                if (Input.GetMouseButtonDown(1)) {
                    var A = 获取后台坐标(Input.mousePosition);
                    Command.开采地块(A.x, A.y);
                }
                if (Input.GetMouseButtonDown(0)) {
                    var A = 获取后台坐标(Input.mousePosition);
                    UI.信息面板.GetComponentInChildren<Text>().text = Command.查询地块(A.x, A.y);
                }
            });
        }
        public static void 订阅事件流程() {
            OnAppUpdate(() => {
                MainCamera.transform.position = new Vector3(前台世界.玩家.transform.position.x, 前台世界.玩家.transform.position.y, -10);
            });
            OnAppDestroy(() => {
                存档管理器.存档();
            });
            Event.当角色坐标更新 += (X, Y) => {
                前台世界.玩家.transform.position = X;
                前台世界.玩家.transform.rotation = Quaternion.Euler(0, 0, Y);
            };
            Event.当地块采集成功 += (X) => {
                if (后台世界[X.x, X.y].矿石层 != null) {
                    后台世界.Player.背包.添加物品(new 后台物品类() { 名称 = 后台世界[X.x, X.y].矿石层.类型.ToString(), 数量 = 1 });
                }
                UI.更新背包显示(后台世界.Player.背包);
            };
            Event.当地块采光 += (X) => {
                if (前台世界.所有矿石.TryGetValue(X, out GameObject A)) {
                    前台世界.所有矿石.Remove(X);
                    Destroy(A);
                    Print($"地块 {X.x}-{X.y} 采光！");
                }
            };
            Event.当建筑受伤 += (X) => {
                if (后台世界[X.x, X.y].建筑层 != null) {
                    前台世界.所有建筑.TryGetValue(X, out GameObject A);
                    A.Tremble();
                    后台世界.Player.背包.添加物品(new 后台物品类() { 名称 = 后台世界[X.x, X.y].建筑层.类型.ToString(), 数量 = 2 });
                }
                UI.更新背包显示(后台世界.Player.背包);
            };
            Event.当地块建筑被毁 += (X) => {
                if (前台世界.所有建筑.TryGetValue(X, out GameObject A)) {
                    前台世界.所有建筑.Remove(X);
                    Destroy(A);
                    Print($"地块建筑 {X.x}-{X.y} 被毁！");
                }
            };
            Event.当建筑掉落 += (X) => {
                后台世界.Player.背包.添加物品(new 后台物品类() { 名称 = 后台世界[X.x, X.y].建筑层.类型.掉落(), 数量 = 1 });
                UI.更新背包显示(后台世界.Player.背包);
            };
            Event.当玩家死亡 += () => {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            };
            ///Event.当获得种子 += () => {
            ///后台世界.Player.背包.添加物品(new 后台物品类() { 名称 = "种子", 数量 = 1 });
            ///Event.背包更新(后台世界.Player.背包);
            ///};
            ///Event.当树木颤抖 += (X) => {
            ///前台世界.所有建筑.TryGetValue(X, out GameObject A);
            ///A.Tremble();
            ///};
        }
    }
}