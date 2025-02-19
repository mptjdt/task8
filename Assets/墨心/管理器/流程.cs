﻿using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;
using static 墨心.LocalStorage;

namespace 墨心.Task8 {
    public class 世界设定类 {
        public int 宽度 = 100;
        public int 高度 = 100;
        public int 铜矿尺寸 = 10;
        public int 铜矿数量 = 10;
        public int 草地尺寸 = 4000;
        public 玩家设定类 玩家设定 = new();
    }
    public class 玩家设定类 {
        public int 玩家移速 = 5;
        public int 玩家转速 = 5;
        public int 玩家血量 = 100;
        public int 玩家饱腹值 = 100;
        public int 背包体积限制 = 30;
        public int 背包重量限制 = 30;
    }
    public class 笔记设定类 {
        public bool 背包是否打开 = false;
    }
    public static partial class LocalStorage {
        public static void 创建世界流程(世界设定类 X) {
            后台世界 = new 后台世界类();
            后台世界.创建世界(X.宽度, X.高度);
            后台世界.填充沙漠();
            后台世界.填充草地(X.草地尺寸);
            后台世界.种植树木();
            后台世界.洒下几堆铜矿(X.铜矿尺寸, X.铜矿数量);
            后台世界.创建玩家(X.玩家设定);
            后台世界.Player.背包.创建背包(X.玩家设定.背包体积限制, X.玩家设定.背包重量限制);
        }
        public static void 创建笔记流程(笔记设定类 X) {
            笔记.背包是否打开 = X.背包是否打开;
        }
        public static void 运行世界流程() {
            后台世界.Player.注册每帧行为();
            OnAppUpdate(() => {
                滚轮缩放();
            });
        }
        public static void 绘制世界流程() {
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    前台世界.创建土质层(i, j, 后台世界[i, j]);
                    前台世界.创建矿石层(i, j, 后台世界[i, j]);
                    前台世界.创建建筑层(i, j, 后台世界[i, j]);
                }
            }
            前台世界.创建玩家(后台世界.Player);
            OnAppUpdate(() => {
                MainCamera.transform.position = new Vector3(前台世界.玩家.transform.position.x, 前台世界.玩家.transform.position.y, -10);
            });
            OnAppDestroy(() => {
                存档管理器.存档();
            });
        }
        public static void 绘制UI流程() {
            UI.创建信息面板();
            UI.创建角色面板();
            UI.创建背包面板(笔记.背包是否打开);
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
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
                    Command.加速();
                }
                if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) {
                    Command.减速();
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
    }
}