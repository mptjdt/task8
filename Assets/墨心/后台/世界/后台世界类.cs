using System;
using UnityEngine;
using static 墨心.GameManager;
using Random = UnityEngine.Random;

namespace 墨心.Task8 {
    public class 后台世界类 : I世界 {
        private I地块[,] Grid;
        public I地块 this[int x, int y] {
            get {
                if (x < 0 || x >= Grid.GetLength(0) || y < 0 || y >= Grid.GetLength(1)) {
                    throw new Exception("坐标越界");
                }
                return Grid[x, y];
            }
            set {
                if (x < 0 || x >= Grid.GetLength(0) || y < 0 || y >= Grid.GetLength(1)) {
                    throw new Exception("坐标越界");
                }
                Grid[x, y] = value;
            }
        }
        public int Width => Grid.GetLength(0);
        public int Height => Grid.GetLength(1);
        public I角色 Player { get; set; }
        public void 创建世界(int 宽度, int 高度) {
            Print("正在创建世界...");
            Grid = new 后台地块类[宽度, 高度];
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    Grid[i, j] = new 后台地块类 { 坐标 = new Vector2Int(i, j) };
                }
            }
        }
        public void 洒下几堆铜矿(int 尺寸, int 数量) {
            Print("正在洒下铜矿...");
            for (int i = 0; i < 数量; i++) {
                传染铜矿(Random.Range(0, Width), Random.Range(0, Height), 尺寸);
            }
        }
        private void 传染铜矿(int X, int Y, int 剩余传染次数) {
            if (剩余传染次数 <= 0 ) return;
            this[X, Y].矿石层 = 矿石类.创建铜矿地块();
            传染铜矿(X + Choice(0, 1, -1), Y + Choice(0, 1, -1), 剩余传染次数 - 1);
        }
        public void 填充沙漠() {
            Print("正在填充沙漠...");
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    this[i, j].土质层 = 土质类.创建沙漠地块();
                }
            }
        }
        public void 填充草地(int 尺寸,int 数量) {
            Print("正在填充草地...");
            int X = Random.Range(0, Width);
            int Y = Random.Range(0, Height);
            边缘地块列表.Add(new Vector2Int(X, Y));
            for (int i = 0; i < 数量; i++) {
                var 边缘地块 = 边缘地块列表[Random.Range(0, 边缘地块列表.Count)];
                传染草地(边缘地块.x, 边缘地块.y, 尺寸);
            }
        }
        private void 传染草地(int X, int Y, int 剩余传染次数) {
            if (剩余传染次数 <= 0) return;     
            this[X, Y].土质层 = 土质类.创建草地地块();
            var A = 边缘地块列表[Random.Range(0, 边缘地块列表.Count)];
            var B = A.x + Choice(0, 1, -1);
            var C = A.y + Choice(0, 1, -1);
            更新边缘地块列表(B, C);
            传染草地(B, C, 剩余传染次数 - 1);
        }
        private List<Vector2Int> 边缘地块列表 = new List<Vector2Int>();
        private void 更新边缘地块列表(int X, int Y) {
            if (判断边缘地块(X, Y)) {
                边缘地块列表.Add(new Vector2Int(X, Y));
            }
            //移除非边缘地块();
        }
        private bool 判断边缘地块(int X, int Y) {
            if (X <= 1 || Y <= 1 || X >= Width - 1 || Y >= Height - 1) {
                return false;
            }
            if (this[X - 1, Y].土质层.类型 == 土质种类.草地 &&
                this[X + 1, Y].土质层.类型 == 土质种类.草地 &&
                this[X, Y - 1].土质层.类型 == 土质种类.草地 &&
                this[X, Y + 1].土质层.类型 == 土质种类.草地) {
                return false;
            }
            return true;
        }
        //private void 移除非边缘地块() {
            //边缘地块列表.RemoveAll(地块 => !判断边缘地块(地块.x, 地块.y));
        //}
        public void 种植树木() {
            Print("正在种植树木...");
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    if (Random.value < 0.04f && this[i, j].土质层.类型 == 土质种类.草地) {
                        this[i, j].建筑层 = 建筑类.创建树木地块();
                    }
                }
            }
            for (int k = 0; k < 4; k++) {
                int i, j;
                do {
                    i = Random.Range(0, Width);
                    j = Random.Range(0, Height);
                } while (this[i, j].土质层.类型 != 土质种类.草地);
                this[i, j].建筑层 = 建筑类.创建树木地块();
            }
        }
        public void 创建玩家(玩家设定类 X) {
            Player = new 后台玩家类();
            Player.移动速度 = X.玩家移速;
            Player.旋转速度 = X.玩家转速;
            Player.血量 = X.玩家血量;
            Player.饱腹值 = X.玩家饱腹值;
            Player.背包 = new 后台背包类();
        }
    }
}