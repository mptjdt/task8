using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class PlayerController : MonoBehaviour {
        public GameObject PlayerObj;//持久化保存前台人物
        public GameObject CreatePlayer(Player player){           
            GameObject playerObj = new GameObject("Player");   
            playerObj.transform.position = player.Position; 
            SpriteRenderer spriteRenderer = playerObj.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GameManager.LoadSprite("player1"); 
            spriteRenderer.sortingOrder = 2; 
            playerObj.transform.rotation = Quaternion.Euler(0, 0, player.Rotation);
            playerObj.AddComponent<PlayerController>();
            return playerObj;
        }
        public void Start() {
            订阅人物移动事件();
        }
        public void Update() {
            if (Input.GetKey(KeyCode.W)) {
                Command.CommandW();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
            if (Input.GetKey(KeyCode.A)) {
                Command.CommandA();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
            if (Input.GetKey(KeyCode.S)) {
                Command.CommandS();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
            if (Input.GetKey(KeyCode.D)) {
                Command.CommandD();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
        }
    }
    public static partial class GameManager {
        public static void 修改角色贴图(Vector2 position, float rotation) {
            PlayerControllerInstance.PlayerObj.transform.position = position;
            PlayerControllerInstance.PlayerObj.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}
