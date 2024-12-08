using UnityEngine;
using System; // 用于 Action 和事件定义

namespace 墨心 {
    public class Event {
        public static event Action<Vector2, float> 当角色坐标更新;
        public static void 角色坐标更新(Vector2 position, float rotation) {
            当角色坐标更新?.Invoke(position, rotation);//人物移动
        }
        public static event Action<Vector2Int> 当地块采光;
        public static void 地块采光(Vector2Int X) {
            当地块采光?.Invoke(X);
        }
    }
}