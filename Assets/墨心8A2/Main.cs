using UnityEngine;
using 墨心8A2; // 引用您的命名空间

public class Main : MonoBehaviour
{
    // 创建地图生成器实例
    private MapGenerator mapGenerator;

    private InfoPanel infoPanel; // 信息面板的引用
    private TileClickHandler tileClickHandler;
    public static int count;
    public static int LastID = -1; // 上一次点击地块的ID，初始化为-1表示没有点击过
    public static TileInfo lastK;
    public static int CurrentID; // 当前点击地块的ID

    public delegate void TileClicked(string tileName, int layerType);
    public static event TileClicked OnTileClicked; // 声明事件


    // Start 方法在游戏开始时调用
    void Start()
    {
        mapGenerator = gameObject.AddComponent<MapGenerator>(); // 动态添加 MapGenerator 组件
        mapGenerator.GenerateMap(10, 10, 1f); // 直接在启动时生成地图

        // 创建信息面板
        infoPanel = gameObject.AddComponent<InfoPanel>();

    }

    private void Update()
    {
        // 检测鼠标右键点击
        if (Input.GetMouseButtonDown(1)) // 右键点击
        {

            Debug.Log(this.mapGenerator.tilesInfo);
            // 获取鼠标位置并转换为世界坐标
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);
            mousePosition.z=0;
            if (lastK is not null&&IsMouseOverTileNotZ(mousePosition, lastK.TileObject)){
                count++;
            }else{
                count=0;
            }
            mousePosition.z = count; // 确保z轴位置为t，模拟不同层级的地块
            // 检查鼠标位置是否在当前物体的范围内
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
                                // 获取点击的地块信息
                                // TileInfo tileInfo = tileClickHandler.GetTileInfo(k.TileObject); // 此处假设你有一个方法能通过游戏对象获取TileInfo
                                Debug.Log("CurrentID: " + CurrentID); // 输出当前点击的地块ID
                                Debug.Log("LastID: " + LastID); // 输出当前点击的地块ID
                                CurrentID = k.ID; // 记录当前点击地块的ID
                                lastK = k;
                                HandleTileClick(k); // 处理点击事件
                                // 更新上一次点击的ID
                                LastID = CurrentID;
                                Debug.Log("LastID After Update: " + LastID); // 输出更新后的 LastID
                            }
                        }
                    }
                }
                //Debug.Log("id:" + k.ID);
                //Debug.Log("transform:" + k.TileObject.transform.position);
                /*

                */


            }
            // 如果点击的ID不同，或者t大于5，重置t为0
            if (count >= 5)
            {
                count = 0; // 重置t为0
            }
        }
    }

    // 处理点击的地块
    public void HandleTileClick(TileInfo tileInfo)
    {
        // 获取地块名称和层级类型
        string tileName = tileInfo.TileObject.name;
        string imageName = tileInfo.TileObject.GetComponent<SpriteRenderer>().sprite.name;
        int layerType = (int)tileInfo.Layer;

        // 根据层级类型处理不同的地块
        switch (tileInfo.Layer)
        {
            case TileInfo.LayerType.Desert:
                Debug.Log("右键点击了沙漠地块");
                break;

            case TileInfo.LayerType.边墙:
                Debug.Log("右键点击了边墙地块");
                break;

            case TileInfo.LayerType.虚空:
                Debug.Log("右键点击了虚空地块");
                break;

            default:
                break;
        }

        // 触发事件，传递图片名称和层级类型
        OnTileClicked?.Invoke(imageName, layerType);
    }

    // 检查鼠标是否在当前地块上
    public bool IsMouseOverTile(Vector3 mousePosition, GameObject TileObject)
    {
        if (TileObject is null)
        {
            return false;
        }
        Vector3 tilePosition = TileObject.transform.position;
        SpriteRenderer spriteRenderer = TileObject.GetComponent<SpriteRenderer>();

        // 获取地块的边界
        Vector2 tileSize = spriteRenderer.bounds.size;

        // 检查鼠标位置是否在地块范围内，包含 z 轴的判断
        return mousePosition.x >= tilePosition.x - tileSize.x / 2 &&
               mousePosition.x <= tilePosition.x + tileSize.x / 2 &&
               mousePosition.y >= tilePosition.y - tileSize.y / 2 &&
               mousePosition.y <= tilePosition.y + tileSize.y / 2 &&
               Mathf.Abs(mousePosition.z - tilePosition.z) < 0.1f; // z轴的匹配
    }
    // 检查鼠标是否在当前地块上
    public bool IsMouseOverTileNotZ(Vector3 mousePosition, GameObject TileObject)
    {
        if (TileObject is null)
        {
            return false;
        }
        Vector3 tilePosition = TileObject.transform.position;
        SpriteRenderer spriteRenderer = TileObject.GetComponent<SpriteRenderer>();

        // 获取地块的边界
        Vector2 tileSize = spriteRenderer.bounds.size;

        // 检查鼠标位置是否在地块范围内，包含 z 轴的判断
        return mousePosition.x >= tilePosition.x - tileSize.x / 2 &&
               mousePosition.x <= tilePosition.x + tileSize.x / 2 &&
               mousePosition.y >= tilePosition.y - tileSize.y / 2 &&
               mousePosition.y <= tilePosition.y + tileSize.y / 2;
               
    }
}
