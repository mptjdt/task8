﻿using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class 前台人物类 : MonoBehaviour {
        public GameObject PlayerObj;//持久化保存前台人物
        public GameObject CreatePlayer(Player player) {
            var A = new GameObject("Player");
            A.transform.position = player.Position;
            A.transform.rotation = Quaternion.Euler(0, 0, player.旋转角度);
            A.AddComponent<SpriteRenderer>().sprite = LoadSprite("player1");
            A.GetComponent<SpriteRenderer>().sortingOrder = 6;
            A.AddComponent<前台人物类>();
            return A;
        }
        public void Start() {
            订阅人物移动事件();
        }
        public void Update() {
            if (Input.GetKey(KeyCode.W)) {
                Command.CommandW();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
            if (Input.GetKey(KeyCode.A)) {
                Command.CommandA();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
            if (Input.GetKey(KeyCode.S)) {
                Command.CommandS();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
            if (Input.GetKey(KeyCode.D)) {
                Command.CommandD();
                Event.NotifyPlayerPositionUpdated(后台世界.Player.Position, 后台世界.Player.旋转角度);
            }
        }
    }
    public static partial class GameManager {
        public static void 修改角色贴图(Vector2 position, float rotation) {
            前台人物.PlayerObj.transform.position = position;
            前台人物.PlayerObj.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}