using System.Diagnostics;
using UnityEngine;

namespace ī��{
    // �����ࣺ������ں���
    public static partial class GameManager{
        public static World WorldInstance { get; private set; }  // �洢��̨�����ʵ��
        public static FrontendWorld FrontendInstance { get; private set; }  // �洢ǰ̨�����ʵ��

        // ���������������
        public static void Mainstart(){
            // ������̨����
            WorldInstance = new World(10, 10);

            // ����ǰ̨����
            FrontendInstance = new FrontendWorld();

            // �������̴�������
            CreateWorld();
        }
    }
    //���̺���
    public static partial class GameManager{
        public static void CreateWorld(){
            int gridWidth = WorldInstance.Grid.GetLength(0);  // ��ȡ��ͼ�Ŀ�ȣ�������
            int gridHeight = WorldInstance.Grid.GetLength(1);  // ��ȡ��ͼ�ĸ߶ȣ�������

            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    FrontendInstance.CreateTileUI(x, y, WorldInstance.Grid[x, y]);  // ���� TileInfo
                }
            }
        }
    }
}
