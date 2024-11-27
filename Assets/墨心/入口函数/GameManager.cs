using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static World 后台实例;
        public static FrontendWorld 前台世界实例;
        public static PlayerController 前台人物实例;
        public static InfoPanel 信息面板实例;
        // 主方法，程序入口
        public static void Mainstart() {
            创建后台世界和人物();
            创建前台世界();
            创建世界流程();         
            创建信息面板流程();
        }
    }
    //流程函数
    public static partial class GameManager {
        public static void 创建后台世界和人物() {
            后台实例 = InitializeWorld(10, 10);
            后台实例.Player = InitializePlayer(5f, 5f);
            初始化土质层();
            初始化矿石层(3, 3);
        }
        public static void 创建前台世界() {
            前台世界实例 = new GameObject("FrontendWorld").AddComponent<FrontendWorld>();
            前台人物实例 = new GameObject("PlayController").AddComponent<PlayerController>();
            信息面板实例 = new GameObject("InfoPanel").AddComponent<InfoPanel>();
        }
        public static void 创建世界流程() {
            for (int x = 0; x < 后台实例.Width; x++) {
                for (int y = 0; y < 后台实例.Height; y++) {
                    前台世界实例.创建土质层(x, y, 后台实例.Grid[x, y]);
                    前台世界实例.创建矿石层(x, y, 后台实例.Grid[x, y]);
                }
            }
            前台人物实例.PlayerObj = 前台人物实例.CreatePlayer(后台实例.Player);
        }
        public static void 创建信息面板流程() {
            信息面板实例.panel = 信息面板实例.CreateInfoPanel();
        }
    }
}