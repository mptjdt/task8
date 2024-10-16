using UnityEngine;
using System; // 添加此命名空间以使用 Action

namespace 墨心8A1
{
    public class TileClickHandler : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer; // 用于获取地块的 SpriteRenderer
        private TileInfo tileInfo; // 存储对应的 TileInfo 对象
        private MapGenerator mapGenerator; // 引用 MapGenerator 实例

        // 定义事件，传递地块类型和剩余数量
        public static event Action<TileInfo.TileType, int> OnTileClicked;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>(); // 获取当前 GameObject 的 SpriteRenderer

            // 获取 MapGenerator 实例并访问 TileInfo 列表
            mapGenerator = FindObjectOfType<MapGenerator>(); // 获取场景中的 MapGenerator 实例
            if (mapGenerator == null)
            {
                Debug.LogError("没有找到 MapGenerator 实例，请确保场景中有 MapGenerator 组件！");
                return; // 如果未找到，停止执行 Start 方法
            }

            // 查找对应的 TileInfo
            foreach (var info in mapGenerator.tileInfo)
            {
                if (info.TileObject == gameObject) // 检查当前 GameObject 是否是 tileInfo 中的地块
                {
                    tileInfo = info; // 存储找到的 TileInfo

                    // 尝试解析地块类型
                    if (Enum.TryParse(typeof(TileInfo.TileType), spriteRenderer.sprite.name, true, out var result))
                    {
                        tileInfo.Type = (TileInfo.TileType)result; // 成功解析，更新 TileInfo 的类型
                    }
                    else
                    {
                        Debug.LogError($"无法解析地块类型：{spriteRenderer.sprite.name}，请检查命名。");
                    }
                    break; // 找到对应地块后可以退出循环
                }
            }

            if (tileInfo == null)
            {
                Debug.LogError("未能找到对应的 TileInfo 对象！");
            }
        }

        private void OnMouseDown() // 当鼠标点击该对象时调用
        {
            if (tileInfo == null) return; // 如果未找到 TileInfo，直接返回

            if (tileInfo.Type == TileInfo.TileType.Stone) // 检查当前地块类型
            {
                tileInfo.RemainingCount--; // 减少剩余数量

                // 触发事件，传递地块类型和剩余数量
                OnTileClicked?.Invoke(TileInfo.TileType.Stone, tileInfo.RemainingCount);

                // 如果剩余数量达到所需的次数，则替换地块
                if (tileInfo.RemainingCount <= 0)
                {
                    ReplaceTileSprite("desert"); // 将地块替换为沙漠
                    tileInfo.RemainingCount = -1; // 更改数量为 -1
                    tileInfo.Type = TileInfo.TileType.Desert; // 更新地块类型为 Desert
                }
            }
            else if (tileInfo.Type == TileInfo.TileType.Desert) // 如果是沙漠类型
            {
                // 触发事件，传递地块类型和点击次数（沙漠类型点击不增加次数，固定传递 -1）
                OnTileClicked?.Invoke(TileInfo.TileType.Desert, -1);
            }
        }

        private void ReplaceTileSprite(string newSpriteName)
        {
            // 加载新的地块图片
            Sprite newSprite = Resources.Load<Sprite>(newSpriteName); // 确保新图片在 Assets/Resources 中
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite; // 替换图片
                // 更新 TileInfo 的类型
                if (Enum.TryParse(typeof(TileInfo.TileType), newSpriteName, true, out var result))
                {
                    tileInfo.Type = (TileInfo.TileType)result; // 更新 TileInfo 的类型
                }

                Debug.Log("已替换地块：" + tileInfo.TileObject.name + " 的图片为：" + newSpriteName); // 输出替换信息
            }
            else
            {
                Debug.LogError("未能加载新的地块图片，检查文件名和路径。");
            }
        }
    }
}
