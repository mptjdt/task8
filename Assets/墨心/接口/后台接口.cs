using System.Collections.Generic;
using UnityEngine;

namespace 墨心.Task8 {
    public interface I世界 {
        public I地块 this[int X, int Y] { get;set; }
        public int Width { get; }
        public int Height { get; }
        public I角色 Player { get; set; }
    }
    public interface I地块 {
        public Vector2Int 坐标 { get; set; }
        public I土质层 土质层 { get; set; }
        public I矿石层 矿石层 { get; set; }
        public I地板层 地板层 { get; set; }
        public I建筑层 建筑层 { get; set; }
        public I悬浮层 悬浮层 { get; set; }
        public void 开采矿物();
        public void 拆除建筑();
        public string 展示文本();
    }
    public interface I角色 {
        public Vector2 坐标 { get; set; }
        public float 旋转角度 { get; set; }
        public float 移动速度 { get; set; }
        public float 旋转速度 { get; set; }
        public int 血量 {  get; set; }
        public int 饱腹值 { get; set; }
        public I背包 背包 { get; set; }
        public string 展示文本();
        public void 掉血(int X);
        public void 扣除饱腹值(int X);
        public void 注册每帧行为();
    }
    public interface I背包 {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<I物品> 物品列表 { get; set; }
        public void 创建背包(int X, int Y);
        public bool 添加物品(I物品 X);
    }
    public interface I物品 {
        public string 名称 { get; set; }
        public int 数量 { get; set; }
        public int 槽位 { get; set; }
    }
}