using UnityEngine;
using static 墨心.GameManager;

namespace 墨心{
    public class PlayerController : MonoBehaviour{
        public void Start(){
            订阅事件();
        }
        public void Update(){
            if (Input.GetKey(KeyCode.W)) {
                Command.CommandW();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
            if (Input.GetKey(KeyCode.A)) {
                Command.CommandA();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
            if (Input.GetKey(KeyCode.S)) {
                Command.CommandS();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
            if (Input.GetKey(KeyCode.D)) {
                Command.CommandD();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
        }
    }
}
