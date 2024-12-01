using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static 后台世界类 后台世界 = new();
        public static 前台世界类 前台世界;
        public static 前台人物类 前台人物;
        public static 信息面板类 信息面板;
        public static void MainStart() {
            初始化后台();
            初始化前台();
            创建世界流程();         
            创建信息面板流程();
        }
    }
    //流程函数
    public static partial class GameManager {
        public static void 初始化后台() {
            后台世界.创建世界(10, 10);
            后台世界.填充沙漠();
            后台世界.洒下铜矿(3, 3);
            后台世界.Player = Player.InitializePlayer(5f, 5f);
        }
        public static void 初始化前台() {
            前台世界 = MainCamera.AddComponent<前台世界类>();
            前台人物 = MainCamera.AddComponent<前台人物类>();
            信息面板 = MainCamera.AddComponent<信息面板类>();
        }
        public static void 创建世界流程() {
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    前台世界.创建土质层(i, j, 后台世界.Grid[i, j]);
                    前台世界.创建矿石层(i, j, 后台世界.Grid[i, j]);
                }
            }
            前台人物.PlayerObj = 前台人物.CreatePlayer(后台世界.Player);
        }
        public static void 创建信息面板流程() {
            信息面板.panel = 信息面板.创建信息面板();
        }
    }
}