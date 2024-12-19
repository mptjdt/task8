using UnityEngine;
using static 墨心.GameManager;
using UnityEngine.UI;
using static UnityEngine.Object;
using System;

namespace 墨心 {
    /// <summary>
    /// 指令分为三类：
    /// 1.命令。修改后台
    /// 2.查询。不修改后台，返回字符串
    /// </summary>
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
            后台世界[X,Y].开采();
        }
        public static string 查询地块(int X, int Y) {
            return 后台世界[X, Y].展示文本();
        }
        public static void 切换背包() {
            笔记.背包是否打开 = !笔记.背包是否打开;
            UI.打开背包(笔记.背包是否打开);
        }
        private static void PlayerMove(Vector2 X, float 目标方向) {
            后台世界.Player.坐标 += X;
            后台世界.Player.旋转角度 = Mathf.LerpAngle(后台世界.Player.旋转角度, 目标方向, Time.deltaTime * 后台世界.Player.旋转速度);
            Event.角色坐标更新(后台世界.Player.坐标, 后台世界.Player.旋转角度);
        }
    }
}