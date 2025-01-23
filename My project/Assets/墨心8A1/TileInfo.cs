using UnityEngine;

namespace 墨心8A1
{
    public class TileInfo
    {
        // 定义 TileType 枚举
        public enum TileType
        {
            Desert,
            Stone
        }

        public GameObject TileObject; // 地块的GameObject引用
        public TileType Type; // 地块类型（使用 TileInfo 中的枚举）
        public int RemainingCount; // 剩余数量

        public TileInfo(GameObject tileObject, TileType type, int remainingCount)
        {
            TileObject = tileObject; // 保存GameObject
            Type = type; // 保存地块类型
            RemainingCount = remainingCount;
        }
    }
}
