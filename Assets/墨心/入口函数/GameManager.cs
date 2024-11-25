using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static World WorldInstance { get; private set; }  // 存储后台类的实例
        public static FrontendWorld FrontendInstance { get; private set; }  // 存储前台世界的实例
        public static PlayerController PlayerControllerInstance { get; private set; }//存储前台人物的实例
        public static InfoPanel PanelInstance {  get; private set; }//存储信息面板的实例
        // 主方法，程序入口
        public static void Mainstart() {
            创建后台世界();// 创建后台世界和人物
            创建前台世界();// 创建前台世界
            CreateWorld();// 调用流程创建世界           
            CreateInfoPanel();// 创建并显示信息面板
        }
}
    //流程函数
    public static partial class GameManager {
        public static void 创建后台世界() {
            WorldInstance = InitializeWorld(10, 10);
            WorldInstance.Player = InitializePlayer(5f, 5f);
        }
        public static void 创建前台世界() {
            FrontendInstance = new GameObject("FrontendWorld").AddComponent<FrontendWorld>();
            PlayerControllerInstance=new GameObject("PlayController").AddComponent<PlayerController>();
            PanelInstance = new GameObject("InfoPanel").AddComponent<InfoPanel>();
        }
        public static void CreateWorld() {
            for (int x = 0; x < WorldInstance.Width; x++){
                for (int y = 0; y < WorldInstance.Height; y++){
                    FrontendInstance.CreateTileUI(x, y, WorldInstance.Grid[x, y]);  // 传递 TileInfo
                }
            }
            PlayerControllerInstance.PlayerObj = PlayerControllerInstance.CreatePlayer(WorldInstance.Player);//创建人物
        }
        public static void CreateInfoPanel() {
            PanelInstance.panel=PanelInstance.CreateInfoPanel();// 调用 InfoPanel 的创建方法
        }
    }
}
