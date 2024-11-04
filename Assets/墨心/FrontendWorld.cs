using UnityEngine;

namespace 墨心{
    public class FrontendWorld : MonoBehaviour{

        // 创建特定坐标的地块 UI
        public void CreateTileUI(int x, int y, TileInfo tileInfo){
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // 创建一个新的 GameObject，命名为 "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // 设置地块的位置

            // 根据土质类型加载精灵
            Sprite tileSprite = Utils.LoadSprite(tileInfo.SoilType);  // 根据 TileInfo 的土质类型加载精灵
            if (tileSprite == null)  {
                Utils.HandleError($"{tileInfo.SoilType} sprite could not be found in Resources folder!");  // 记录错误信息
            }

            // 设置精灵
            SpriteRenderer spriteRenderer = tileObj.AddComponent<SpriteRenderer>();  // 为地块对象添加 SpriteRenderer 组件
            spriteRenderer.sprite = tileSprite;  // 将加载的精灵赋值给 SpriteRenderer
        }
    }
}
