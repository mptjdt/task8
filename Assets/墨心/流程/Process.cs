using UnityEngine;
//�����ļ�
namespace ī��{
    //���̺���
    public static partial class GameManager{
        public static void CreateWorld(){
            int gridWidth = WorldInstance.Width;  // ��ȡ��ͼ�Ŀ�ȣ�������
            int gridHeight = WorldInstance.Height;  // ��ȡ��ͼ�ĸ߶ȣ�������
            for (int x = 0; x < gridWidth; x++){
                for (int y = 0; y < gridHeight; y++){
                    FrontendInstance.CreateTileUI(x, y, Grid[x, y]);  // ���� TileInfo
                }
            }
        }
    }
}