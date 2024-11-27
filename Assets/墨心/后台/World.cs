using System.Collections.Generic;
using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class World {
        public TileInfo[,] Grid;
        public int Width => Grid.GetLength(0);
        public int Height => Grid.GetLength(1);
        public Player Player;
        public void 创建世界(int 宽度, int 高度) {
            Print("正在创建世界...");
            Grid = new TileInfo[宽度, 高度];
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    Grid[i, j] = new TileInfo();
                }
            }
        }
        public void 洒下铜矿(int 单个矿堆矿石数, int 矿堆个数) {
            Print("正在洒下铜矿...");
            for (int i = 0; i < 矿堆个数; i++) {
                传染铜矿(Random.Range(0, Width), Random.Range(0, Height), 单个矿堆矿石数);
            }
        }
        private void 传染铜矿(int X, int Y, int 剩余传染次数) {
            if (剩余传染次数 <= 0 || X < 0 || Y < 0 || X >= Width || Y >= Height) return;
            Grid[X, Y].矿石层 = 矿石类.创建铜矿地块();
            传染铜矿(X + Choice(0, 1, -1), Y + Choice(0, 1, -1), 剩余传染次数 - 1);
        }
        public void 填充沙漠() {
            Print("正在填充沙漠...");
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    Grid[i, j].土质层 = 土质类.创建沙漠地块();
                }
            }
        }
    }
    public static partial class GameManager {
        public static TileInfo 获取当前地块(Vector2 screenPosition) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);// 使用摄像头将屏幕坐标转换为世界坐标
            int gridX = Mathf.FloorToInt(worldPos.x);  // 取整转换为网格坐标
            int gridY = Mathf.FloorToInt(worldPos.y);  // 取整转换为网格坐标          
            gridX = Mathf.Clamp(gridX, 0, 后台实例.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, 后台实例.Height - 1); // 将世界坐标转换为网格坐标                                                                     // 判断是否在有效地块范围内
            if (gridX < 0 || gridX >= 后台实例.Width || gridY < 0 || gridY >= 后台实例.Height) {
                return null;  // 如果超出范围，返回 null 或其他表示无效的值
            }
            return 后台实例.Grid[gridX,gridY];// 根据网格坐标获取当前地块并返回
        }
    }
}