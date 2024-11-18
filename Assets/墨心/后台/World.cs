using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using static 墨心.GameManager;
namespace 墨心{
    public class World{

        // 每个地块存储一个 List<TileInfo>，即每个地块有多个 TileInfo
        public List<TileInfo>[,] Grid { get; set; }
        // 宽度属性
        public int Width { get { return Grid.GetLength(0); } }
        // 高度属性
        public int Height { get { return Grid.GetLength(1); } }
        // 将 Player 作为 World 类的成员
        public Player Player { get; set; }

    }
    public class Player  {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; } // 当前旋转角度（以度为单位）
        public float moveSpeed {get;set;}//移动速度
        public float rotationSpeed { get; set; }//旋转速度
    }
    public static partial class GameManager{
        // 静态方法，初始化地块网格并返回初始化后的 World 对象
        public static World InitializeWorld(int width, int height,int 矿石数量){
            World world = new World();  // 创建新的 World 实例
            world.Grid = new List<TileInfo>[width, height];  // 根据指定大小创建网格
            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    world.Grid[x, y] = new List<TileInfo>();  // 每个地块初始化为空的 List<TileInfo>
                    创建沙漠地块(world.Grid[x, y]);
                }
            }
            随机生成矿石(world,矿石数量);
            return world;  // 返回初始化后的 World 对象
        }
        // 静态方法代替构造函数，并返回 Player 实例
        public static Player InitializePlayer(float movespeed, float rotationspeed){
            Player player = new Player();  // 创建新的 Player 实例
            player.Position = new Vector2(0, 0);  // 初始化位置
            player.Rotation = 0;//初始固定为0
            player.moveSpeed = movespeed;
            player.rotationSpeed = rotationspeed;
            return player;  // 返回 Player 实例
        }
        public static void 角色位置改变(World world, Vector2 positionChange, float targetRotation){
            // 更新玩家位置
            world.Player.Position += positionChange;
            // 更新玩家旋转角度
            world.Player.Rotation = Mathf.LerpAngle(world.Player.Rotation, targetRotation, Time.deltaTime * world.Player.rotationSpeed);
        }
        public static List<TileInfo> 获取当前地块(Vector2 screenPosition, World world){
            // 使用摄像头将屏幕坐标转换为世界坐标
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);

            // 假设每个地块的大小是 1 单位（可以根据需要调整）
            int gridX = Mathf.FloorToInt(worldPos.x);  // 取整转换为网格坐标
            int gridY = Mathf.FloorToInt(worldPos.y);  // 取整转换为网格坐标

            // 将世界坐标转换为网格坐标
            gridX = Mathf.Clamp(gridX, 0, world.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, world.Height - 1);

            // 根据网格坐标获取当前地块并返回
            return world.Grid[gridX, gridY];
        }
        // 随机生成矿石
        public static void 随机生成矿石(World world, int times){
            if (times <= 0) return; // 如果需要生成的矿石数量为0或负数，直接返回

            // 获取随机的沙漠地块作为起始点
            Vector2Int? initialPosition = GetRandomDesertPosition(world);
            if (initialPosition == null) return; // 如果没有沙漠地块，退出

            HashSet<Vector2Int> visited = new HashSet<Vector2Int> { initialPosition.Value };
            world.Grid[initialPosition.Value.x, initialPosition.Value.y] = GameManager.创建石头地块(world.Grid[initialPosition.Value.x, initialPosition.Value.y]);

            int generatedCount = 1; // 已生成矿石的数量，初始为1

            // 逐步扩展生成矿石
            while (generatedCount < times){
                Vector2Int? currentOre = GetRandomOrePosition(visited);
                if (currentOre == null) break; // 没有可扩展位置，停止生成

                List<Vector2Int> neighbors = GetNeighbors(currentOre.Value.x, currentOre.Value.y);

                foreach (var neighbor in neighbors){
                    if (IsValidPosition(neighbor.x, neighbor.y, world) &&
                        world.Grid[neighbor.x, neighbor.y][0].SoilType == "desert" &&
                        !visited.Contains(neighbor)){
                        world.Grid[neighbor.x, neighbor.y] = GameManager.创建石头地块(world.Grid[neighbor.x, neighbor.y]);
                        visited.Add(neighbor);
                        generatedCount++; // 增加生成计数
                        break; // 成功生成一个矿石，跳出循环
                    }
                }
            }
        }

        // 随机选择一个已生成矿石的坐标
        private static Vector2Int? GetRandomOrePosition(HashSet<Vector2Int> visited){
            if (visited.Count == 0) return null;
            var enumerator = visited.GetEnumerator();
            int index = UnityEngine.Random.Range(0, visited.Count);
            for (int i = 0; i <= index; i++) enumerator.MoveNext();
            return enumerator.Current;
        }

        // 随机获取一个沙漠地块的位置
        private static Vector2Int? GetRandomDesertPosition(World world){
            List<Vector2Int> desertPositions = new List<Vector2Int>();

            for (int x = 0; x < world.Width; x++){
                for (int y = 0; y < world.Height; y++){
                    if (world.Grid[x, y][0].SoilType == "desert"){
                        desertPositions.Add(new Vector2Int(x, y));
                    }
                }
            }

            if (desertPositions.Count == 0) return null; // 如果没有沙漠地块，返回空
            return desertPositions[UnityEngine.Random.Range(0, desertPositions.Count)];
        }

        // 获取相邻的四个方向（上、下、左、右）坐标
        private static List<Vector2Int> GetNeighbors(int x, int y){
            return new List<Vector2Int>{
                new Vector2Int(x - 1, y),  // 左
                new Vector2Int(x + 1, y),  // 右
                new Vector2Int(x, y - 1),  // 下
                new Vector2Int(x, y + 1)   // 上
            };
        }

        // 检查位置是否有效（是否在地图范围内）
        private static bool IsValidPosition(int x, int y, World world){
            return x >= 0 && x < world.Width && y >= 0 && y < world.Height;
        }
    }
}
