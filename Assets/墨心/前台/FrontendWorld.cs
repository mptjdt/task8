using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
namespace 墨心{
    public class FrontendWorld : MonoBehaviour{
        public GameObject playerobj;
        public void CreateTileUI(int x, int y, List<TileInfo> tileInfoList){
            foreach (var tileInfo in tileInfoList){
                GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // 创建一个新的 GameObject，命名为 "Tile_x_y"
                tileObj.transform.position = new Vector3(x, y, 0);  // 设置地块的位置

                // 加载精灵并设置到 SpriteRenderer 上
                var spriteRenderer = tileObj.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = GameManager.LoadSprite(tileInfo.SoilType);  // 添加 SpriteRenderer 组件并直接设置精灵

                // 设置显示顺序，沙漠的顺序低于石头
                if (tileInfo.SoilType == "desert"){
                    spriteRenderer.sortingOrder = 0;  // 沙漠的层级
                }
                else if (tileInfo.SoilType == "stone"){
                    spriteRenderer.sortingOrder = 1;  // 石头的层级
                }
            }
        }
        public GameObject CreatePlayer(Player player){
            // 创建一个新的 GameObject 用来显示人物
            GameObject playerObj = new GameObject("Player");

            // 将玩家对象的位置设置为玩家的坐标
            playerObj.transform.position = player.Position;

            // 获取或添加 SpriteRenderer 并设置精灵
            SpriteRenderer spriteRenderer = playerObj.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GameManager.LoadSprite("player1");  // 设置人物精灵
            spriteRenderer.sortingOrder = 2;  // 人物的排序顺序，较高的值显示在上方

            // 根据玩家的旋转角度更新角色的旋转
            playerObj.transform.rotation = Quaternion.Euler(0, 0, player.Rotation);  // 将旋转应用到 GameObject
            playerObj.AddComponent<PlayerController>();
            return playerObj;
        }
    }
    public static partial class GameManager{
        public static void 修改角色贴图(Vector2 position, float rotation, FrontendWorld frontendWorld){
            frontendWorld.gameObject.transform.position = position;
            frontendWorld.gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}

