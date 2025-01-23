using UnityEngine;
using System.Collections.Generic;

namespace 墨心8A2
{
    public class MapGenerator : MonoBehaviour
    {
        // 创建一个三维列表用于存储每个地块的信息
        public List<List<List<TileInfo>>> tilesInfo = new List<List<List<TileInfo>>>();

        [Range(0, 1)]
        public float stoneSpawnChance = 0.5f; // 随机生成石头的概率（0到1之间）
        [Range(0, 1)]
        public float inventorystoneSpawnChance = 0.5f; // 随机生成Inventorystone的概率（0到1之间）

        private int tileIdCounter = 0; // ID计数器

        // 生成地图方法
        public void GenerateMap(int width, int height, float tileSize)
        {
            // 初始化三维列表
            for (int x = 0; x < width; x++)
            {
                tilesInfo.Add(new List<List<TileInfo>>());
                for (int y = 0; y < height; y++)
                {
                    tilesInfo[x].Add(new List<TileInfo>());
                    // 初始化z轴的TileInfo列表
                    for (int z = 0; z <= 5; z++) // 确保z=0到z=5都有初始化
                    {
                        tilesInfo[x][y].Add(null); // 初始化z轴的TileInfo为null
                    }
                }
            }

            // 遍历地图的每个地块
            for (int z = 1; z <= 5; z += 2) // 从1到5，每次增加2
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        CreateTile(x, y, z, tileSize); // 调用创建地块的方法
                    }
                }
            }

            // 随机生成0层地块
            for (int i = 0; i < 5; i++) // 随机生成5个地块
            {
                int randomX = Random.Range(0, width);
                int randomY = Random.Range(0, height);
                CreateTile(randomX, randomY, 0, tileSize); // 创建0层的地块
            }

            // 随机生成2层的Inventorystone地块
            for (int i = 0; i < 5; i++) // 随机生成5个Inventorystone
            {
                int randomX = Random.Range(0, width);
                int randomY = Random.Range(0, height);
                CreateTile(randomX, randomY, 2, tileSize); // 创建2层的Inventorystone地块
            }
        }

        // 创建地块的方法
        private void CreateTile(int x, int y, int z, float tileSize)
        {
            // 创建地图地块
            GameObject tile = new GameObject("Tile_" + x + "_" + y + "_Layer_" + z);
            tile.transform.position = new Vector3(x * tileSize - 5, y * tileSize - 5, z); // 设置地块位置

            // 添加可视化效果 (例如使用SpriteRenderer)
            SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
            Sprite tileSprite = null;

            // 根据z值选择不同的地块类型
            if (z == 1)
            {
                tileSprite = Resources.Load<Sprite>("desert"); // 沙漠
            }
            else if (z == 3)
            {
                tileSprite = Resources.Load<Sprite>("边墙"); // 边墙
            }
            else if (z == 5)
            {
                tileSprite = Resources.Load<Sprite>("虚空"); // 虚空
            }
            else if (z == 0 || z == 2) // 随机生成stone或Inventorystone
            {
                float randomValue = Random.value; // 生成一个0到1之间的随机数
                if (randomValue < stoneSpawnChance) // 按照stoneSpawnChance生成stone
                {
                    tileSprite = Resources.Load<Sprite>("stone"); // 石头
                }
                else if (randomValue < stoneSpawnChance + inventorystoneSpawnChance) // 按照inventorystoneSpawnChance生成Inventorystone
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
                Debug.LogError("未能加载地块图片，检查文件名和路径。");
            }

            // 添加碰撞组件
            BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(tileSize, tileSize); // 设置碰撞器的大小为地块大小
            collider.offset = new Vector2(0, 0); // 设置碰撞器的偏移

            // 添加点击处理器
            TileClickHandler clickHandler = tile.AddComponent<TileClickHandler>();
            clickHandler.mapGenerator = this; // 将 MapGenerator 引用传递给点击处理器

            // 生成唯一ID并创建TileInfo
            int tileID = tileIdCounter++; // 生成唯一ID
            TileInfo.LayerType layerType = (TileInfo.LayerType)(z);
            TileInfo newTileInfo = new TileInfo(tile, layerType, tileID);

            // 将TileInfo添加到三维列表中
            tilesInfo[x][y][z] = newTileInfo; // 将TileInfo添加到三维列表

            Debug.Log("生成地块：" + tile.name + " 坐标：" + tile.transform.position + " ID: " + tileID);
        }
    }
}
