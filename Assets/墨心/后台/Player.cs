using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace ī�� {
    public class Player {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; } // ��ǰ��ת�Ƕȣ��Զ�Ϊ��λ��
        public float moveSpeed { get; set; }//�ƶ��ٶ�
        public float rotationSpeed { get; set; }//��ת�ٶ�
    }
    public static partial class GameManager {
        // ��̬�������湹�캯���������� Player ʵ��
        public static Player InitializePlayer(float movespeed, float rotationspeed) {
            Player player = new Player();  // �����µ� Player ʵ��
            player.Position = new Vector2(0, 0);  // ��ʼ��λ��
            player.Rotation = 0;//��ʼ�̶�Ϊ0
            player.moveSpeed = movespeed;
            player.rotationSpeed = rotationspeed;
            return player;  // ���� Player ʵ��
        }
    }
}