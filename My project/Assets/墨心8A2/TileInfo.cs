using UnityEngine;

namespace ī��8A2
{
    public class TileInfo : MonoBehaviour
    {
        // �ؿ�㼶����
        public enum LayerType
        {
            Stone,
            Desert = 1,  // ɳĮ��
            ��ǽ = 3,    // ��ǽ��
            ��� = 5      // ��ղ�
        }

        // ����
        public GameObject TileObject { get; private set; } // ��Ӧ����Ϸ����
        public LayerType Layer { get; private set; } // ������
        public int ID { get; private set; } // ID

        // ���캯��
        public TileInfo(GameObject tileObject, LayerType layer, int id)
        {
            TileObject = tileObject; // ��ֵ��Ϸ����
            Layer = layer; // ���ò㼶
            ID = id; // ����ID
        }
        


    }
}
