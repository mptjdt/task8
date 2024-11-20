using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class Command {
        public static void CommandA() {
            角色位置改变(new Vector2(-PlayerInstance.moveSpeed * Time.deltaTime, 0), 90f);
        }
        public static void CommandS() {
            角色位置改变(new Vector2(0, -PlayerInstance.moveSpeed * Time.deltaTime), 180f);
        }
        public static void CommandW() {
            角色位置改变(new Vector2(0, PlayerInstance.moveSpeed * Time.deltaTime), 0f);
        }
        public static void CommandD() {
            角色位置改变(new Vector2(PlayerInstance.moveSpeed * Time.deltaTime, 0), 270f);
        }
        private static void 角色位置改变(Vector2 positionChange, float targetRotation) {
            PlayerInstance.Position += positionChange;
            PlayerInstance.Rotation = Mathf.LerpAngle(PlayerInstance.Rotation, targetRotation, Time.deltaTime * PlayerInstance.rotationSpeed);
        }
    }
}