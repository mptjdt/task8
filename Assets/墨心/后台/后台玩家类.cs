using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace 墨心 {
    public class 后台玩家类 {
        public Vector2 Position = new(0, 0);
        public float 旋转角度;
        public float 移动速度;
        public float 旋转速度;
        public static 后台玩家类 InitializePlayer(float 移速, float 转速) {
            var A = new 后台玩家类();
            A.移动速度 = 移速;
            A.旋转速度 = 转速;
            return A;
        }
    }
}