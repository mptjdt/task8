using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    public class FrontendWorld : MonoBehaviour {
        public void Start() {
            订阅地块点击事件();
        }
        public void Update() {
            if (Input.GetMouseButtonDown(1)) {
                Command.Command鼠标右键();
            }
            if (Input.GetMouseButtonDown(0)) {
                Vector2 mousePosition = Input.mousePosition;
                TileInfo 当前地块 = 获取当前地块(mousePosition);
                if (当前地块.矿石层 != null) {
                    Event.触发地块点击(获取矿石类型字符串(当前地块), 当前地块.矿石层.数量);
                }
                if (当前地块.矿石层 == null && 当前地块.土质层 != null) {
                    Event.触发地块点击(获取土质类型字符串(当前地块), -1);
                }
            }
        }
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
                tileInfo.矿石对象 = tileObj;//持久储存，方便查找与删除
            }
        }
        public void 删除矿石对象(TileInfo tileInfo) {
            if (tileInfo.矿石对象 != null) {
                Destroy(tileInfo.矿石对象);
                tileInfo.矿石层 = null;
                tileInfo.矿石对象 = null;
            }
        }
    }
}