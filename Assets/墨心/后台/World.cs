using static 墨心.GameManager;
namespace 墨心{
    public class World{
        
        // 宽度属性
        public int Width = 10;
        // 高度属性
        public int Height = 10;
    }
    public static partial class GameManager{
        public static TileInfo[,] Grid { get; set; }
        // 静态方法，初始化地块网格并返回初始化后的 World 对象
        public static World InitializeWorld(){
            World world = new World();  // 创建新的 World 实例
            Grid = new TileInfo[world.Width, world.Height];  // 根据指定大小创建网格
            for (int x = 0; x <world.Width ; x++){
                for (int y = 0; y < world.Height; y++){
                    Grid[x, y] = 创建沙漠地块();  // 每个地块默认初始化为沙漠地块
                }
            }
            return world;  // 返回初始化后的 World 对象
        }
    }
}