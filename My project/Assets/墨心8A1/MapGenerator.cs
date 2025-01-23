using UnityEngine;
using System.Collections.Generic;

namespace ī��8A1
{
    public class MapGenerator : MonoBehaviour
    {
        private int n = 5; // ����n��Ĭ��ֵΪ5
        public List<TileInfo> tileInfo = new List<TileInfo>(); // ���ڴ洢ÿ���ؿ����Ϣ

        // ���ɵ�ͼ����
        public void GenerateMap(int width, int height, float tileSize)
        {
            // ������ͼ��ÿ���ؿ�
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // ������ͼ�ؿ�
                    GameObject tile = new GameObject("Tile_" + x + "_" + y);
                    tile.transform.position = new Vector3(x * tileSize - 5, y * tileSize - 5, 0); // ���õؿ�λ��

                    // ��ӿ��ӻ�Ч�� (����ʹ��SpriteRenderer)
                    SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
                    Sprite tileSprite = Resources.Load<Sprite>("desert"); // ȷ��desert.png��Assets/Resources��
                    if (tileSprite != null)
                    {
                        renderer.sprite = tileSprite;
                        renderer.sortingOrder = 0; // �ؿ��������ڽ�ɫ
                    }
                    else
                    {
                        Debug.LogError("δ�ܼ��صؿ�ͼƬ������ļ�����·����");
                    }

                    // �����ײ���
                    BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
                    collider.size = new Vector2(tileSize, tileSize); // ������ײ���Ĵ�СΪ�ؿ��С
                    collider.offset = new Vector2(0, 0); // ������ײ����ƫ��

                    // ��ӵ��������
                    TileClickHandler clickHandler = tile.AddComponent<TileClickHandler>();

                    // ��ӵؿ���Ϣ��tileInfo�б�
                    tileInfo.Add(new TileInfo(tile, TileInfo.TileType.Desert, -1)); // ÿ���ؿ��ʼ����ΪDesert

                    Debug.Log("���ɵؿ飺" + tile.name + " ���꣺" + tile.transform.position);
                }
            }

            // ���ѡ��n���ؿ�����滻Ϊʯͷ
            for (int i = 0; i < n; i++)
            {
                if (tileInfo.Count > 0)
                {
                    int randomIndex = Random.Range(0, tileInfo.Count); // �������
                    TileInfo tileToReplaceInfo = tileInfo[randomIndex];  // ��ȡ���ѡ��ĵؿ���Ϣ

                    // �滻ΪʯͷͼƬ�������ؿ����͸�Ϊ Stone
                    ReplaceTileSprite(tileToReplaceInfo.TileObject, "stone"); // ȷ��stone.png��Assets/Resources��

                    // ����tileInfo�е�ʣ������
                    tileToReplaceInfo.RemainingCount = 3; // ��������Ϊ3
                    tileToReplaceInfo.Type = TileInfo.TileType.Stone; // ���µؿ�����ΪStone

                    Debug.Log("�ѽ��ؿ��滻Ϊʯͷ��" + tileToReplaceInfo.TileObject.name);
                }
            }
        }

        // �滻�ؿ�ͼƬ�ķ���
        public void ReplaceTileSprite(GameObject tile, string newSpriteName)
        {
            if (tile == null)
            {
                Debug.LogError("�ؿ������Ϊnull��");
                return;
            }

            SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
            if (renderer == null)
            {
                Debug.LogError("�ؿ�û��SpriteRenderer�����");
                return;
            }

            // �����µĵؿ�ͼƬ
            Sprite newSprite = Resources.Load<Sprite>(newSpriteName); // ȷ����ͼƬ��Assets/Resources��
            if (newSprite != null)
            {
                renderer.sprite = newSprite;  // �滻ͼƬ
                tile.name = newSpriteName;    // ���ؿ�������޸�Ϊ�µ����� (���� "stone")
                Debug.Log("���滻�ؿ飺" + tile.name + " ��ͼƬΪ��" + newSpriteName);
            }
            else
            {
                Debug.LogError("δ�ܼ����µĵؿ�ͼƬ������ļ�����·����");
            }
        }
    }
}

