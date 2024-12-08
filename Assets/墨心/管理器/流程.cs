using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace 墨心 {
    public static partial class GameManager {
        public static void 创建世界流程() {
            后台世界.创建世界(10, 10);
            后台世界.填充沙漠();
            后台世界.洒下铜矿(3, 3);
            后台世界.创建玩家(5, 5);
            //后台世界.Player = 后台玩家类.InitializePlayer(5f, 5f);
        }
        public static void 绘制世界流程() {
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    var 土质层 = 前台世界.创建土质层(i, j, 后台世界.Grid[i, j]);
                    var 矿石层 = 前台世界.创建矿石层(i, j, 后台世界.Grid[i, j]);
                    前台世界.所有矿石.Add(后台世界.Grid[i, j].坐标, 矿石层);
                }
            }
            前台世界.玩家 = 前台世界.创建玩家(后台世界.Player);
        }
        public static void 初始化快捷指令() {
            OnAppUpdate(() => {
                if (Input.GetKey(KeyCode.W)) {
                    Command.帧上移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.坐标, 后台世界.Player.旋转角度);
                }
                if (Input.GetKey(KeyCode.A)) {
                    Command.帧左移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.坐标, 后台世界.Player.旋转角度);
                }
                if (Input.GetKey(KeyCode.S)) {
                    Command.帧下移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.坐标, 后台世界.Player.旋转角度);
                }
                if (Input.GetKey(KeyCode.D)) {
                    Command.帧右移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.坐标, 后台世界.Player.旋转角度);
                }
                if (Input.GetMouseButtonDown(1)) {
                    Command.开采地块();
                }
                if (Input.GetMouseButtonDown(0)) {
                    //Input.mousePosition转化为坐标
                    信息面板.信息面板.GetComponentInChildren<Text>().text = Command.查询地块(X,Y);
                }
            });
        }
        public static void 订阅事件流程() {
            Event.OnPlayerPositionUpdated += (Vector2 position, float rotation) => {
                前台世界.玩家.transform.position = position;
                前台世界.玩家.transform.rotation = Quaternion.Euler(0, 0, rotation);
            };
            Event.on地块采光 += (Vector2Int X) => {
                if (前台世界.所有矿石.TryGetValue(X, out GameObject 删除地块)) {
                    前台世界.所有矿石.Remove(X);
                    Destroy(删除地块);
                }
            };
        }
    }
}