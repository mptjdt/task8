using UnityEngine;

namespace ī��
{
    public class FrontendWorld : MonoBehaviour
    {
        private Sprite desertSprite;

        // ���캯�������� World ʵ��
        public FrontendWorld(World worldInstance)
        {
            // ����ɳĮ����
            desertSprite = Resources.Load<Sprite>("desert");  // �� Resources �ļ��м�����Ϊ "desert" �� Sprite
            if (desertSprite == null)  // ���ɳĮ�����Ƿ�ɹ�����
            {
                UnityEngine.Debug.LogError("Desert sprite could not be found in Resources folder!");  // ��¼������Ϣ
            }

            DisplayTiles(worldInstance);  // ������ʾ�ؿ�ķ���
        }

        // ��ʾ��ͼ�ϵ����еؿ�
        private void DisplayTiles(World world)  // �� World ʵ����Ϊ����
        {
            int gridWidth = world.Grid.GetLength(0);  // ��ȡ��ͼ�Ŀ�ȣ�������
            int gridHeight = world.Grid.GetLength(1);  // ��ȡ��ͼ�ĸ߶ȣ�������

            // ˫��ѭ��������ͼ��ÿ��λ��
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    CreateTileUI(x, y);  // Ϊÿ���ؿ鴴���û�����
                }
            }
        }

        // ����һ���ض�����ĵؿ��û�����
        private void CreateTileUI(int x, int y)
        {
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // ����һ���µ� GameObject������Ϊ "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // ���õؿ��λ��

            // ����ɳĮ����
            SpriteRenderer spriteRenderer = tileObj.AddComponent<SpriteRenderer>();  // Ϊ�ؿ������� SpriteRenderer ���
            spriteRenderer.sprite = desertSprite;  // ��ɳĮ���鸳ֵ�� SpriteRenderer
        }
    }
}
