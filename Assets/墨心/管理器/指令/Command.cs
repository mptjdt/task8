using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class Command {
        public static void CommandA() {
            角色位置改变(new Vector2(-后台世界.Player.移动速度 * Time.deltaTime, 0), 90f);
        }
        public static void CommandS() {
            角色位置改变(new Vector2(0, -后台世界.Player.移动速度 * Time.deltaTime), 180f);
        }
        public static void CommandW() {
            角色位置改变(new Vector2(0, 后台世界.Player.移动速度 * Time.deltaTime), 0f);
        }
        public static void CommandD() {
            角色位置改变(new Vector2(后台世界.Player.移动速度 * Time.deltaTime, 0), 270f);
        }
        public static void Command鼠标右键() {
            开采矿石();
        }
        private static void 角色位置改变(Vector2 positionChange, float targetRotation) {
            后台世界.Player.Position += positionChange;
            后台世界.Player.旋转角度 = Mathf.LerpAngle(后台世界.Player.旋转角度, targetRotation, Time.deltaTime * 后台世界.Player.旋转速度);
        }
        private static void 开采矿石() {
            Vector2 mousePosition = Input.mousePosition;
            TileInfo 当前地块 = 获取当前地块(mousePosition);
            if (当前地块.矿石层 != null) {
                if (当前地块.矿石层.数量 >0) {
                    当前地块.矿石层.数量 -= 1;
                }
                if(当前地块.矿石层.数量 == 0) {
                    前台世界.删除矿石对象(当前地块);
                }
            }
        }
    }
}