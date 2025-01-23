using System.Collections.Generic;
using UnityEngine;

namespace 墨心.Task8 {
    public interface I世界系统 {
        public Dictionary<Vector2Int, GameObject> 所有矿石 { get; set; }
        public Dictionary<Vector2Int, GameObject> 所有土质 { get; set; }
        public Dictionary<Vector2Int, GameObject> 所有建筑 { get; set; }
        public GameObject 玩家 { get; set; }
        public void 创建玩家(I角色 X);
        public void 创建土质层(int X, int Y, I地块 Z);
        public void 创建矿石层(int X, int Y, I地块 Z);
        public void 创建建筑层(int X, int Y, I地块 Z);        
    }
    public interface IUI系统 {
        public GameObject 信息面板 { get; set; }
        public Dictionary<int, GameObject> 所有物品 { get; set; }
        public GameObject 背包面板 { get; set; }
        public GameObject 角色面板 { get; set; }
        public void 创建信息面板();
        public void 创建背包面板(bool X);
        public void 创建角色面板();
        public void 更新背包显示(I背包 X);
        public void 开关背包(bool X);
    }
    public interface I存档管理 {
        public void 存档();
        public bool 读档();
    }
    public interface I笔记 {
        bool 背包是否打开 { get; set; }
    }
}