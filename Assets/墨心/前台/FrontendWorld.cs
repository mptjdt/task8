using System.Collections.Generic;
using System.Diagnostics;
using static 墨心.GameManager;
using UnityEngine;

namespace 墨心 {
    public class FrontendWorld : MonoBehaviour {
        public void CreateTileUI(int x, int y, TileInfo tileInfo) {
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // 创建一个新的 GameObject，命名为 "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // 设置地块的位置            
            tileObj.AddComponent<SpriteRenderer>().sprite = GameManager.LoadSprite(获取土质类型字符串(tileInfo));
        }
        public void Start() {
            订阅地块点击事件();
        }
        public void Update() {
        }
    }
}


