using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class 后台背包类:I背包 {
        public I物品[,] Grid { get; set; }
        public int Width => Grid.GetLength(0);
        public int Height => Grid.GetLength(1);
        public void 创建背包(int 宽度, int 高度) {
            Print("正在创建背包...");
            Grid = new 后台物品类[宽度, 高度];
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    Grid[i, j] = new 后台物品类 { 坐标 = new Vector2Int(i, j) };
                }
            }
        }
        public bool 添加物品(I物品 X) {
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    if (Grid[i, j] == null) {
                        Grid[i, j] = X;
                        X.坐标 = new Vector2Int(i, j);
                        Print("物品添加到位置: " + new Vector2Int(i, j));
                        return true;
                    }
                }
            }
            Print("背包已满，无法添加物品");
            return false;
        }
    }
}
