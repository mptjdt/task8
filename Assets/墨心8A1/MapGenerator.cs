using UnityEngine;
using System.Collections.Generic;

namespace 墨心8A1
{
    public class MapGenerator : MonoBehaviour
    {
        private int n = 5; // 设置n的默认值为5
        public List<TileInfo> tileInfo = new List<TileInfo>(); // 用于存储每个地块的信息

        // 生成地图方法
        public void GenerateMap(int width, int height, float tileSize)
        {
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

                    // 添加碰撞组件
                    BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
                    collider.size = new Vector2(tileSize, tileSize); // 设置碰撞器的大小为地块大小
                    collider.offset = new Vector2(0, 0); // 设置碰撞器的偏移

                    // 添加点击处理器
                    TileClickHandler clickHandler = tile.AddComponent<TileClickHandler>();

                    // 添加地块信息到tileInfo列表
                    tileInfo.Add(new TileInfo(tile, TileInfo.TileType.Desert, -1)); // 每个地块初始类型为Desert

                    Debug.Log("生成地块：" + tile.name + " 坐标：" + tile.transform.position);
                }
            }

            // 随机选择n个地块进行替换为石头
            for (int i = 0; i < n; i++)
            {
                if (tileInfo.Count > 0)
                {
                    int randomIndex = Random.Range(0, tileInfo.Count); // 随机索引
                    TileInfo tileToReplaceInfo = tileInfo[randomIndex];  // 获取随机选择的地块信息

                    // 替换为石头图片，并将地块类型改为 Stone
                    ReplaceTileSprite(tileToReplaceInfo.TileObject, "stone"); // 确保stone.png在Assets/Resources中

                    // 更新tileInfo中的剩余数量
                    tileToReplaceInfo.RemainingCount = 3; // 更新数量为3
                    tileToReplaceInfo.Type = TileInfo.TileType.Stone; // 更新地块类型为Stone

                    Debug.Log("已将地块替换为石头：" + tileToReplaceInfo.TileObject.name);
                }
            }
        }

        // 替换地块图片的方法
        public void ReplaceTileSprite(GameObject tile, string newSpriteName)
        {
            if (tile == null)
            {
                Debug.LogError("地块对象不能为null。");
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

