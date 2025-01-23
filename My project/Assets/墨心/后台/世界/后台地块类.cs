using System.Collections.Generic;
using UnityEngine;

namespace 墨心.Task8 {
    public class 后台地块类 : I地块 {
        public Vector2Int 坐标 { get; set; }
        public I土质层 土质层 { get; set; }
        public I矿石层 矿石层 { get; set; }
        public I地板层 地板层 { get; set; }
        public I建筑层 建筑层 { get; set; }
        public I悬浮层 悬浮层 { get; set; }
        public void 开采矿物() {
            if (矿石层 == null) {
                return;
            }
            if (矿石层.数量 > 0) {
                矿石层.数量 -= 1;
                Event.地块采集成功(this);
            }
            if (矿石层.数量 == 0) {
                矿石层 = null;
                Event.地块矿石采光(this);
            }
        }
        public void 拆除建筑() {
            if (建筑层 == null) {
                return;
            }
            if (建筑层.耐久 > 0) {
                建筑层.耐久 -= 1;
                Event.建筑受伤(this);
            }
            if (建筑层.耐久 == 0) {
                var A = 建筑层.类型.掉落();
                if (A!= null) {
                    悬浮层 = 悬浮类.To悬浮(A);//掉落文本格式：XX*X XX*X
                    Event.建筑掉落(this);
                }
                建筑层 = null;
                Event.地块建筑被毁(this);
            }
        }
        public string 展示文本() {
            if (建筑层 != null) {
                return $"地块类型: {建筑层.类型}\n数量: {建筑层.耐久}";
            }
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