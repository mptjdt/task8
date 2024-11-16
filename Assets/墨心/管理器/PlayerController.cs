using UnityEngine;
using static 墨心.GameManager;

namespace 墨心{
    public class PlayerController : MonoBehaviour{
        // 每帧更新玩家位置的逻辑
        void Start(){
            // 确保订阅事件
            GameManager.订阅事件();
        }

        void Update(){
            GameManager.BindKeyCommands();  // 调用 GameManager 中的方法，检查输入并更新玩家位置
        }
    }
}
