using UnityEngine;

namespace ī��8A2
{
    public class TileClickHandler : MonoBehaviour
    {
        public MapGenerator mapGenerator; // ���� MapGenerator ʵ��

        // �����¼�ί��
        public delegate void TileClicked(string tileName, int layerType);
        public static event TileClicked OnTileClicked; // �����¼�
       

        



        // �������Ƿ��ڵ�ǰ�ؿ���
        public bool IsMouseOverTile(Vector3 mousePosition)
        {
            Vector3 tilePosition = transform.position;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // ��ȡ�ؿ�ı߽�
            Vector2 tileSize = spriteRenderer.bounds.size;

            // ������λ���Ƿ��ڵؿ鷶Χ�ڣ����� z ����ж�
            return mousePosition.x >= tilePosition.x - tileSize.x / 2 &&
                   mousePosition.x <= tilePosition.x + tileSize.x / 2 &&
                   mousePosition.y >= tilePosition.y - tileSize.y / 2 &&
                   mousePosition.y <= tilePosition.y + tileSize.y / 2 &&
                   Mathf.Abs(mousePosition.z - tilePosition.z) < 0.1f; // z���ƥ��
        }


        // ����ά�б��л�ȡ TileInfo
        public TileInfo GetTileInfo(GameObject tileObject)
        {
            for (int x = 0; x < mapGenerator.tilesInfo.Count; x++)
            {
                for (int y = 0; y < mapGenerator.tilesInfo[x].Count; y++)
                {
                    for (int z = 0; z < mapGenerator.tilesInfo[x][y].Count; z++)
                    {
                        if (mapGenerator.tilesInfo[x][y][z]?.TileObject == tileObject)
                        {
                            return mapGenerator.tilesInfo[x][y][z]; // �ҵ���Ӧ�� TileInfo ������
                        }
                    }
                }
            }
            return null; // ���δ�ҵ������� null
        }

        // �������ĵؿ�
        public void HandleTileClick(TileInfo tileInfo)
        {
            // ��ȡ�ؿ����ƺͲ㼶����
            string tileName = tileInfo.TileObject.name;
            string imageName = tileInfo.TileObject.GetComponent<SpriteRenderer>().sprite.name;
            int layerType = (int)tileInfo.Layer;

            // ���ݲ㼶���ʹ���ͬ�ĵؿ�
            switch (tileInfo.Layer)
            {
                case TileInfo.LayerType.Desert:
                    Debug.Log("�Ҽ������ɳĮ�ؿ�");
                    break;

                case TileInfo.LayerType.��ǽ:
                    Debug.Log("�Ҽ�����˱�ǽ�ؿ�");
                    break;

                case TileInfo.LayerType.���:
                    Debug.Log("�Ҽ��������յؿ�");
                    break;

                default:
                    break;
            }

            // �����¼�������ͼƬ���ƺͲ㼶����
            OnTileClicked?.Invoke(imageName, layerType);
        }
    }
}

