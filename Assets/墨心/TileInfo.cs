namespace 墨心
{
    public class TileInfo
    {
        // 地块的土质类型字段
        public string SoilType { get; private set; }

       
        public TileInfo()
        {
            SoilType = "desert";  // 默认土质类型为沙漠
        }
    }
}
