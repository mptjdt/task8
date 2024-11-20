﻿using System.Diagnostics;
using UnityEngine;
//项目入口文件
namespace 墨心{
    // 部分类：包含入口函数
    public static partial class GameManager{
        public static World WorldInstance { get; private set; }  // 存储后台世界的实例
        public static FrontendWorld FrontendInstance { get; private set; }  // 存储前台世界的实例
        public static GameObject PlayerObj;//持久化保存人物
       
        // 主方法，程序入口
        public static void Mainstart(){
            // 创建后台世界和人物
            创建后台世界();
            // 创建前台世界
            创建前台世界();
            // 调用流程创建世界
            CreateWorld();
            // 创建并显示信息面板
            CreateInfoPanel();
        }
}
    //流程函数
    public static partial class GameManager{
        public static void 创建后台世界(){
            WorldInstance = InitializeWorld(10, 10, 10);
            WorldInstance.Player = InitializePlayer(5f, 5f);
        }
        public static void 创建前台世界(){
            FrontendInstance = new GameObject("FrontendWorld").AddComponent<FrontendWorld>();
        }
        public static void CreateWorld(){
            for (int x = 0; x < WorldInstance.Width; x++){
                for (int y = 0; y < WorldInstance.Height; y++){
                    FrontendInstance.CreateTileUI(x, y, WorldInstance.Grid[x, y]);  // 传递 TileInfo
                }
            }
            PlayerObj=FrontendInstance.CreatePlayer(WorldInstance.Player);//创建人物
        }
        public static void CreateInfoPanel(){
            // 动态创建一个 GameObject 来承载 InfoPanel 组件
            GameObject infoPanelObject = new GameObject("InfoPanel");

            // 将 InfoPanel 组件添加到 GameObject 上
            InfoPanel infoPanel = infoPanelObject.AddComponent<InfoPanel>();

            // 调用 InfoPanel 的创建方法
            infoPanel.CreateInfoPanel();
        }
    }
}
