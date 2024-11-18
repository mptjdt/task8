using UnityEngine;
using static 墨心.GameManager;
namespace 墨心{

    public class Command {
        public static void CommandA(){
            角色位置改变(WorldInstance, new Vector2(-WorldInstance.Player.moveSpeed * Time.deltaTime, 0), 90f);
        }

        public static void CommandS(){
            角色位置改变(WorldInstance, new Vector2(0, -WorldInstance.Player.moveSpeed * Time.deltaTime), 180f);
        }

        public static void CommandW(){
            角色位置改变(WorldInstance, new Vector2(0, WorldInstance.Player.moveSpeed * Time.deltaTime), 0f);
        }

        public static void CommandD(){
            角色位置改变(WorldInstance, new Vector2(WorldInstance.Player.moveSpeed * Time.deltaTime, 0), 270f);
        }
    }
    public static partial class GameManager {
        public static void BindKeyCommands(){
            // 检测WASD按键并调用对应的指令方法
            if (Input.GetKey(KeyCode.W)){
                Command.CommandW();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
            if (Input.GetKey(KeyCode.A)){
                Command.CommandA();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
            if (Input.GetKey(KeyCode.S)){
                Command.CommandS();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
            if (Input.GetKey(KeyCode.D)){
                Command.CommandD();
                Event.NotifyPlayerPositionUpdated(WorldInstance.Player.Position, WorldInstance.Player.Rotation, FrontendInstance);
            }
        }
    }
}
