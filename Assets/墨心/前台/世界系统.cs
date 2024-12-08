using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    public class 世界系统 {
        public Dictionary<Vector2Int, GameObject> 所有矿石 = new();
        public GameObject 玩家;
        public GameObject 创建玩家(I角色 X) {
            var A = new GameObject("Player");
            A.transform.position = X.坐标;
            A.transform.rotation = Quaternion.Euler(0, 0, X.旋转角度);
            A.AddComponent<SpriteRenderer>().sprite = LoadSprite("player1");
            A.GetComponent<SpriteRenderer>().sortingOrder = 6;
            return A;
        }
        public GameObject 创建土质层(int X, int Y, I地块 Z) {
            if (Z.土质层 != null) {
                var A = new GameObject("土质层_" + X + "_" + Y);
                A.transform.position = new Vector3(X, Y, 0);
                A.AddComponent<SpriteRenderer>().sprite = LoadSprite(Z.土质层.类型.ToString());
                A.GetComponent<SpriteRenderer>().sortingOrder = 0;
                return A;
            }
            return null;
        }
        public GameObject 创建矿石层(int X, int Y, I地块 Z) {
            if (Z.矿石层 != null) {
                var A = new GameObject("矿石层_" + X + "_" + Y);
                A.transform.position = new Vector3(X, Y, 0);
                A.AddComponent<SpriteRenderer>().sprite = LoadSprite(Z.矿石层.类型.ToString());
                A.GetComponent<SpriteRenderer>().sortingOrder = 1;
                return A;
            }
            return null;
        }
    }
}