using UnityEngine;
using static 墨心.GameManager;
namespace 墨心{

    public class Command {
        public static void CommandA() {
            WorldInstance.Player.Position += new Vector2(-WorldInstance.Player.moveSpeed * Time.deltaTime, 0);
            WorldInstance.Player.Rotation = Mathf.LerpAngle(WorldInstance.Player.Rotation, 90f, Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        public static void CommandS() {
            WorldInstance.Player.Position += new Vector2(0, -WorldInstance.Player.moveSpeed * Time.deltaTime);
            WorldInstance.Player.Rotation = Mathf.LerpAngle(WorldInstance.Player.Rotation, 180f, Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        public static void CommandW(){
            WorldInstance.Player.Position += new Vector2(0, WorldInstance.Player.moveSpeed * Time.deltaTime);
            WorldInstance.Player.Rotation = Mathf.LerpAngle(WorldInstance.Player.Rotation, 0f, Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        public static void CommandD() {
            WorldInstance.Player.Position += new Vector2(WorldInstance.Player.moveSpeed * Time.deltaTime, 0);
            WorldInstance.Player.Rotation = Mathf.LerpAngle(WorldInstance.Player.Rotation, 270f, Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
    }
    public static partial class GameManager {
        public static void BindKeyCommands(){
            // 检测WASD按键并调用对应的指令方法
            if (Input.GetKey(KeyCode.W)){
                Command.CommandW();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
            if (Input.GetKey(KeyCode.A)){
                Command.CommandA();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
            if (Input.GetKey(KeyCode.S)){
                Command.CommandS();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
            if (Input.GetKey(KeyCode.D)){
                Command.CommandD();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation);
            }
        }
    }
}
