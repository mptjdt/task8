using UnityEngine;
using System; // 用于 Action 和事件定义
namespace 墨心{

    public class Event{
        // 定义一个角色坐标变化事件
        public static event Action<Vector2, float, FrontendWorld> OnPlayerPositionUpdated;

        // 触发事件的方法
        public static void NotifyPlayerPositionUpdated(Vector2 position, float rotation, FrontendWorld frontendworld)
        {
            // 如果有订阅者，触发事件
            OnPlayerPositionUpdated?.Invoke(position, rotation,frontendworld);
        }
    }

    public static partial class GameManager {
        // 事件订阅
        public static void 订阅事件(){
            Event.OnPlayerPositionUpdated += 修改角色贴图;
        }
    }

}