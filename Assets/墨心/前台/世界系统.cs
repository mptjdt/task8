using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.LocalStorage;
using UnityEngine;
using System.Linq;

namespace 墨心.Task8 {
    public class 世界系统 {
        public Dictionary<Vector2Int, GameObject> 所有矿石 = new();
        public Dictionary<Vector2Int, GameObject> 所有土质 = new();
        public Dictionary<Vector2Int, GameObject> 所有建筑 = new();
        public GameObject 玩家;
        public void 创建玩家(I角色 X) {
            玩家 = new GameObject("Player");
            玩家.transform.position = X.坐标;
            玩家.transform.rotation = Quaternion.Euler(0, 0, X.旋转角度);
            玩家.AddComponent<SpriteRenderer>().sprite = LoadSprite("player1");
            玩家.GetComponent<SpriteRenderer>().sortingOrder = 6;
        }
        public void 创建土质层(int X, int Y, I地块 Z) {
            if (Z.土质层 != null) {
                所有土质[Z.坐标] = new GameObject("土质层_" + X + "_" + Y);
                所有土质[Z.坐标].transform.position = new Vector3(X+0.5f, Y+0.5f, 0);
                所有土质[Z.坐标].AddComponent<SpriteRenderer>().sprite = LoadSprite(Z.土质层.类型.ToString());
                所有土质[Z.坐标].GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        public void 创建矿石层(int X, int Y, I地块 Z) {
            if (Z.矿石层 != null) {
                所有矿石[Z.坐标] = new GameObject("矿石层_" + X + "_" + Y);
                所有矿石[Z.坐标].transform.position = new Vector3(X+0.5f, Y+0.5f, 0);
                所有矿石[Z.坐标].AddComponent<SpriteRenderer>().sprite = LoadSprite(Z.矿石层.类型.ToString());
                所有矿石[Z.坐标].GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
        public void 创建建筑层(int X, int Y, I地块 Z) {
            if (Z.建筑层 != null) {
                所有建筑[Z.坐标] = new GameObject("建筑层_" + X + "_" + Y);
                所有建筑[Z.坐标].transform.position = new Vector3(X+0.5f, Y+0.5f, 0);
                所有建筑[Z.坐标].AddComponent<SpriteRenderer>().sprite = LoadSprite(Z.建筑层.类型.ToString());
                所有建筑[Z.坐标].GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
    }
}