﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public List<芥子<T>> GetRound(int X, int Y, int 半径 = 1, bool 空心 = true) {
            var A = new List<芥子<T>> {
                Values[X-半径, Y-半径],Values[X, Y-半径],Values[X+半径, Y-半径],
                Values[X-半径, Y],Values[X+半径, Y],
                Values[X-半径, Y+半径],Values[X, Y+半径],Values[X+半径, Y+半径],
            };
            var B = new List<芥子<T>>(A) { Values[X, Y] };
            return (半径 == 1) ? (空心 ? A : B) : new List<芥子<T>>();
        }
        //public Grid<T> 生成小堆(int X, int Y, int 尺寸) {

        //}
        public Grid<T> 生成大区(int X, int Y, int 尺寸) {
            var 背景网格 = Clone();
            var 目标网格 = Clone().Clear();
            var 边缘网格 = Clone().Clear();
            目标网格.Add(背景网格[X, Y]);
            边缘网格.Add(背景网格[X, Y]);
            背景网格.RemoveAt(X, Y);
            while (目标网格.Count() < 尺寸 && 边缘网格.Count() > 0) {
                var 随机边缘坐标 = 边缘网格.RandomSpace();
                var 周围八格 = GetRound(随机边缘坐标.X, 随机边缘坐标.Y);
                var 外界点 = 周围八格.Choice(t => 背景网格.Contains(t));
                if (外界点 == null) {
                    边缘网格.RemoveAt(随机边缘坐标.X,随机边缘坐标.Y);
                    continue;
                }
                目标网格.Add(外界点);
                边缘网格.Add(外界点);
                背景网格.RemoveAt(外界点.X,外界点.Y);
                foreach (var i in GetRound(外界点.X, 外界点.Y)) {
                    if (i == null) {
                        边缘网格.RemoveAt(i.X, i.Y);
                    }
                }
            }
            return 目标网格;
        }
        public Grid<T> Clone() {
            var A = new Grid<T>(宽度, 高度);
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    A[i, j] = new 芥子<T> {
                        X = Values[i, j].X,
                        Y = Values[i, j].Y,
                        Value = Values[i, j].Value
                    };
                }
            }
            return A;
        }
        public Grid<T> Clear() {
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    Values[i, j] = new 芥子<T> {
                        X = i,
                        Y = j,
                        Value = default(T)
                    };
                }
            }
            return this;
        }
        public Grid<T> Add(芥子<T> X) {
            this[X.X, X.Y] = X;
            return this;
        }
        public int Count() {
            int count = 0;
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    if (!EqualityComparer<T>.Default.Equals(Values[i, j].Value, default(T))) {
                        count++;
                    }
                }
            }
            return count;
        }
        public Grid<T> RemoveAt(int X,int Y) {
            Values[X, Y] = new 芥子<T> {
                X = X,
                Y = Y,
                Value = default(T)
            };
            return this;
        }
        public 芥子<T> RandomSpace() {
            System.Random rand = new System.Random();
            int randomX = rand.Next(0, 宽度);
            int randomY = rand.Next(0, 高度);
            return Values[randomX, randomY];
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
    }
}