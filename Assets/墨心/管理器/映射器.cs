using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static I地块 获取当前地块(int X,int Y) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector2(X, Y));
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);// 使用摄像头将屏幕坐标转换为世界坐标
            int gridX = Mathf.FloorToInt(worldPos.x);  
            int gridY = Mathf.FloorToInt(worldPos.y);  // 取整转换为网格坐标          
            gridX = Mathf.Clamp(gridX, 0, 后台世界.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, 后台世界.Height - 1); // 将世界坐标转换为网格坐标                                                                     // 判断是否在有效地块范围内
            if (gridX < 0 || gridX >= 后台世界.Width || gridY < 0 || gridY >= 后台世界.Height) {
                return null;  
            }
            return 后台世界.Grid[gridX, gridY];
        }
    }
}