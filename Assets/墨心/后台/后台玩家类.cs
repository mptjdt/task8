﻿using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace 墨心 {
    public class 后台玩家类 : I角色 {
        //public Vector2 坐标 { get; set; } = new Vector2(0, 0);
        public Vector2 坐标 { get; set; }
        public float 旋转角度 { get; set; }
        public float 移动速度 { get; set; }
        public float 旋转速度 { get; set; }
        public static 后台玩家类 InitializePlayer(float 移速, float 转速) {
            var A = new 后台玩家类();
            A.移动速度 = 移速;
            A.旋转速度 = 转速;
            return A;
        }
    }
}