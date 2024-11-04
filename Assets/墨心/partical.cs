using UnityEngine;

namespace 墨心{
    public static class Utils{
        // 加载精灵的静态方法
        public static Sprite LoadSprite(string path){
            try{
                return Resources.Load<Sprite>(path);
            }
            catch (System.Exception e){
                HandleError($"Failed to load sprite at {path}: {e.Message}");  // 处理加载精灵时的错误
                return null;
            }
        }

        // 错误处理方法
        public static void HandleError(string message){
            Debug.LogError(message);  // 记录错误信息
        }
    }

    public static class GameManager{
        public static World WorldInstance { get; private set; }  // 存储后台世界的实例
        public static FrontendWorld FrontendInstance { get; private set; }  // 存储前台世界的实例

        // 主方法，程序入口
        public static void Main(){
            // 创建后台世界
            WorldInstance = new World(10, 10);

            // 创建前台世界
            FrontendInstance = new FrontendWorld();

            // 调用流程创建世界
            Process.CreateWorld(FrontendInstance, WorldInstance);
        }
    }

    public static class Process{
        public static void CreateWorld(FrontendWorld frontend, World world){
            int gridWidth = world.Grid.GetLength(0);  // 获取地图的宽度（行数）
            int gridHeight = world.Grid.GetLength(1);  // 获取地图的高度（列数）

            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    frontend.CreateTileUI(x, y, world.Grid[x, y]);  // 传递 TileInfo
                }
            }
        }
    }
}
