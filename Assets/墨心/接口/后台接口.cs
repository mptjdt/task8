using UnityEngine;

namespace 墨心 {
    public interface I世界 {
        public I地块 this[int X, int Y] { get; }
        //public I地块[,] Grid { get; set; }
        public int Width { get; }
        public int Height { get; }
        public I角色 Player { get; set; }
    }
    public interface I地块 {
        public Vector2Int 坐标 { get; set; }
        public I土质层 土质层 { get; set; }
        public I矿石层 矿石层 { get; set; }
        public I地板层 地板层 { get; }
        public I建筑层 建筑层 { get; }
        public I悬浮层 悬浮层 { get; }
        public void 开采();
        public string 展示文本();
    }
    public interface I角色 {
        public Vector2 坐标 { get; set; }
        public float 旋转角度 { get; set; }
        public float 移动速度 { get; set; }
        public float 旋转速度 { get; set; }
        public I背包 背包 { get; set; }
    }
    public interface I背包 {
        public int Width { get; }
        public int Height { get; }
        public I物品[,] Grid { get; set; }
        public void 创建背包(int X, int Y);
        public bool 添加物品(I物品 X);
    }
    public interface I物品 {
        public string 名称 { get; set; }
        public int 数量 { get; set; }
        public Vector2Int 槽位 { get; set; }
    }
}