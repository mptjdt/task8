using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class World {
        public TileInfo[,] Grid { get; set; }// 每个地块存储一个TileInfo
        public int Width => Grid.GetLength(0);// 宽度属性       
        public int Height => Grid.GetLength(1);// 高度属性
        public Player Player { get; set; }//人物
    }
    public static partial class GameManager {
        // 静态方法，初始化地块网格并返回初始化后的 World 对象
        public static World InitializeWorld(int width, int height) {
            World world = new World();  // 创建新的 World 实例
            world.Grid = new TileInfo[width, height];  // 根据指定大小创建网格
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    world.Grid[x, y] = new TileInfo(); // 初始化 TileInfo 实例
                    world.Grid[x, y].土质层=创建沙漠地块();
                }
            }
            return world;  // 返回初始化后的 World 对象
        }   
    }
}