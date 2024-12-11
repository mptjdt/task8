using UnityEngine;
using static 墨心.GameManager;
using UnityEngine.UI;
using static UnityEngine.Object;
using System;

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
            获取当前地块(X,Y).开采();
            if (获取当前地块(X, Y).矿石层 != null) {
                后台背包.添加物品(new 后台物品类() { 名称 = 获取当前地块(X, Y).矿石层.类型.ToString(), 数量 = 1 });
                if(获取当前地块(X, Y).矿石层.数量 == 0) {
                    获取当前地块(X, Y).矿石层 = null;
                }
                Event.背包更新(后台背包.Grid);
            }
        }
        public static string 查询地块(int X, int Y) {
            return 获取当前地块(X, Y).展示文本();
        }
        public static void 切换背包() {
            Event.开关背包();
        }
        private static void PlayerMove(Vector2 X, float 目标方向) {
            后台世界.Player.坐标 += X;
            后台世界.Player.旋转角度 = Mathf.LerpAngle(后台世界.Player.旋转角度, 目标方向, Time.deltaTime * 后台世界.Player.旋转速度);
            Event.角色坐标更新(后台世界.Player.坐标, 后台世界.Player.旋转角度);
        }
    }
}