using UnityEngine;
using static 墨心.GameManager;
namespace 墨心{
    public class World{
  
        public TileInfo[,] Grid { get; set; }
        // 宽度属性
        public int Width { get { return Grid.GetLength(0); } }
        // 高度属性
        public int Height { get { return Grid.GetLength(1); } }
        // 将 Player 作为 World 类的成员
        public Player Player { get; set; }

    }
    public class Player{
        public Vector2 Position { get; set; }
    }
    public static partial class GameManager{
        // 静态方法，初始化地块网格并返回初始化后的 World 对象
        public static World InitializeWorld(int width,int height){
            World world = new World();  // 创建新的 World 实例
            world.Grid = new TileInfo[width,height];  // 根据指定大小创建网格
            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    world.Grid[x, y] = 创建沙漠地块();  // 每个地块默认初始化为沙漠地块
                }
            }
            return world;  // 返回初始化后的 World 对象
        }
        // 静态方法代替构造函数，并返回 Player 实例
        public static Player InitializePlayer(){
            Player player = new Player();  // 创建新的 Player 实例
            player.Position = new Vector2(0, 0);  // 初始化位置

            return player;  // 返回 Player 实例
        }
    }
}
