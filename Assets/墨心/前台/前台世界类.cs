using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    /// <summary>
    /// Todo：前台类中不该出现TileInfo！！！！
    /// </summary>
    public class 前台世界类 : MonoBehaviour {
        public Dictionary<Vector2Int, GameObject> 所有地块;
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
        public void 创建前台世界(int 宽度, int 高度) {
            Grid = new 前台地块类[宽度, 高度];
            for (int i = 0; i < 宽度; i++) {
                for (int j = 0; j < 高度; j++) {
                    Grid[i, j] = new 前台地块类();
                }
            }
        }
        public GameObject 创建土质层(int x, int y, TileInfo tileInfo) {
            if (tileInfo.土质层 != null) {
                GameObject tileObj = new GameObject("土质层_" + x + "_" + y);
                tileObj.transform.position = new Vector3(x, y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取土质类型字符串(tileInfo));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 0;
                return tileObj;
            }
            return null;
        }
        public GameObject 创建矿石层(int x, int y, TileInfo tileInfo) {
            if (tileInfo.矿石层 != null) {
                GameObject tileObj = new GameObject("矿石层_" + x + "_" + y);
                tileObj.transform.position = new Vector3(x, y, 0);
                tileObj.AddComponent<SpriteRenderer>().sprite = LoadSprite(获取矿石类型字符串(tileInfo));
                tileObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
                return tileObj;
            }
            return null;
        }
        public void 删除矿石对象(TileInfo tileinfo, 前台地块类 前台地块) {
            if (前台地块.矿石对象 != null) {
                Destroy(前台地块.矿石对象);
                tileinfo.矿石层 = null;
                前台地块.矿石对象 = null;
            }
        }
    }
    public static partial class GameManager {
        public static 前台地块类 获取当前地块对象(Vector2 screenPosition) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);// 使用摄像头将屏幕坐标转换为世界坐标
            int gridX = Mathf.FloorToInt(worldPos.x);  // 取整转换为网格坐标
            int gridY = Mathf.FloorToInt(worldPos.y);  // 取整转换为网格坐标          
            gridX = Mathf.Clamp(gridX, 0, 前台世界.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, 前台世界.Height - 1); // 将世界坐标转换为网格坐标                                                                     // 判断是否在有效地块范围内
            if (gridX < 0 || gridX >= 前台世界.Width || gridY < 0 || gridY >= 前台世界.Height) {
                return null;  // 如果超出范围，返回 null 或其他表示无效的值
            }
            return 前台世界.Grid[gridX, gridY];// 根据网格坐标获取当前地块并返回
        }
    }
}