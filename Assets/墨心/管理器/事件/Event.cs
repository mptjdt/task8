using UnityEngine;
using System; // 用于 Action 和事件定义

namespace 墨心 {
    public class Event {
        public static event Action<Vector2, float> OnPlayerPositionUpdated;
        public static void NotifyPlayerPositionUpdated(Vector2 position, float rotation) {
            OnPlayerPositionUpdated?.Invoke(position, rotation);//人物移动
        }
        public static event Action<string,int> 地块点击;
        public static void 触发地块点击(string SoilType, int 数量) {
            地块点击?.Invoke(SoilType,数量);
        }
    }
    public static partial class GameManager {
        public static void 订阅人物移动事件() {
            Event.OnPlayerPositionUpdated += 修改角色贴图;
        }
        public static void 订阅地块点击事件() {
            Event.地块点击 += 修改信息面板;
        }
    }
}