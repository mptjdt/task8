using UnityEngine;

namespace 墨心 {
    public interface I层级 {

    }
    public interface I地板层 : I层级 {
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
        石地板,
    }
    public enum 建筑种类 {
        无,
        树木,
        箱子,
    }
    public enum 矿石种类 {
        无,
        铜矿,
        铁矿,
    }
    public enum 土质种类 {
        虚空,
        沙漠,
        淡水,
    }
    public enum 悬浮种类 {
        无,
    }
}