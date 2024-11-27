using System.Collections.Generic;
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
        public static World InitializeWorld(int width, int height) {
            World world = new World();  // 创建新的 World 实例
            world.Grid = new TileInfo[width, height];  // 根据指定大小创建网格
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    world.Grid[x, y] = new TileInfo(); // 初始化 TileInfo 实例
                }
            }
            return world;  // 返回初始化后的 World 对象
        }
        public static TileInfo 获取当前地块(Vector2 screenPosition) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);// 使用摄像头将屏幕坐标转换为世界坐标
            int gridX = Mathf.FloorToInt(worldPos.x);  // 取整转换为网格坐标
            int gridY = Mathf.FloorToInt(worldPos.y);  // 取整转换为网格坐标          
            gridX = Mathf.Clamp(gridX, 0, WorldInstance.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, WorldInstance.Height - 1); // 将世界坐标转换为网格坐标                                                                     // 判断是否在有效地块范围内
            if (gridX < 0 || gridX >= WorldInstance.Width || gridY < 0 || gridY >= WorldInstance.Height) {
                return null;  // 如果超出范围，返回 null 或其他表示无效的值
            }
            return WorldInstance.Grid[gridX,gridY];// 根据网格坐标获取当前地块并返回
        }
    }
}