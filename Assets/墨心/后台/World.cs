using UnityEngine;
using static ī��.GameManager;
namespace ī��{
    public class World{

        // �������
        public int Width { get { return 10; } }
        // �߶�����
        public int Height { get { return 10; } }
        // �� Player ��Ϊ World ��ĳ�Ա
        public Player Player { get; set; }
    }
    public class Player{
        public Vector2 Position { get; set; }
    }
    public static partial class GameManager{
        public static TileInfo[,] Grid { get; set; }
        // ��̬��������ʼ���ؿ����񲢷��س�ʼ����� World ����
        public static World InitializeWorld(){
            World world = new World();  // �����µ� World ʵ��
            Grid = new TileInfo[world.Width, world.Height];  // ����ָ����С��������
            for (int x = 0; x < world.Width; x++){
                for (int y = 0; y < world.Height; y++){
                    Grid[x, y] = ����ɳĮ�ؿ�();  // ÿ���ؿ�Ĭ�ϳ�ʼ��ΪɳĮ�ؿ�
                }
            }
            world.Player = CreatePlayer();
            return world;  // ���س�ʼ����� World ����
        }
        // ��̬�������湹�캯���������� Player ʵ��
        public static Player CreatePlayer(){
            Player player = new Player();  // �����µ� Player ʵ��
            player.Position = new Vector2(0, 0);  // ��ʼ��λ��

            return player;  // ���� Player ʵ��
        }
    }
}
