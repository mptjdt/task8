using System.Collections.Generic;
using UnityEngine;

namespace 墨心 {
    public class TileInfo {
        public Vector2Int 位置;
        public 土质类 土质层;
        public 矿石类 矿石层;
        public 地板类 地板层;
        public 建筑类 建筑层;
        public 悬浮类 悬浮层;
        public void 开采() {
            if (矿石层 != null) {
                if (矿石层.数量 > 0) {
                    矿石层.数量 -= 1;
                }
                if (矿石层.数量 == 0) {
                    Event.地块采光(位置);
                }
            }
        }
    }
    public static partial class GameManager {
        public static string 获取土质类型字符串(TileInfo tileinfo) {
            return tileinfo.土质层.类型.ToString();
        }
        public static string 获取矿石类型字符串(TileInfo tileinfo) {
            return tileinfo.矿石层.类型.ToString();
        }
    }
}