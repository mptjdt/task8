using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    public class 前台世界类 : MonoBehaviour {
        public Dictionary<Vector2Int, GameObject> 所有地块;
        public void Start() {

        }
        public void Update() {
            if (Input.GetMouseButtonDown(1)) {
                Command.开采地块();
            }
            if (Input.GetMouseButtonDown(0)) {
                Vector2 mousePosition = Input.mousePosition;
                后台地块类 当前地块 = 获取当前地块(mousePosition);
                if (当前地块.矿石层 != null) {
                    Event.触发地块点击(当前地块, 当前地块.矿石层.数量);
                }
                if (当前地块.矿石层 == null && 当前地块.土质层 != null) {
                    Event.触发地块点击(当前地块, -1);
                }
            }
        }
        public void 创建土质层(int x, int y, 后台地块类 tileInfo) {
            if (tileInfo.土质层 != null) {
                GameObject tileObj = new GameObject("土质层_" + x + "_" + y);
                tileObj.transform.position = new Vector3(x, y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取土质类型字符串(tileInfo));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        public GameObject 创建矿石层(int x, int y, 后台地块类 tileInfo) {
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