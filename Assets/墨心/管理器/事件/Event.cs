﻿using UnityEngine;
using System; // 用于 Action 和事件定义

namespace 墨心 {
    public class Event {
        public static event Action<Vector2, float> OnPlayerPositionUpdated;
        public static void NotifyPlayerPositionUpdated(Vector2 position, float rotation) {
            OnPlayerPositionUpdated?.Invoke(position, rotation);
        }
    }
    public static partial class GameManager {
        public static void 订阅事件() {
            Event.OnPlayerPositionUpdated += 修改角色贴图;
        }
    }
}