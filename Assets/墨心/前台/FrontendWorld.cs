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
}

