using UnityEngine;
namespace ī��{
    public class FrontendWorld : MonoBehaviour{
        // �����ض�����ĵؿ� UI
        public void CreateTileUI(int x, int y, TileInfo tileInfo){
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // ����һ���µ� GameObject������Ϊ "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // ���õؿ��λ��

            // ���ؾ��鲢���õ� SpriteRenderer ��
            tileObj.AddComponent<SpriteRenderer>().sprite = GameManager.LoadSprite(tileInfo.SoilType);  // ��� SpriteRenderer �����ֱ�����þ���
        }
    }
    public static partial class GameManager{
        public static void ShowPlayer(Player player){
            // ����һ���µ� GameObject ������ʾ����
            GameObject playerObj = new GameObject("Player");

            // ����Ҷ����λ������Ϊ��ҵ�����
            playerObj.transform.position = player.Position;

            // ��ȡ����� SpriteRenderer �����þ���
            SpriteRenderer spriteRenderer = playerObj.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GameManager.LoadSprite("player1");  // �������ﾫ��
            spriteRenderer.sortingOrder = 1;  // ���������˳�򣬽ϸߵ�ֵ��ʾ���Ϸ�

        }

    }
}

