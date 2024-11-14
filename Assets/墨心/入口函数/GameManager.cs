using System.Diagnostics;
using UnityEngine;
//项目入口文件
namespace 墨心{
    // 部分类：包含入口函数
    public static partial class GameManager{
        public static World WorldInstance { get; private set; }  // 存储后台世界的实例
        public static FrontendWorld FrontendInstance { get; private set; }  // 存储前台世界的实例

        // 主方法，程序入口
        public static void Mainstart(){
            // 创建后台世界和人物
            WorldInstance = InitializeWorld(10, 10);
            WorldInstance.Player = InitializePlayer(5f,5f);
            // 创建前台世界
            GameObject frontendObj = new GameObject("FrontendWorld");
            FrontendInstance = frontendObj.AddComponent<FrontendWorld>();
            // 调用流程创建世界
            CreateWorld();
        }
        //流程函数
        public static partial class GameManager{
            public static void CreateWorld(){
                int gridWidth = WorldInstance.Width;  // 获取地图的宽度（行数）
                int gridHeight = WorldInstance.Height;  // 获取地图的高度（列数）
                for (int x = 0; x < gridWidth; x++){
                    for (int y = 0; y < gridHeight; y++){
                        FrontendInstance.CreateTileUI(x, y, WorldInstance.Grid[x, y]);  // 传递 TileInfo
                    }
                }
                FrontendInstance.ShowPlayer(WorldInstance.Player);//创建人物
            }
        }
    }
   
}
