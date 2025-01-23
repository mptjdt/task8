using UnityEngine;
using System.Collections.Generic;

namespace 墨心main // 添加命名空间
{
    public class MapGenerator : MonoBehaviour
    {
        private int n = 10; // 矿堆数量
        private int stonesPerMine = 10; // 每个矿堆中的石头数量

        // 生成地图方法
        public void GenerateMap(int width, int height, float tileSize)
        {
            // 创建一个列表以存储生成的地块
            List<GameObject> tiles = new List<GameObject>();

            // 遍历地图的每个地块
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // 创建地图地块
                    GameObject tile = new GameObject("Tile_" + x + "_" + y);
                    tile.transform.position = new Vector3(x * tileSize - 5, y * tileSize - 5, 0); // 设置地块位置

                    // 添加可视化效果 (例如使用SpriteRenderer)
                    SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();

                    // 判断是否是边缘地块，如果是，将其替换为边墙图片
                    if (IsEdgeTile(x, y, width, height))
                    {
                        ReplaceTileSprite(tile, "边墙"); // 将边缘地块替换为边墙图片
                    }
                    else
                    {
                        // 加载资源文件夹中的地块图片
                        Sprite tileSprite = Resources.Load<Sprite>("desert"); // 确保desert.png在Assets/Resources中
                        if (tileSprite != null)
                        {
                            renderer.sprite = tileSprite;
                            renderer.sortingOrder = 0; // 地块的排序低于角色
                        }
                        else
                        {
                            Debug.LogError("未能加载地块图片，检查文件名和路径。");
                        }
                    }

                    // 添加碰撞组件
                    BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
                    collider.size = new Vector2(tileSize, tileSize); // 设置碰撞器的大小为地块大小
                    collider.offset = new Vector2(0, 0); // 设置碰撞器的偏移

                    // 添加点击处理器
                    TileClickHandler clickHandler = tile.AddComponent<TileClickHandler>();

                    // 将地块添加到列表中
                    tiles.Add(tile);

                    Debug.Log("生成地块：" + tile.name + " 坐标：" + tile.transform.position);
                }
            }

            // 生成矿堆
            for (int i = 0; i < n; i++)
            {
                GenerateMine(tiles);
            }
        }

        // 判断是否是边缘地块的方法
        private bool IsEdgeTile(int x, int y, int width, int height)
        {
            return (x == 0 || x == width - 1 || y == 0 || y == height - 1);
        }

        // 生成矿堆的方法
        private void GenerateMine(List<GameObject> tiles)
        {
            if (tiles.Count == 0) return;

            // 随机选择一个非边缘的地块作为矿堆的第一个点
            GameObject initialTile = null;
            while (initialTile == null)
            {
                int randomIndex = Random.Range(0, tiles.Count);
                GameObject candidateTile = tiles[randomIndex];

                if (candidateTile.name != "边墙" && candidateTile.name != "stone") // 确保选中的地块不是边墙或石头
                {
                    initialTile = candidateTile;
                }
            }

            ReplaceTileSprite(initialTile, "stone"); // 确保stone.png在Assets/Resources中

            // 使用队列进行广度优先搜索来“传染”周围的点
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(new Vector2Int((int)initialTile.transform.position.x + 5, (int)initialTile.transform.position.y + 5));

            // 添加的石头数量计数器
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

                    if (neighborTile != null && neighborTile.name != "stone" && neighborTile.name != "边墙") // 确保不会替换已经是石头或边墙的地块
                    {
                        ReplaceTileSprite(neighborTile, "stone");
                        queue.Enqueue(neighbor); // 将周围的点加入队列
                        stonesAdded++; // 增加计数器
                    }

                    // 如果已添加的石头数量达到上限，则结束循环
                    if (stonesAdded >= stonesPerMine)
                    {
                        break;
                    }
                }
            }
        }

        // 获取周围的点
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

        // 替换地块图片的方法
        public void ReplaceTileSprite(GameObject tile, string newSpriteName)
        {
            if (tile == null)
            {
                Debug.LogError("地块对象不能为空。");
                return;
            }

            SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
            if (renderer == null)
            {
                Debug.LogError("地块没有SpriteRenderer组件。");
                return;
            }

            // 加载新的地块图片
            Sprite newSprite = Resources.Load<Sprite>(newSpriteName); // 确保新图片在Assets/Resources中
            if (newSprite != null)
            {
                renderer.sprite = newSprite;  // 替换图片
                tile.name = newSpriteName;    // 将地块的名字修改为新的名字 (例如 "stone")
                Debug.Log("已替换地块：" + tile.name + " 的图片为：" + newSpriteName);
            }
            else
            {
                Debug.LogError("未能加载新的地块图片，检查文件名和路径。");
            }
        }
    }
}
