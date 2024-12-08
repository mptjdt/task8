using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace 墨心 {
    public class 世界设定类 {
        public int 宽度 = 10;
        public int 高度 = 10;
        public int 铜矿尺寸 = 3;
        public int 铜矿数量 = 3;
        public int 玩家移速 = 5;
        public int 玩家转速 = 5;
    }
    public static partial class GameManager {
        public static void 创建世界流程(世界设定类 X) {
            后台世界.创建世界(X.宽度, X.高度);
            后台世界.填充沙漠();
            后台世界.洒下几堆铜矿(X.铜矿尺寸, X.铜矿数量);
            后台世界.创建玩家(X.玩家移速, X.玩家转速);
            //后台世界.Player = 后台玩家类.InitializePlayer(5f, 5f);
        }
        public static void 绘制世界流程() {
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    前台世界.创建土质层(i, j, 后台世界.Grid[i, j]);
                    前台世界.创建矿石层(i, j, 后台世界.Grid[i, j]);
                }
            }
            前台世界.创建玩家(后台世界.Player);
        }
        public static void 初始化快捷指令() {
            OnAppUpdate(() => {
                if (Input.GetKey(KeyCode.W)) {
                    Command.帧上移();
                }
                if (Input.GetKey(KeyCode.A)) {
                    Command.帧左移();
                }
                if (Input.GetKey(KeyCode.S)) {
                    Command.帧下移();
                }
                if (Input.GetKey(KeyCode.D)) {
                    Command.帧右移();
                }
                if (Input.GetMouseButtonDown(1)) {
                    Command.开采地块(X, Y);
                }
                if (Input.GetMouseButtonDown(0)) {
                    //Input.mousePosition转化为坐标
                    信息面板.信息面板.GetComponentInChildren<Text>().text = Command.查询地块(X, Y);
                }
            });
        }
        public static void 订阅事件流程() {
            Event.当角色坐标更新 += (Vector2 X, float Y) => {
                前台世界.玩家.transform.position = X;
                前台世界.玩家.transform.rotation = Quaternion.Euler(0, 0, Y);
            };
            Event.当地块采光 += (Vector2Int X) => {
                if (前台世界.所有矿石.TryGetValue(X, out GameObject A)) {
                    前台世界.所有矿石.Remove(X);
                    Destroy(A);
                    Print($"地块 {X.x}-{X.y} 采光！");
                }
            };
        }
    }
}