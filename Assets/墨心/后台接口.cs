using UnityEngine;

namespace 墨心 {
    public interface I地块 {
        public Vector2Int 位置 { get; set; }
        public I土质层 土质层 { get; set; }
        public I矿石层 矿石层 { get; set; }
        public I地板层 地板层 { get; }
        public I建筑层 建筑层 { get; }
        public I悬浮层 悬浮层 { get; }
        public void 开采();
    }
    public interface I世界 {
        public int Width { get;}
        public int Height { get;}
        public I角色 Player { get; set; }
        public I地块[,] Grid { get; set; }
    }
    public interface I角色 {
        public Vector2 Position { get; set; }
        public float 旋转角度 { get; set; }
        public float 移动速度 { get; set; }
        public float 旋转速度 { get; set; }
    }
    public interface I层级 {

    }
    public interface I地板层: I层级 {
        public 地板种类 类型 { get; set; }
        public int 数量 { get; set; }
    }
    public interface I建筑层 : I层级 {
        public 建筑种类 类型 { get; set; }
        public int 数量 { get; set; }
    }
    public interface I矿石层 : I层级 {
        public 矿石种类 类型 { get; set; }
        public int 数量 { get; set; }
    }
    public interface I土质层 : I层级 {
        public 土质种类 类型 { get; set; }
    }
    public interface I悬浮层 : I层级 {
        public 悬浮种类 类型 { get; set; }
        public int 数量 { get; set; }
    }
    public enum 地板种类 {
        无,
        石地板
    }
    public enum 建筑种类 {
        无,
        树木,
        箱子
    }
    public enum 矿石种类 {
        无,
        铜矿,
        铁矿,
    }
    public enum 土质种类 {
        虚空,
        沙漠,
        淡水
    }
    public enum 悬浮种类 {
        无
    }
}