using UnityEngine;
//流程文件
namespace 墨心{
    //流程函数
    public static partial class GameManager{
        public static void CreateWorld(int m,int n){
            InitializeWorld(WorldInstance, m, n);
            int gridWidth = WorldInstance.Grid.GetLength(0);  // 获取地图的宽度（行数）
            int gridHeight = WorldInstance.Grid.GetLength(1);  // 获取地图的高度（列数）

            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    FrontendInstance.CreateTileUI(x, y, WorldInstance.Grid[x, y]);  // 传递 TileInfo
                }
            }
        }
    }
}