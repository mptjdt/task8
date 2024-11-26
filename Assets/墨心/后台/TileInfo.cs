using System.Collections.Generic;

namespace 墨心 {
    public class TileInfo {
        public 土质类 土质层 { get; set; }
        public 矿石类 矿石层 { get; set; }
        public 地板类 地板层 { get; set; }
        public 建筑类 建筑层 { get; set; }
        public 悬浮类 悬浮层 { get; set; }
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
