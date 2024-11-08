using UnityEngine;

namespace 墨心{
    public class FrontendWorld : MonoBehaviour{
        // 创建特定坐标的地块 UI
        public void CreateTileUI(int x, int y, TileInfo tileInfo){
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // 创建一个新的 GameObject，命名为 "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // 设置地块的位置

            // 加载精灵并设置到 SpriteRenderer 上
            tileObj.AddComponent<SpriteRenderer>().sprite = GameManager.LoadSprite(tileInfo.SoilType);  // 添加 SpriteRenderer 组件并直接设置精灵
        }
    }
}

