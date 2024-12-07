using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace 墨心 {
    public static partial class GameManager {
        public static void 初始化后台() {
            后台世界.创建世界(10, 10);
            后台世界.填充沙漠();
            后台世界.洒下铜矿(3, 3);
            后台世界.Player = 后台玩家类.InitializePlayer(5f, 5f);
        }
        public static void 初始化前台() {
            前台世界 = new 前台世界类();
            信息面板 = new UI系统();
        }
        public static void 绘制世界流程() {
            前台世界.所有地块 = new Dictionary<Vector2Int, GameObject>();
            for (int i = 0; i < 后台世界.Width; i++) {
                for (int j = 0; j < 后台世界.Height; j++) {
                    前台世界.创建土质层(i, j, 后台世界.Grid[i, j]);
                    GameObject 矿石层对象 = 前台世界.创建矿石层(i, j, 后台世界.Grid[i, j]);
                    前台世界.所有地块.Add(后台世界.Grid[i, j].位置, 矿石层对象);
                }
            }
            前台世界.玩家 = 前台世界.CreatePlayer(后台世界.Player);
        }
        public static void 初始化快捷指令() {
            OnAppUpdate(() => {
                if (Input.GetKey(KeyCode.W)) {
                    Command.帧上移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
                }
                if (Input.GetKey(KeyCode.A)) {
                    Command.帧左移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
                }
                if (Input.GetKey(KeyCode.S)) {
                    Command.帧下移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
                }
                if (Input.GetKey(KeyCode.D)) {
                    Command.帧右移();
                    Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
                }
                if (Input.GetMouseButtonDown(1)) {
                    Command.开采地块();
                }
                if (Input.GetMouseButtonDown(0)) {
                    Command.点击地块();
                }
            });
        }
        public static void 订阅事件流程() {
            Event.OnPlayerPositionUpdated += (Vector2 position, float rotation) => {
                前台世界.玩家.transform.position = position;
                前台世界.玩家.transform.rotation = Quaternion.Euler(0, 0, rotation);
            };
            Event.on地块采光 += (Vector2Int X) => {
                if (前台世界.所有地块.TryGetValue(X, out GameObject 删除地块)) {
                    前台世界.所有地块.Remove(X);
                    Destroy(删除地块);
                }
            };
        }
    }
}