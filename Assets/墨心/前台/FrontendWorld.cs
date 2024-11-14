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
        public void ShowPlayer(Player player){
            // 创建一个新的 GameObject 用来显示人物
            GameObject playerObj = new GameObject("Player2");

            // 将玩家对象的位置设置为玩家的坐标
            playerObj.transform.position = player.Position;

            // 获取或添加 SpriteRenderer 并设置精灵
            SpriteRenderer spriteRenderer = playerObj.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GameManager.LoadSprite("player1");  // 设置人物精灵
            spriteRenderer.sortingOrder = 1;  // 人物的排序顺序，较高的值显示在上方

        }

    }
}

