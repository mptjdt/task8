using UnityEngine;
//�����ļ�
namespace ī��{
    //���̺���
    public static partial class GameManager{
        public static void CreateWorld(int m,int n){
            InitializeWorld(WorldInstance, m, n);
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