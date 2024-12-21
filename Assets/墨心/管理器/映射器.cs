using UnityEngine;

namespace 墨心.Task8 {
    public static partial class GameManager {
        public static Vector2Int 获取后台坐标(Vector2 screenPosition) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);// 使用摄像头将屏幕坐标转换为世界坐标
            int gridX = Mathf.FloorToInt(worldPos.x);  
            int gridY = Mathf.FloorToInt(worldPos.y);  // 取整转换为网格坐标          
            gridX = Mathf.Clamp(gridX, 0, 后台世界.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, 后台世界.Height - 1); // 将世界坐标转换为网格坐标
            return new Vector2Int(gridX, gridY);
        }
    }
}