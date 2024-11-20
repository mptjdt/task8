using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public class FrontendWorld : MonoBehaviour {
        public void CreateTileUI(int x, int y, List<TileInfo> tileInfoList) {
            foreach (var tileInfo in tileInfoList) {
                GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // 创建一个新的 GameObject，命名为 "Tile_x_y"
                tileObj.transform.position = new Vector3(x, y, 0);  // 设置地块的位置            
                var spriteRenderer = tileObj.AddComponent<SpriteRenderer>(); // 加载精灵并设置到 SpriteRenderer 上
                spriteRenderer.sprite = GameManager.LoadSprite(tileInfo.SoilType);  // 添加 SpriteRenderer 组件并直接设置精灵
                // 设置显示顺序，沙漠的顺序低于石头
                if (tileInfo.SoilType == "desert") {
                    spriteRenderer.sortingOrder = 0;  // 沙漠的层级
                }
                else if (tileInfo.SoilType == "stone") {
                    spriteRenderer.sortingOrder = 1;  // 石头的层级
                }
            }
        }
    } 
}

