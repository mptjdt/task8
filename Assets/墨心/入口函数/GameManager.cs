using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static World 后台实例 = new();
        public static FrontendWorld 前台世界实例;
        public static PlayerController 前台人物实例;
        public static InfoPanel 信息面板实例;
        // 主方法，程序入口
        public static void Mainstart() {
            初始化后台世界和人物();
            初始化前台();
            创建世界流程();         
            创建信息面板流程();
        }
    }
    //流程函数
    public static partial class GameManager {
        public static void 初始化后台世界和人物() {
            后台实例.创建世界(10, 10);
            后台实例.填充沙漠();
            后台实例.洒下铜矿(3, 3);
            后台实例.Player = Player.InitializePlayer(5f, 5f);
        }
        public static void 初始化前台() {
            前台世界实例 = MainCamera.AddComponent<FrontendWorld>();
            前台人物实例 = MainCamera.AddComponent<PlayerController>();
            信息面板实例 = MainCamera.AddComponent<InfoPanel>();
        }
        public static void 创建世界流程() {
            for (int i = 0; i < 后台实例.Width; i++) {
                for (int j = 0; j < 后台实例.Height; j++) {
                    前台世界实例.创建土质层(i, j, 后台实例.Grid[i, j]);
                    前台世界实例.创建矿石层(i, j, 后台实例.Grid[i, j]);
                }
            }
            前台人物实例.PlayerObj = 前台人物实例.CreatePlayer(后台实例.Player);
        }
        public static void 创建信息面板流程() {
            信息面板实例.panel = 信息面板实例.CreateInfoPanel();
        }
    }
}