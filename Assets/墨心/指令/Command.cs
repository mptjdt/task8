using UnityEngine;
using static 墨心.GameManager;
namespace 墨心{

    public class Command : MonoBehaviour{
        public static void CommandA() {
            WorldInstance.Player.transform.position += new Vector3(-WorldInstance.Player.moveSpeed * Time.deltaTime, 0, 0);
            WorldInstance.Player.transform.rotation = Quaternion.Lerp(WorldInstance.Player.transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        public static void CommandS() {
            WorldInstance.Player.transform.position += new Vector3(0,-WorldInstance.Player.moveSpeed * Time.deltaTime, 0);
            WorldInstance.Player.transform.rotation = Quaternion.Lerp(WorldInstance.Player.transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        public static void CommandW() {
            WorldInstance.Player.transform.position += new Vector3(0,WorldInstance.Player.moveSpeed * Time.deltaTime, 0);
            WorldInstance.Player.transform.rotation = Quaternion.Lerp(WorldInstance.Player.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        public static void CommandD() {
            WorldInstance.Player.transform.position += new Vector3(WorldInstance.Player.moveSpeed * Time.deltaTime, 0, 0);
            WorldInstance.Player.transform.rotation = Quaternion.Lerp(WorldInstance.Player.transform.rotation, Quaternion.Euler(0, 0, 270), Time.deltaTime * WorldInstance.Player.rotationSpeed);
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
