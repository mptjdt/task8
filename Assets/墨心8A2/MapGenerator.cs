using UnityEngine;
using System.Collections.Generic;

namespace ī��8A2
{
    public class MapGenerator : MonoBehaviour
    {
        // ����һ����ά�б����ڴ洢ÿ���ؿ����Ϣ
        public List<List<List<TileInfo>>> tilesInfo = new List<List<List<TileInfo>>>();

        [Range(0, 1)]
        public float stoneSpawnChance = 0.5f; // �������ʯͷ�ĸ��ʣ�0��1֮�䣩
        [Range(0, 1)]
        public float inventorystoneSpawnChance = 0.5f; // �������Inventorystone�ĸ��ʣ�0��1֮�䣩

        private int tileIdCounter = 0; // ID������

        // ���ɵ�ͼ����
        public void GenerateMap(int width, int height, float tileSize)
        {
            // ��ʼ����ά�б�
            for (int x = 0; x < width; x++)
            {
                tilesInfo.Add(new List<List<TileInfo>>());
                for (int y = 0; y < height; y++)
                {
                    tilesInfo[x].Add(new List<TileInfo>());
                    // ��ʼ��z���TileInfo�б�
                    for (int z = 0; z <= 5; z++) // ȷ��z=0��z=5���г�ʼ��
                    {
                        tilesInfo[x][y].Add(null); // ��ʼ��z���TileInfoΪnull
                    }
                }
            }

            // ������ͼ��ÿ���ؿ�
            for (int z = 1; z <= 5; z += 2) // ��1��5��ÿ������2
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        CreateTile(x, y, z, tileSize); // ���ô����ؿ�ķ���
                    }
                }
            }

            // �������0��ؿ�
            for (int i = 0; i < 5; i++) // �������5���ؿ�
            {
                int randomX = Random.Range(0, width);
                int randomY = Random.Range(0, height);
                CreateTile(randomX, randomY, 0, tileSize); // ����0��ĵؿ�
            }

            // �������2���Inventorystone�ؿ�
            for (int i = 0; i < 5; i++) // �������5��Inventorystone
            {
                int randomX = Random.Range(0, width);
                int randomY = Random.Range(0, height);
                CreateTile(randomX, randomY, 2, tileSize); // ����2���Inventorystone�ؿ�
            }
        }

        // �����ؿ�ķ���
        private void CreateTile(int x, int y, int z, float tileSize)
        {
            // ������ͼ�ؿ�
            GameObject tile = new GameObject("Tile_" + x + "_" + y + "_Layer_" + z);
            tile.transform.position = new Vector3(x * tileSize - 5, y * tileSize - 5, z); // ���õؿ�λ��

            // ��ӿ��ӻ�Ч�� (����ʹ��SpriteRenderer)
            SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
            Sprite tileSprite = null;

            // ����zֵѡ��ͬ�ĵؿ�����
            if (z == 1)
            {
                tileSprite = Resources.Load<Sprite>("desert"); // ɳĮ
            }
            else if (z == 3)
            {
                tileSprite = Resources.Load<Sprite>("��ǽ"); // ��ǽ
            }
            else if (z == 5)
            {
                tileSprite = Resources.Load<Sprite>("���"); // ���
            }
            else if (z == 0 || z == 2) // �������stone��Inventorystone
            {
                float randomValue = Random.value; // ����һ��0��1֮��������
                if (randomValue < stoneSpawnChance) // ����stoneSpawnChance����stone
                {
                    tileSprite = Resources.Load<Sprite>("stone"); // ʯͷ
                }
                else if (randomValue < stoneSpawnChance + inventorystoneSpawnChance) // ����inventorystoneSpawnChance����Inventorystone
                {
                    tileSprite = Resources.Load<Sprite>("Inventorystone"); // Inventorystone
                }
            }

            if (tileSprite != null)
            {
                renderer.sprite = tileSprite;
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
            clickHandler.mapGenerator = this; // �� MapGenerator ���ô��ݸ����������

            // ����ΨһID������TileInfo
            int tileID = tileIdCounter++; // ����ΨһID
            TileInfo.LayerType layerType = (TileInfo.LayerType)(z);
            TileInfo newTileInfo = new TileInfo(tile, layerType, tileID);

            // ��TileInfo��ӵ���ά�б���
            tilesInfo[x][y][z] = newTileInfo; // ��TileInfo��ӵ���ά�б�

            Debug.Log("���ɵؿ飺" + tile.name + " ���꣺" + tile.transform.position + " ID: " + tileID);
        }
    }
}
