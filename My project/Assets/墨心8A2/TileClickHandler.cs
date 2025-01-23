using UnityEngine;

namespace 墨心8A2
{
    public class TileClickHandler : MonoBehaviour
    {
        public MapGenerator mapGenerator; // 引用 MapGenerator 实例

        // 定义事件委托
        public delegate void TileClicked(string tileName, int layerType);
        public static event TileClicked OnTileClicked; // 声明事件
       

        



        // 检查鼠标是否在当前地块上
        public bool IsMouseOverTile(Vector3 mousePosition)
        {
            Vector3 tilePosition = transform.position;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // 获取地块的边界
            Vector2 tileSize = spriteRenderer.bounds.size;

            // 检查鼠标位置是否在地块范围内，包含 z 轴的判断
            return mousePosition.x >= tilePosition.x - tileSize.x / 2 &&
                   mousePosition.x <= tilePosition.x + tileSize.x / 2 &&
                   mousePosition.y >= tilePosition.y - tileSize.y / 2 &&
                   mousePosition.y <= tilePosition.y + tileSize.y / 2 &&
                   Mathf.Abs(mousePosition.z - tilePosition.z) < 0.1f; // z轴的匹配
        }


        // 从三维列表中获取 TileInfo
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
                            return mapGenerator.tilesInfo[x][y][z]; // 找到对应的 TileInfo 并返回
                        }
                    }
                }
            }
            return null; // 如果未找到，返回 null
        }

        // 处理点击的地块
        public void HandleTileClick(TileInfo tileInfo)
        {
            // 获取地块名称和层级类型
            string tileName = tileInfo.TileObject.name;
            string imageName = tileInfo.TileObject.GetComponent<SpriteRenderer>().sprite.name;
            int layerType = (int)tileInfo.Layer;

            // 根据层级类型处理不同的地块
            switch (tileInfo.Layer)
            {
                case TileInfo.LayerType.Desert:
                    Debug.Log("右键点击了沙漠地块");
                    break;

                case TileInfo.LayerType.边墙:
                    Debug.Log("右键点击了边墙地块");
                    break;

                case TileInfo.LayerType.虚空:
                    Debug.Log("右键点击了虚空地块");
                    break;

                default:
                    break;
            }

            // 触发事件，传递图片名称和层级类型
            OnTileClicked?.Invoke(imageName, layerType);
        }
    }
}

