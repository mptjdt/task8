using UnityEngine;
using static 墨心.GameManager;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace 墨心 {
    public class Command {
        public static void 帧左移() {
            PlayerMove(new Vector2(-后台世界.Player.移动速度 * Time.deltaTime, 0), 90f);
        }
        public static void 帧下移() {
            PlayerMove(new Vector2(0, -后台世界.Player.移动速度 * Time.deltaTime), 180f);
        }
        public static void 帧上移() {
            PlayerMove(new Vector2(0, 后台世界.Player.移动速度 * Time.deltaTime), 0f);
        }
        public static void 帧右移() {
            PlayerMove(new Vector2(后台世界.Player.移动速度 * Time.deltaTime, 0), 270f);
        }
        public static void 开采地块() {
            获取当前地块(Input.mousePosition).开采();
        }
        public static void 点击地块() {
            查看地块信息(Input.mousePosition);
        }
        private static void PlayerMove(Vector2 X, float 目标方向) {
            后台世界.Player.Position += X;
            后台世界.Player.旋转角度 = Mathf.LerpAngle(后台世界.Player.旋转角度, 目标方向, Time.deltaTime * 后台世界.Player.旋转速度);
        }
        public static void 查看地块信息(Vector2 X) {
            var A = 获取当前地块(X);
            if (A.矿石层 != null) {
                信息面板.信息面板.GetComponentInChildren<Text>().text = $"地块类型: {获取矿石类型字符串(A)}\n数量: {A.矿石层.数量}";
            }
            if (A.矿石层 == null && A.土质层 != null) {
                信息面板.信息面板.GetComponentInChildren<Text>().text = $"地块类型: {获取土质类型字符串(A)}\n数量: {-1}";
            }
        }
    }
}