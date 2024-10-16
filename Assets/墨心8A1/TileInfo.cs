using UnityEngine;

namespace ī��8A1
{
    public class TileInfo
    {
        // ���� TileType ö��
        public enum TileType
        {
            Desert,
            Stone
        }

        public GameObject TileObject; // �ؿ��GameObject����
        public TileType Type; // �ؿ����ͣ�ʹ�� TileInfo �е�ö�٣�
        public int RemainingCount; // ʣ������

        public TileInfo(GameObject tileObject, TileType type, int remainingCount)
        {
            TileObject = tileObject; // ����GameObject
            Type = type; // ����ؿ�����
            RemainingCount = remainingCount;
        }
    }
}
