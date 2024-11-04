namespace 墨心{
    public class World{
        // 地块网格，大小由构造函数设置
        public TileInfo[,] Grid { get; private set; }
        // 行数和列数
        private int gridWidth;
        private int gridHeight;
        // 构造函数，接收行数和列数作为参数
        public World(int width, int height){
            gridWidth = width;  // 设置行数
            gridHeight = height;  // 设置列数
            Grid = new TileInfo[gridWidth, gridHeight];  // 根据指定大小创建网格
            GenerateTiles();  // 生成地块
        }
        // 生成地块的方法
        private void GenerateTiles(){
            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    Grid[x, y] = new TileInfo();  // 每个地块默认土质为沙漠
                }
            }
        }
    }
}