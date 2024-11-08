namespace 墨心{
    public class World{
        // 地块网格
        public TileInfo[,] Grid { get; set; }
    }
    public static partial class GameManager{
        // 静态方法，初始化地块网格并生成地块
        public static void InitializeWorld(World world, int width, int height){
            world.Grid = new TileInfo[width, height];  // 根据指定大小创建网格
            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    world.Grid[x, y] = TileInfo.CreateTileInfo();  // 每个地块默认初始化
                }
            }
        }
    }
}
