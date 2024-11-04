using UnityEngine;

namespace ī��{
    public class FrontendWorld : MonoBehaviour{

        // �����ض�����ĵؿ� UI
        public void CreateTileUI(int x, int y, TileInfo tileInfo){
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // ����һ���µ� GameObject������Ϊ "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // ���õؿ��λ��

            // �����������ͼ��ؾ���
            Sprite tileSprite = Utils.LoadSprite(tileInfo.SoilType);  // ���� TileInfo ���������ͼ��ؾ���
            if (tileSprite == null)  {
                Utils.HandleError($"{tileInfo.SoilType} sprite could not be found in Resources folder!");  // ��¼������Ϣ
            }

            // ���þ���
            SpriteRenderer spriteRenderer = tileObj.AddComponent<SpriteRenderer>();  // Ϊ�ؿ������� SpriteRenderer ���
            spriteRenderer.sprite = tileSprite;  // �����صľ��鸳ֵ�� SpriteRenderer
        }
    }
}
