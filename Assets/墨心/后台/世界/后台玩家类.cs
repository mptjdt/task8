using System;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using static 墨心.GameManager;

namespace 墨心.Task8 {
    public class 后台玩家类 : I角色 {
        public Vector2 坐标 { get; set; }
        public float 旋转角度 { get; set; }
        public float 移动速度 { get; set; }
        public float 旋转速度 { get; set; }
        public int 血量 { get; set; }
        public int 饱腹值 { get; set; }
        public I背包 背包 { get; set; }
        public void 注册每帧行为() {
            OnAppSeconds(3, () => 扣除饱腹值(1));
            OnAppSeconds(1, () => {
                if (饱腹值 == 0) {
                    掉血(1);
                }
            });
        }
        public string 展示文本() {
            return $"饱腹值: {饱腹值}\n血量: {血量}";
        }
        public void 掉血(int X) {
            血量 = Math.Max(血量 - X, 0);
            if (血量 == 0) {
                Event.玩家死亡();
            }
        }
        public void 扣除饱腹值(int X) {
            饱腹值 = Math.Max(饱腹值 - X, 0);
        }
    }
}