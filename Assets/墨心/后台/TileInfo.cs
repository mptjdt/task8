using 墨心;

namespace 墨心{
    public class TileInfo{
        // 地块的土质类型字段
        public string SoilType { get; set; }   
    }
    // 静态方法，用于初始化 TileInfo 对象
    public static partial class GameManager{
        public static TileInfo 创建沙漠地块(){
            TileInfo tileInfo = new TileInfo();
            tileInfo.SoilType = "desert";  // 默认土质类型为沙漠
            return tileInfo;
        }
    }
}