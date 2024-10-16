using UnityEngine;
using System; // ��Ӵ������ռ���ʹ�� Action

namespace ī��8A1
{
    public class TileClickHandler : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer; // ���ڻ�ȡ�ؿ�� SpriteRenderer
        private TileInfo tileInfo; // �洢��Ӧ�� TileInfo ����
        private MapGenerator mapGenerator; // ���� MapGenerator ʵ��

        // �����¼������ݵؿ����ͺ�ʣ������
        public static event Action<TileInfo.TileType, int> OnTileClicked;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>(); // ��ȡ��ǰ GameObject �� SpriteRenderer

            // ��ȡ MapGenerator ʵ�������� TileInfo �б�
            mapGenerator = FindObjectOfType<MapGenerator>(); // ��ȡ�����е� MapGenerator ʵ��
            if (mapGenerator == null)
            {
                Debug.LogError("û���ҵ� MapGenerator ʵ������ȷ���������� MapGenerator �����");
                return; // ���δ�ҵ���ִֹͣ�� Start ����
            }

            // ���Ҷ�Ӧ�� TileInfo
            foreach (var info in mapGenerator.tileInfo)
            {
                if (info.TileObject == gameObject) // ��鵱ǰ GameObject �Ƿ��� tileInfo �еĵؿ�
                {
                    tileInfo = info; // �洢�ҵ��� TileInfo

                    // ���Խ����ؿ�����
                    if (Enum.TryParse(typeof(TileInfo.TileType), spriteRenderer.sprite.name, true, out var result))
                    {
                        tileInfo.Type = (TileInfo.TileType)result; // �ɹ����������� TileInfo ������
                    }
                    else
                    {
                        Debug.LogError($"�޷������ؿ����ͣ�{spriteRenderer.sprite.name}������������");
                    }
                    break; // �ҵ���Ӧ�ؿ������˳�ѭ��
                }
            }

            if (tileInfo == null)
            {
                Debug.LogError("δ���ҵ���Ӧ�� TileInfo ����");
            }
        }

        private void OnMouseDown() // ��������ö���ʱ����
        {
            if (tileInfo == null) return; // ���δ�ҵ� TileInfo��ֱ�ӷ���

            if (tileInfo.Type == TileInfo.TileType.Stone) // ��鵱ǰ�ؿ�����
            {
                tileInfo.RemainingCount--; // ����ʣ������

                // �����¼������ݵؿ����ͺ�ʣ������
                OnTileClicked?.Invoke(TileInfo.TileType.Stone, tileInfo.RemainingCount);

                // ���ʣ�������ﵽ����Ĵ��������滻�ؿ�
                if (tileInfo.RemainingCount <= 0)
                {
                    ReplaceTileSprite("desert"); // ���ؿ��滻ΪɳĮ
                    tileInfo.RemainingCount = -1; // ��������Ϊ -1
                    tileInfo.Type = TileInfo.TileType.Desert; // ���µؿ�����Ϊ Desert
                }
            }
            else if (tileInfo.Type == TileInfo.TileType.Desert) // �����ɳĮ����
            {
                // �����¼������ݵؿ����ͺ͵��������ɳĮ���͵�������Ӵ������̶����� -1��
                OnTileClicked?.Invoke(TileInfo.TileType.Desert, -1);
            }
        }

        private void ReplaceTileSprite(string newSpriteName)
        {
            // �����µĵؿ�ͼƬ
            Sprite newSprite = Resources.Load<Sprite>(newSpriteName); // ȷ����ͼƬ�� Assets/Resources ��
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite; // �滻ͼƬ
                // ���� TileInfo ������
                if (Enum.TryParse(typeof(TileInfo.TileType), newSpriteName, true, out var result))
                {
                    tileInfo.Type = (TileInfo.TileType)result; // ���� TileInfo ������
                }

                Debug.Log("���滻�ؿ飺" + tileInfo.TileObject.name + " ��ͼƬΪ��" + newSpriteName); // ����滻��Ϣ
            }
            else
            {
                Debug.LogError("δ�ܼ����µĵؿ�ͼƬ������ļ�����·����");
            }
        }
    }
}
