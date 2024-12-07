using UnityEngine;
using System; // 用于 Action 和事件定义

namespace 墨心 {
    public class Event {
        public static event Action<Vector2, float> OnPlayerPositionUpdated;
        public static void NotifyPlayerPositionUpdated(Vector2 position, float rotation) {
            OnPlayerPositionUpdated?.Invoke(position, rotation);//人物移动
        }
        public static event Action<Vector2Int> on地块采光;
        public static void 地块采光(Vector2Int X) {
            on地块采光?.Invoke(X);
        }
    }
}