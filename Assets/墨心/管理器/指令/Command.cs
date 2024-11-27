using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class Command {
        public static void CommandA() {
            角色位置改变(new Vector2(-WorldInstance.Player.moveSpeed * Time.deltaTime, 0), 90f);
        }
        public static void CommandS() {
            角色位置改变(new Vector2(0, -WorldInstance.Player.moveSpeed * Time.deltaTime), 180f);
        }
        public static void CommandW() {
            角色位置改变(new Vector2(0, WorldInstance.Player.moveSpeed * Time.deltaTime), 0f);
        }
        public static void CommandD() {
            角色位置改变(new Vector2(WorldInstance.Player.moveSpeed * Time.deltaTime, 0), 270f);
        }
        public static void Command鼠标右键() {
            开采矿石();
        }
        private static void 角色位置改变(Vector2 positionChange, float targetRotation) {
            WorldInstance.Player.Position += positionChange;
            WorldInstance.Player.Rotation = Mathf.LerpAngle(WorldInstance.Player.Rotation, targetRotation, Time.deltaTime * WorldInstance.Player.rotationSpeed);
        }
        private static void 开采矿石() {
            Vector2 mousePosition = Input.mousePosition;
            TileInfo 当前地块 = 获取当前地块(mousePosition);
            if (当前地块.矿石层 != null) {
                if (当前地块.矿石层.数量 >0) {
                    当前地块.矿石层.数量 -= 1;
                }
                else{
                    FrontendInstance.删除矿石对象(当前地块);
                }
            }
        }
    }
}