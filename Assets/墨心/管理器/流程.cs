using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace 墨心 {
    public class 世界设定类 {
        public int 宽度 = 10;
        public int 高度 = 10;
        public int 铜矿尺寸 = 3;
        public int 铜矿数量 = 3;
        public int 玩家移速 = 5;
        public int 玩家转速 = 5;
    }
    public class 背包设定类 {
        public int 宽度 = 4;
        public int 高度 = 5;
    }
    public static partial class GameManager {
        public static void 创建世界流程(世界设定类 X) {
            后台世界.创建世界(X.宽度, X.高度);
            后台世界.填充沙漠();
            后台世界.洒下几堆铜矿(X.铜矿尺寸, X.铜矿数量);
            后台世界.创建玩家(X.玩家移速, X.玩家转速);
        }
        public static void 绘制世界流程() {
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    前台世界.创建土质层(i, j, 后台世界.Grid[i, j]);
                    前台世界.创建矿石层(i, j, 后台世界.Grid[i, j]);
                }
            }
            前台世界.创建玩家(后台世界.Player);
            OnAppUpdate(() => {
                MainCamera.transform.position = new Vector3(前台世界.玩家.transform.position.x, 前台世界.玩家.transform.position.y, -10);
            });
        }
        public static void 创建背包流程(背包设定类 X) {
            后台背包.创建背包(X.宽度, X.高度);
        }
        public static void 绘制背包流程() {
            背包面板.创建背包面板(后台背包.Width,后台背包.Height);
        }
        public static void 初始化快捷指令() {
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
                if (Input.GetKey(KeyCode.E)) {
                    Command.切换背包();
                }
                if (Input.GetMouseButtonDown(1)) {
                    Command.开采地块(获取后台坐标(Input.mousePosition).x, 获取后台坐标(Input.mousePosition).y);
                }
                if (Input.GetMouseButtonDown(0)) {
                    信息面板.信息面板.GetComponentInChildren<Text>().text = Command.查询地块(获取后台坐标(Input.mousePosition).x, 获取后台坐标(Input.mousePosition).y);
                }
            });
        }
        public static void 订阅事件流程() {
            Event.当角色坐标更新 += (Vector2 X, float Y) => {
                前台世界.玩家.transform.position = X;
                前台世界.玩家.transform.rotation = Quaternion.Euler(0, 0, Y);
            };
            Event.当地块采光 += (Vector2Int X) => {
                if (前台世界.所有矿石.TryGetValue(X, out GameObject A)) {
                    前台世界.所有矿石.Remove(X);
                    Destroy(A);
                    Print($"地块 {X.x}-{X.y} 采光！");
                }
            };
            Event.当开关背包 +=()=> {
                背包面板.背包是否打开 = !背包面板.背包是否打开;
                背包面板.背包面板.SetActive(背包面板.背包是否打开);
            };
            Event.当背包更新 += (I物品[,] X) => {
                背包面板.更新背包显示(X);
            };
        }
    }
}