
using UnityEngine;
using static 墨心.GameManager;
namespace 墨心{

    public class Command {
        public static void CommandA() {
            WorldInstance.Player.Position += new Vector2(-WorldInstance.Player.moveSpeed * Time.deltaTime, 0);
        }
        public static void CommandS() {
            WorldInstance.Player.Position += new Vector2(0, -WorldInstance.Player.moveSpeed * Time.deltaTime);
        }
        public static void CommandW(){
            WorldInstance.Player.Position += new Vector2(0, WorldInstance.Player.moveSpeed * Time.deltaTime);
        }
        public static void CommandD() {
            WorldInstance.Player.Position += new Vector2(WorldInstance.Player.moveSpeed * Time.deltaTime, 0);
            
        }
    }
    public static partial class GameManager {
        public static void BindKeyCommands(){
            // 检测WASD按键并调用对应的指令方法
            if (Input.GetKey(KeyCode.W)){
                Command.CommandW();
            }
            if (Input.GetKey(KeyCode.A)){
                Command.CommandA();
            }
            if (Input.GetKey(KeyCode.S)){
                Command.CommandS();
            }
            if (Input.GetKey(KeyCode.D)){
                Command.CommandD();
            }
        }
    }
}
