using System;
using System.Collections.Generic;
using UnityEngine;
using static 墨心.LocalStorage;
using Random = UnityEngine.Random;
using 墨心;

namespace 墨心.Task8 {
    public class 后台世界类 : I世界 {
        private Grid<I地块> grid;
        public I地块 this[int x, int y] {
            get {
                if (x < 0 || x >= grid.宽度 || y < 0 || y >= grid.高度) {
                    throw new Exception("坐标越界");
                }
                return grid[x, y].Value;
            }
            set {
                if (x < 0 || x >= grid.宽度 || y < 0 || y >= grid.高度) {
                    throw new Exception("坐标越界");
                }
                grid[x, y].Value = value;
            }
        }
        public int Width => grid.宽度;
        public int Height => grid.高度;
        public I角色 Player { get; set; }
        public bool Is坐标合法(int x,int y) {
            if (x < 0 || x >= grid.宽度 || y < 0 || y >= grid.高度) {
                return false;
            }
            return true;
        }
        public void 创建世界(int 宽度, int 高度) {
            Print("正在创建世界...");
            grid = new Grid<I地块>(宽度, 高度);
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    grid[i, j] = new 芥子<I地块> { X = i, Y = j, Value = new 后台地块类 { 坐标 = new Vector2Int(i, j) } };
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
            if (!Is坐标合法(X, Y)) return;
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
        public void 填充草地(int 尺寸) {
            Print("正在填充草地...");
            var 目标网格 = grid.生成大区(Random.Range(0, Width), Random.Range(0, Height), 尺寸);
            for (int i = 0; i < grid.宽度; i++) {
                for (int j = 0; j < grid.高度; j++) {
                    var 芥子 = grid[i, j];
                    this[芥子.X, 芥子.Y].土质层 = 土质类.创建草地地块();
                }
            }
        }
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