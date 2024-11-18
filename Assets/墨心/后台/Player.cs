using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace 墨心 {
    public class Player {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; } // 当前旋转角度（以度为单位）
        public float moveSpeed { get; set; }//移动速度
        public float rotationSpeed { get; set; }//旋转速度
    }
    public static partial class GameManager {
        // 静态方法代替构造函数，并返回 Player 实例
        public static Player InitializePlayer(float movespeed, float rotationspeed) {
            Player player = new Player();  // 创建新的 Player 实例
            player.Position = new Vector2(0, 0);  // 初始化位置
            player.Rotation = 0;//初始固定为0
            player.moveSpeed = movespeed;
            player.rotationSpeed = rotationspeed;
            return player;  // 返回 Player 实例
        }
    }
}