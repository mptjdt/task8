using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    public class FrontendWorld : MonoBehaviour {
        public void 创建土质层(int x, int y, TileInfo tileInfo) {
            if (tileInfo.土质层 != null) {
                GameObject tileObj = new GameObject("土质层_" + x + "_" + y);
                tileObj.transform.position = new Vector3(x, y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取土质类型字符串(tileInfo));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        public void 创建矿石层(int x, int y, TileInfo tileInfo) {
            if (tileInfo.矿石层 != null) {
                GameObject tileObj = new GameObject("矿石层_" + x + "_" + y);
                tileObj.transform.position = new Vector3(x, y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取矿石类型字符串(tileInfo));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
        public void Start() {
            订阅地块点击事件();
        }
        public void Update() {
        }
    }
}


