using System.Collections.Generic;
using UnityEngine;

namespace 墨心 {
    public class 后台地块类 : I地块 {
        public Vector2Int 坐标 { get; set; }
        public I土质层 土质层 { get; set; }
        public I矿石层 矿石层 { get; set; }
        public I地板层 地板层 { get; set; }
        public I建筑层 建筑层 { get; set; }
        public I悬浮层 悬浮层 { get; set; }
        public void 开采() {
            if (矿石层 != null) {
                if (矿石层.数量 > 0) {
                    矿石层.数量 -= 1;
                }
                if (矿石层.数量 == 0) {
                    Event.地块采光(坐标);
                    矿石层 = null;
                }
            }
        }
        public string 展示文本() {
            if (矿石层 != null) {
                return $"地块类型: {矿石层.类型}\n数量: {矿石层.数量}";
            }
            if (土质层 != null) {
                return $"地块类型: {土质层.类型}\n数量: {-1}";
            }
            return "未知";
        }
    }
}