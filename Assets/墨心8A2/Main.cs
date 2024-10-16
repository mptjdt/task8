using UnityEngine;
using ī��8A2; // �������������ռ�

public class Main : MonoBehaviour
{
    // ������ͼ������ʵ��
    private MapGenerator mapGenerator;

    private InfoPanel infoPanel; // ��Ϣ��������
    private TileClickHandler tileClickHandler;
    public static int count;
    public static int LastID = -1; // ��һ�ε���ؿ��ID����ʼ��Ϊ-1��ʾû�е����
    public static TileInfo lastK;
    public static int CurrentID; // ��ǰ����ؿ��ID

    public delegate void TileClicked(string tileName, int layerType);
    public static event TileClicked OnTileClicked; // �����¼�


    // Start ��������Ϸ��ʼʱ����
    void Start()
    {
        mapGenerator = gameObject.AddComponent<MapGenerator>(); // ��̬��� MapGenerator ���
        mapGenerator.GenerateMap(10, 10, 1f); // ֱ��������ʱ���ɵ�ͼ

        // ������Ϣ���
        infoPanel = gameObject.AddComponent<InfoPanel>();

    }

    private void Update()
    {
        // �������Ҽ����
        if (Input.GetMouseButtonDown(1)) // �Ҽ����
        {

            Debug.Log(this.mapGenerator.tilesInfo);
            // ��ȡ���λ�ò�ת��Ϊ��������
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);
            mousePosition.z=0;
            if (lastK is not null&&IsMouseOverTileNotZ(mousePosition, lastK.TileObject)){
                count++;
            }else{
                count=0;
            }
            mousePosition.z = count; // ȷ��z��λ��Ϊt��ģ�ⲻͬ�㼶�ĵؿ�
            // ������λ���Ƿ��ڵ�ǰ����ķ�Χ��
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foreach (TileInfo k in this.mapGenerator.tilesInfo[i][j])
                    {
                        // Debug.Log(k);
                        if (k is not null)
                        {
                            // Debug.Log("transform" + k.TileObject.transform);
                            if (IsMouseOverTile(mousePosition, k.TileObject))
                            {
                                // ��ȡ����ĵؿ���Ϣ
                                // TileInfo tileInfo = tileClickHandler.GetTileInfo(k.TileObject); // �˴���������һ��������ͨ����Ϸ�����ȡTileInfo
                                Debug.Log("CurrentID: " + CurrentID); // �����ǰ����ĵؿ�ID
                                Debug.Log("LastID: " + LastID); // �����ǰ����ĵؿ�ID
                                CurrentID = k.ID; // ��¼��ǰ����ؿ��ID
                                lastK = k;
                                HandleTileClick(k); // �������¼�
                                // ������һ�ε����ID
                                LastID = CurrentID;
                                Debug.Log("LastID After Update: " + LastID); // ������º�� LastID
                            }
                        }
                    }
                }
                //Debug.Log("id:" + k.ID);
                //Debug.Log("transform:" + k.TileObject.transform.position);
                /*

                */


            }
            // ��������ID��ͬ������t����5������tΪ0
            if (count >= 5)
            {
                count = 0; // ����tΪ0
            }
        }
    }

    // �������ĵؿ�
    public void HandleTileClick(TileInfo tileInfo)
    {
        // ��ȡ�ؿ����ƺͲ㼶����
        string tileName = tileInfo.TileObject.name;
        string imageName = tileInfo.TileObject.GetComponent<SpriteRenderer>().sprite.name;
        int layerType = (int)tileInfo.Layer;

        // ���ݲ㼶���ʹ���ͬ�ĵؿ�
        switch (tileInfo.Layer)
        {
            case TileInfo.LayerType.Desert:
                Debug.Log("�Ҽ������ɳĮ�ؿ�");
                break;

            case TileInfo.LayerType.��ǽ:
                Debug.Log("�Ҽ�����˱�ǽ�ؿ�");
                break;

            case TileInfo.LayerType.���:
                Debug.Log("�Ҽ��������յؿ�");
                break;

            default:
                break;
        }

        // �����¼�������ͼƬ���ƺͲ㼶����
        OnTileClicked?.Invoke(imageName, layerType);
    }

    // �������Ƿ��ڵ�ǰ�ؿ���
    public bool IsMouseOverTile(Vector3 mousePosition, GameObject TileObject)
    {
        if (TileObject is null)
        {
            return false;
        }
        Vector3 tilePosition = TileObject.transform.position;
        SpriteRenderer spriteRenderer = TileObject.GetComponent<SpriteRenderer>();

        // ��ȡ�ؿ�ı߽�
        Vector2 tileSize = spriteRenderer.bounds.size;

        // ������λ���Ƿ��ڵؿ鷶Χ�ڣ����� z ����ж�
        return mousePosition.x >= tilePosition.x - tileSize.x / 2 &&
               mousePosition.x <= tilePosition.x + tileSize.x / 2 &&
               mousePosition.y >= tilePosition.y - tileSize.y / 2 &&
               mousePosition.y <= tilePosition.y + tileSize.y / 2 &&
               Mathf.Abs(mousePosition.z - tilePosition.z) < 0.1f; // z���ƥ��
    }
    // �������Ƿ��ڵ�ǰ�ؿ���
    public bool IsMouseOverTileNotZ(Vector3 mousePosition, GameObject TileObject)
    {
        if (TileObject is null)
        {
            return false;
        }
        Vector3 tilePosition = TileObject.transform.position;
        SpriteRenderer spriteRenderer = TileObject.GetComponent<SpriteRenderer>();

        // ��ȡ�ؿ�ı߽�
        Vector2 tileSize = spriteRenderer.bounds.size;

        // ������λ���Ƿ��ڵؿ鷶Χ�ڣ����� z ����ж�
        return mousePosition.x >= tilePosition.x - tileSize.x / 2 &&
               mousePosition.x <= tilePosition.x + tileSize.x / 2 &&
               mousePosition.y >= tilePosition.y - tileSize.y / 2 &&
               mousePosition.y <= tilePosition.y + tileSize.y / 2;
               
    }
}
