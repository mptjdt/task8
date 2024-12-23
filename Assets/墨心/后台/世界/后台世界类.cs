﻿using System.Collections.Generic;
using UnityEngine;
using static 墨心.GameManager;

namespace 墨心.Task8 {
    public class 后台世界类 : I世界 {
        private I地块[,] Grid;
        public I地块 this[int x, int y] {
            get => Grid[x, y];
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
        public void 填充草地() {
            Print("正在填充草地...");
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    if (UnityEngine.Random.value < 0.4f) {
                        Grid[i, j].土质层 = 土质类.创建草地地块();
                    }
                }
            }
        }
        public void 种植树木() {
            Print("正在种植树木...");
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    if (UnityEngine.Random.value < 0.04f&& Grid[i, j].土质层.类型== 土质种类.草地) {
                        Grid[i, j].建筑层 = 建筑类.创建树木地块();
                    }
                }
            }
        }
        public void 创建玩家(int 玩家移速, int 玩家转速,int 玩家血量,int 玩家饱腹值) {
            Player = new 后台玩家类();
            Player.移动速度 = 玩家移速;
            Player.旋转速度 = 玩家转速;
            Player.血量 = 玩家血量;
            Player.饱腹值 = 玩家饱腹值;
            Player.背包 = new 后台背包类();
            Player.注册每帧行为();
        }
    }
}