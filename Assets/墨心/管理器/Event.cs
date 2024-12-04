using UnityEngine;
using System; // 用于 Action 和事件定义

namespace 墨心 {
    public class Event {
        public static event Action<Vector2, float> OnPlayerPositionUpdated;
        public static void NotifyPlayerPositionUpdated(Vector2 position, float rotation) {
            OnPlayerPositionUpdated?.Invoke(position, rotation);//人物移动
        }
        public static event Action<string, int> 地块点击;
        public static void 触发地块点击(string SoilType, int 数量) {
            地块点击?.Invoke(SoilType, 数量);
        }
        public static event Action<Vector2Int> on地块采光;
        public static void 地块采光(Vector2Int X) {
            on地块采光?.Invoke(X);
        }
    }
}