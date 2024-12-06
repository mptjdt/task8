using UnityEngine;

namespace 墨心 {
    public interface I地块 {
        public Vector2Int 位置 { get; }
        public I地板层 地板层 { get; }
        public void 开采();
    }
    public interface I世界 {
        public int Width { get; }
        public int Height { get; }
    }
    public interface I角色 {
        public Vector2 Position { get; }
        public float 旋转角度 { get; }
        public float 移动速度 { get; }
        public float 旋转速度 { get; }
    }
    public interface I层级 {

    }
    public interface I地板层: I层级 {

    }
    public interface I建筑层 : I层级 {

    }
    public interface I矿石层 : I层级 {

    }
    public interface I土质层 : I层级 {

    }
    public interface I悬浮层 : I层级 {

    }
    public enum 地板种类 {

    }
    public enum 建筑种类 {

    }
}