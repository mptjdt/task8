using System.Collections.Generic;

namespace 墨心 {
    public class TileInfo {
        public string SoilType { get; set; }// 地块的土质类型字段
        public int 数量 { get; set; }
    }
    public static partial class GameManager {
        public static TileInfo 创建沙漠地块() {
            TileInfo tileInfo= new TileInfo();
            tileInfo.SoilType = "desert";
            tileInfo.数量 = -1;          
            return tileInfo;  
        }
        public static TileInfo 创建石头地块() {
            TileInfo tileInfo = new TileInfo();
            tileInfo.SoilType = "stone";
            tileInfo.数量 = 3;
            return tileInfo;  
        }
        
    }
}
