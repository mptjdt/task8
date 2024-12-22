using UnityEngine;
using System; // 用于 Action 和事件定义

namespace 墨心.Task8 {
    public class Event {
        public static event Action<Vector2, float> 当角色坐标更新;
        public static void 角色坐标更新(Vector2 position, float rotation) {
            当角色坐标更新?.Invoke(position, rotation);//人物移动
        }
        public static event Action<Vector2Int> 当地块采光;
        public static void 地块矿石采光(Vector2Int X) {
            当地块采光?.Invoke(X);
        }
        public static event Action<Vector2Int> 当地块采集成功;
        public static void 地块采集成功(Vector2Int X) {
            当地块采集成功?.Invoke(X);
        }
        public static event Action<Vector2Int> 当建筑受伤;
        public static void 建筑受伤(Vector2Int X) {
            当建筑受伤?.Invoke(X);
        }
        public static event Action<Vector2Int> 当地块建筑被毁;
        public static void 地块建筑被毁(Vector2Int X) {
            当地块建筑被毁?.Invoke(X);
        }
        public static event Action<Vector2Int> 当建筑掉落;
        public static void 建筑掉落(Vector2Int X) {
            当建筑掉落?.Invoke(X);
        }
        public static event Action 当玩家死亡;
        public static void 玩家死亡() {
            当玩家死亡?.Invoke();
        }
    }
}