using UnityEngine;
using System.Collections.Generic;

namespace ī��main // ��������ռ�
{
    public class MapGenerator : MonoBehaviour
    {
        private int n = 10; // �������
        private int stonesPerMine = 10; // ÿ������е�ʯͷ����

        // ���ɵ�ͼ����
        public void GenerateMap(int width, int height, float tileSize)
        {
            // ����һ���б��Դ洢���ɵĵؿ�
            List<GameObject> tiles = new List<GameObject>();

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

                    // �ж��Ƿ��Ǳ�Ե�ؿ飬����ǣ������滻Ϊ��ǽͼƬ
                    if (IsEdgeTile(x, y, width, height))
                    {
                        ReplaceTileSprite(tile, "��ǽ"); // ����Ե�ؿ��滻Ϊ��ǽͼƬ
                    }
                    else
                    {
                        // ������Դ�ļ����еĵؿ�ͼƬ
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
                    }

                    // �����ײ���
                    BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
                    collider.size = new Vector2(tileSize, tileSize); // ������ײ���Ĵ�СΪ�ؿ��С
                    collider.offset = new Vector2(0, 0); // ������ײ����ƫ��

                    // ��ӵ��������
                    TileClickHandler clickHandler = tile.AddComponent<TileClickHandler>();

                    // ���ؿ���ӵ��б���
                    tiles.Add(tile);

                    Debug.Log("���ɵؿ飺" + tile.name + " ���꣺" + tile.transform.position);
                }
            }

            // ���ɿ��
            for (int i = 0; i < n; i++)
            {
                GenerateMine(tiles);
            }
        }

        // �ж��Ƿ��Ǳ�Ե�ؿ�ķ���
        private bool IsEdgeTile(int x, int y, int width, int height)
        {
            return (x == 0 || x == width - 1 || y == 0 || y == height - 1);
        }

        // ���ɿ�ѵķ���
        private void GenerateMine(List<GameObject> tiles)
        {
            if (tiles.Count == 0) return;

            // ���ѡ��һ���Ǳ�Ե�ĵؿ���Ϊ��ѵĵ�һ����
            GameObject initialTile = null;
            while (initialTile == null)
            {
                int randomIndex = Random.Range(0, tiles.Count);
                GameObject candidateTile = tiles[randomIndex];

                if (candidateTile.name != "��ǽ" && candidateTile.name != "stone") // ȷ��ѡ�еĵؿ鲻�Ǳ�ǽ��ʯͷ
                {
                    initialTile = candidateTile;
                }
            }

            ReplaceTileSprite(initialTile, "stone"); // ȷ��stone.png��Assets/Resources��

            // ʹ�ö��н��й����������������Ⱦ����Χ�ĵ�
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(new Vector2Int((int)initialTile.transform.position.x + 5, (int)initialTile.transform.position.y + 5));

            // ��ӵ�ʯͷ����������
            int stonesAdded = 1;

            while (queue.Count > 0 && stonesAdded < stonesPerMine)
            {
                Vector2Int currentPos = queue.Dequeue();
                List<Vector2Int> neighbors = GetNeighbors(currentPos);

                foreach (Vector2Int neighbor in neighbors)
                {
                    GameObject neighborTile = tiles.Find(t =>
                        (int)t.transform.position.x + 5 == neighbor.x &&
                        (int)t.transform.position.y + 5 == neighbor.y);

                    if (neighborTile != null && neighborTile.name != "stone" && neighborTile.name != "��ǽ") // ȷ�������滻�Ѿ���ʯͷ���ǽ�ĵؿ�
                    {
                        ReplaceTileSprite(neighborTile, "stone");
                        queue.Enqueue(neighbor); // ����Χ�ĵ�������
                        stonesAdded++; // ���Ӽ�����
                    }

                    // �������ӵ�ʯͷ�����ﵽ���ޣ������ѭ��
                    if (stonesAdded >= stonesPerMine)
                    {
                        break;
                    }
                }
            }
        }

        // ��ȡ��Χ�ĵ�
        private List<Vector2Int> GetNeighbors(Vector2Int position)
        {
            List<Vector2Int> neighbors = new List<Vector2Int>
        {
            new Vector2Int(position.x + 1, position.y),
            new Vector2Int(position.x - 1, position.y),
            new Vector2Int(position.x, position.y + 1),
            new Vector2Int(position.x, position.y - 1)
        };
            return neighbors;
        }

        // �滻�ؿ�ͼƬ�ķ���
        public void ReplaceTileSprite(GameObject tile, string newSpriteName)
        {
            if (tile == null)
            {
                Debug.LogError("�ؿ������Ϊ�ա�");
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
