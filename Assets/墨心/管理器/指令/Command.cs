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
        private static void 角色位置改变(World world, Vector2 positionChange, float targetRotation) {
            world.Player.Position += positionChange;
            world.Player.Rotation = Mathf.LerpAngle(world.Player.Rotation, targetRotation, Time.deltaTime * world.Player.rotationSpeed);
        }
    }
}