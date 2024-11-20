using System.Collections.Generic;

namespace 墨心 {
    public class TileInfo {
        public string SoilType { get; set; }// 地块的土质类型字段
        public int 数量 { get; set; }
    }
    public static partial class GameManager {
        public static List<TileInfo> 创建沙漠地块(List<TileInfo> tileList) {
            tileList.Add(new TileInfo { 
                SoilType = "desert",  // 土质类型为沙漠
                数量 = -1  // 设置默认数量
            });
            return tileList;  // 返回修改后的列表
        }
        public static List<TileInfo> 创建石头地块(List<TileInfo> tileList) {
            tileList.Add(new TileInfo{
                SoilType = "stone",  // 土质类型为石头
                数量 = 3  // 设置数量为 3
            });
            return tileList;  // 返回修改后的列表
        }
        public static List<TileInfo> 移除石头地块(List<TileInfo> tileList) {          
            tileList.RemoveAll(tile => tile.SoilType == "stone");// 使用 LINQ 的 RemoveAll 方法移除所有符合条件的地块
            return tileList;  // 返回修改后的列表
        }
    }
}
