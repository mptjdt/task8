namespace ī��{
    public class World{
        // �ؿ�����
        public TileInfo[,] Grid { get; set; }
    }
    public static partial class GameManager{
        // ��̬��������ʼ���ؿ��������ɵؿ�
        public static void InitializeWorld(World world, int width, int height){
            world.Grid = new TileInfo[width, height];  // ����ָ����С��������
            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    world.Grid[x, y] = TileInfo.CreateTileInfo();  // ÿ���ؿ�Ĭ�ϳ�ʼ��
                }
            }
        }
    }
}
