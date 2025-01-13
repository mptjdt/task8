using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace 墨心 {
    public class Grid<T> {
        public int 宽度;
        public int 高度;
        public 芥子<T>[,] Values;
        public Grid(int 宽度, int 高度) {
            //初始化
        }
        public List<芥子<T>> GetRound(int X, int Y, int 半径 = 1, bool 空心 = true) {
            //当半径为1时，获取目标格子周围八格坐标
            //当实心时，半径1获得的是九格
        }
        public List<芥子<T>> 生成小堆(int X, int Y, int 尺寸) {

        }
        public List<芥子<T>> 生成大区(int X, int Y, int 尺寸) {
            var 背景网格 = Clone();
            var 目标网格 = Clone().Clear();
            var 边缘网格 = Clone().Clear();
            //先提把整个地图放入背景
            //然后选目标点，放入目标与边缘，从背景中移除
            //然后从边缘中随机选一个点，获取其周围8格中的一个在背景的点，放入目标与边缘，从背景中移除。并从边缘中移除不再是边缘的点（节约算力，只检查新点周围8格）
            //如此，执行 图形尺寸 次
            目标网格.Add(背景网格[X, Y]);
            边缘网格.Add(背景网格[X, Y]);
            背景网格.RemoveAt(X, Y);
            while (目标网格.Count < 尺寸 && 边缘网格.Count > 0) {
                var 随机边缘坐标 = 边缘网格.RandomSpace();
                var 周围八格 = GetRound(随机边缘坐标.x, 随机边缘坐标.y);
                var 外界点 = 周围八格.Choice(t => 背景网格.Contains(t));
                if (外界点 == null) {
                    边缘网格.RemoveAt(随机边缘坐标);
                    continue;
                }
                目标网格.Add(外界点);
                边缘网格.Add(外界点);
                背景网格.Remove(外界点);
                foreach (var i in GetRound(外界点.x, 外界点.y)) {
                    //从边缘中移除不再是边缘的点（节约算力，只检查新点周围8格）
                }
            }
            return 目标网格;
        }
    }
    public class 芥子<T> {
        public int X;
        public int Y;
        public T Value;
        //隐式转化为T
        public static implicit operator T(芥子<T> 芥子) {
            return 芥子.Value;
        }
    }
}