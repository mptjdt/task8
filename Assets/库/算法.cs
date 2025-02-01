﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

namespace 墨心 {
    public class Grid<T> {
        public int 宽度 => Values.GetLength(0);
        public int 高度 => Values.GetLength(1);
        public 芥子<T>[,] Values;
        public Grid(int 宽度, int 高度) {
            Values = new 芥子<T>[宽度, 高度];
            for(int i = 0; i < 宽度; i++) {
                for(int j = 0; j < 高度; j++){
                    Values[i, j] = new 芥子<T> {
                        X = i,
                        Y = j,
                        Value = default(T)
                    };
                }
            }
        }
        public 芥子<T> this[int x, int y] {
            get {
                if (x < 0 || x >= Values.GetLength(0) || y < 0 || y >= Values.GetLength(1)) {
                    throw new Exception("坐标越界");
                }
                return Values[x, y];
            }
            set {
                if (x < 0 || x >= Values.GetLength(0) || y < 0 || y >= Values.GetLength(1)) {
                    throw new Exception("坐标越界");
                }
                Values[x, y] = value;
            }
        }
        public 芥子<T> TryGetValue(int x, int y) {
            if (x < 0 || x >= 宽度 || y < 0 || y >= 高度) {
                return null;
            }
            return Values[x, y];
        }
        public List<芥子<T>> GetRound(int X, int Y, int 半径 = 1, bool 空心 = true) {
            var A = new List<芥子<T>>();
            for (int i = -半径; i <= 半径; i++) {
                for (int j = -半径; j <= 半径; j++) {
                    if (i == 0 && j == 0 && !空心) continue; // Skip the center if not hollow
                    var B = TryGetValue(X + i, Y + j);
                    if (B != null) {
                        A.Add(B);
                    }
                }
            }
            return A;
        }
        //public Grid<T> 生成小堆(int X, int Y, int 尺寸) {

        //}
        public List<芥子<T>> 生成大区(int X, int Y, int 尺寸) {
            var 背景网格 = Clone();
            var 目标网格 = new List<芥子<T>>();
            var 边缘网格 = new List<芥子<T>>();
            目标网格.Add(this[X, Y]);
            边缘网格.Add(this[X, Y]);
            背景网格.Remove(this[X,Y]);
            while (目标网格.Count() < 尺寸 && 边缘网格.Count() > 0) {
                var 随机边缘坐标 = 边缘网格.RandomSpace();
                var 周围八格 = GetRound(随机边缘坐标.X, 随机边缘坐标.Y);
                var 外界点 = 周围八格.Choice(t => 背景网格.Contains(t));
                if (外界点 == null) {
                    边缘网格.Remove(随机边缘坐标);
                    continue;
                }
                目标网格.Add(外界点);
                边缘网格.Add(外界点);
                背景网格.Remove(外界点);
                foreach (var i in GetRound(外界点.X, 外界点.Y)) {
                    if (i == null) {
                        边缘网格.Remove(i);
                    }
                }
            }
            return 目标网格;
        }
        public List<芥子<T>> Clone() {
            var A = new List<芥子<T>>();
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    A.Add(Values[i, j]);
                }
            }
            return A;
        }
        public bool Contains(芥子<T> 芥子) {
            return this[芥子.X, 芥子.Y].X == 芥子.X &&
                   this[芥子.X, 芥子.Y].Y == 芥子.Y &&
                   EqualityComparer<T>.Default.Equals(this[芥子.X, 芥子.Y].Value, 芥子.Value);
        }
    }
    public class 芥子<T> {
        public int X;
        public int Y;
        public T Value;
        public static implicit operator T(芥子<T> 芥子) {
            return 芥子.Value;
        }
    }
    public static class GridExtensions {
        public static 芥子<T> Choice<T>(this List<芥子<T>> list, Func<芥子<T>, bool> X) {
            return list.FirstOrDefault(X);
        }
        private static Random random = new Random();
        public static T RandomSpace<T>(this List<T> list) {
            if (list == null || list.Count == 0) {
                throw new Exception("列表为空");
            }
            var A = random.Next(list.Count);
            return list[A];
        }
    }
}