using UnityEngine;

namespace ī��{
    public static class Utils{
        // ���ؾ���ľ�̬����
        public static Sprite LoadSprite(string path){
            try{
                return Resources.Load<Sprite>(path);
            }
            catch (System.Exception e){
                HandleError($"Failed to load sprite at {path}: {e.Message}");  // ������ؾ���ʱ�Ĵ���
                return null;
            }
        }

        // ��������
        public static void HandleError(string message){
            Debug.LogError(message);  // ��¼������Ϣ
        }
    }

    public static class GameManager{
        public static World WorldInstance { get; private set; }  // �洢��̨�����ʵ��
        public static FrontendWorld FrontendInstance { get; private set; }  // �洢ǰ̨�����ʵ��

        // ���������������
        public static void Main(){
            // ������̨����
            WorldInstance = new World(10, 10);

            // ����ǰ̨����
            FrontendInstance = new FrontendWorld();

            // �������̴�������
            Process.CreateWorld(FrontendInstance, WorldInstance);
        }
    }

    public static class Process{
        public static void CreateWorld(FrontendWorld frontend, World world){
            int gridWidth = world.Grid.GetLength(0);  // ��ȡ��ͼ�Ŀ�ȣ�������
            int gridHeight = world.Grid.GetLength(1);  // ��ȡ��ͼ�ĸ߶ȣ�������

            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    frontend.CreateTileUI(x, y, world.Grid[x, y]);  // ���� TileInfo
                }
            }
        }
    }
}
