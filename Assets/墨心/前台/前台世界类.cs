using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    public class 前台世界类 {
        public Dictionary<Vector2Int, GameObject> 所有地块;
        public GameObject 玩家;
        public GameObject CreatePlayer(I角色 X) {
            var A = new GameObject("Player");
            A.transform.position = X.Position;
            A.transform.rotation = Quaternion.Euler(0, 0, X.旋转角度);
            A.AddComponent<SpriteRenderer>().sprite = LoadSprite("player1");
            A.GetComponent<SpriteRenderer>().sortingOrder = 6;
            return A;
        }
        public void 创建土质层(int X, int Y, I地块 Z) {
            if (Z.土质层 != null) {
                GameObject tileObj = new GameObject("土质层_" + X + "_" + Y);
                tileObj.transform.position = new Vector3(X, Y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取土质类型字符串(Z));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        public GameObject 创建矿石层(int x, int y, I地块 tileInfo) {
            if (tileInfo.矿石层 != null) {
                GameObject tileObj = new GameObject("矿石层_" + x + "_" + y);
                tileObj.transform.position = new Vector3(x, y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取矿石类型字符串(tileInfo));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
                return tileObj;
            }
            return null;
        }
    }
}