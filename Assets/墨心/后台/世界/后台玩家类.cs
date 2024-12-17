using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace 墨心 {
    public class 后台玩家类 : I角色 {
        public Vector2 坐标 { get; set; }
        public float 旋转角度 { get; set; }
        public float 移动速度 { get; set; }
        public float 旋转速度 { get; set; }
        public I背包 背包 { get; set; }
    }
}