using UnityEngine;
using System; // 用于 Action 和事件定义
namespace 墨心{

    public class Event{
        // 定义一个角色后台坐标和旋转变化的事件
        public static event Action<Vector2, float> OnPlayerPositionUpdated;

        // 触发事件的方法
        public static void NotifyPlayerPositionUpdated(Vector2 position, float rotation){
            // 如果有订阅者，触发事件
            OnPlayerPositionUpdated?.Invoke(position, rotation);
        }
    }

    public static partial class GameManager {
        // 事件订阅
        public static void 订阅事件(){
            Event.OnPlayerPositionUpdated += 角色后台坐标变化;
        }
        public static void 角色后台坐标变化(Vector2 position, float rotation){
            FrontendInstance.playerobj.transform.position=position;
            FrontendInstance.playerobj.transform.rotation= Quaternion.Euler(0, 0, rotation);
        }
    }

}