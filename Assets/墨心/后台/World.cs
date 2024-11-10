using static ī��.GameManager;
namespace ī��{
    public class World{
        
        // �������
        public int Width = 10;
        // �߶�����
        public int Height = 10;
    }
    public static partial class GameManager{
        public static TileInfo[,] Grid { get; set; }
        // ��̬��������ʼ���ؿ����񲢷��س�ʼ����� World ����
        public static World InitializeWorld(){
            World world = new World();  // �����µ� World ʵ��
            Grid = new TileInfo[world.Width, world.Height];  // ����ָ����С��������
            for (int x = 0; x <world.Width ; x++){
                for (int y = 0; y < world.Height; y++){
                    Grid[x, y] = ����ɳĮ�ؿ�();  // ÿ���ؿ�Ĭ�ϳ�ʼ��ΪɳĮ�ؿ�
                }
            }
            return world;  // ���س�ʼ����� World ����
        }
    }
}