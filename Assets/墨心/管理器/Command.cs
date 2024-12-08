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
        public static void 开采地块(int X,int Y) {
            获取当前地块(Input.mousePosition).开采();
        }
        public static string 查询地块(int X, int Y) {
            //查看地块信息(Input.mousePosition);
        }
        private static void PlayerMove(Vector2 X, float 目标方向) {
            后台世界.Player.坐标 += X;
            后台世界.Player.旋转角度 = Mathf.LerpAngle(后台世界.Player.旋转角度, 目标方向, Time.deltaTime * 后台世界.Player.旋转速度);
            Event.角色坐标更新(后台世界.Player.坐标, 后台世界.Player.旋转角度);
        }
        public static void 查看地块信息(Vector2 X) {
            var A = 获取当前地块(X);
            信息面板.信息面板.GetComponentInChildren<Text>().text = A.展示文本();
        }
    }
}