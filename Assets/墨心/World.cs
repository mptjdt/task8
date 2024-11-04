namespace ī��{
    public class World{
        // �ؿ����񣬴�С�ɹ��캯������
        public TileInfo[,] Grid { get; private set; }
        // ����������
        private int gridWidth;
        private int gridHeight;
        // ���캯��������������������Ϊ����
        public World(int width, int height){
            gridWidth = width;  // ��������
            gridHeight = height;  // ��������
            Grid = new TileInfo[gridWidth, gridHeight];  // ����ָ����С��������
            GenerateTiles();  // ���ɵؿ�
        }
        // ���ɵؿ�ķ���
        private void GenerateTiles(){
            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    Grid[x, y] = new TileInfo();  // ÿ���ؿ�Ĭ������ΪɳĮ
                }
            }
        }
    }
}