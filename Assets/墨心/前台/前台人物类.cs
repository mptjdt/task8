using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class 前台人物类 : MonoBehaviour {
        public GameObject PlayerObj;//持久化保存前台人物
        public GameObject CreatePlayer(后台玩家类 player) {
            var A = new GameObject("Player");
            A.transform.position = player.Position;
            A.transform.rotation = Quaternion.Euler(0, 0, player.旋转角度);
            A.AddComponent<SpriteRenderer>().sprite = LoadSprite("player1");
            A.GetComponent<SpriteRenderer>().sortingOrder = 6;
            A.AddComponent<前台人物类>();
            return A;
        }
        public void Start() {

        }
        public void Update() {
            if (Input.GetKey(KeyCode.W)) {
                Command.帧上移();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
            if (Input.GetKey(KeyCode.A)) {
                Command.帧左移();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
            if (Input.GetKey(KeyCode.S)) {
                Command.帧下移();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
            if (Input.GetKey(KeyCode.D)) {
                Command.帧右移();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
        }
    }
}