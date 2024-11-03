using UnityEngine;

namespace 墨心
{
    public class FrontendWorld : MonoBehaviour
    {
        private Sprite desertSprite;

        // 构造函数，接收 World 实例
        public FrontendWorld(World worldInstance)
        {
            // 加载沙漠精灵
            desertSprite = Resources.Load<Sprite>("desert");  // 从 Resources 文件夹加载名为 "desert" 的 Sprite
            if (desertSprite == null)  // 检查沙漠精灵是否成功加载
            {
                UnityEngine.Debug.LogError("Desert sprite could not be found in Resources folder!");  // 记录错误信息
            }

            DisplayTiles(worldInstance);  // 调用显示地块的方法
        }

        // 显示地图上的所有地块
        private void DisplayTiles(World world)  // 将 World 实例作为参数
        {
            int gridWidth = world.Grid.GetLength(0);  // 获取地图的宽度（行数）
            int gridHeight = world.Grid.GetLength(1);  // 获取地图的高度（列数）

            // 双重循环遍历地图的每个位置
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    CreateTileUI(x, y);  // 为每个地块创建用户界面
                }
            }
        }

        // 创建一个特定坐标的地块用户界面
        private void CreateTileUI(int x, int y)
        {
            GameObject tileObj = new GameObject("Tile_" + x + "_" + y);  // 创建一个新的 GameObject，命名为 "Tile_x_y"
            tileObj.transform.position = new Vector3(x, y, 0);  // 设置地块的位置

            // 设置沙漠精灵
            SpriteRenderer spriteRenderer = tileObj.AddComponent<SpriteRenderer>();  // 为地块对象添加 SpriteRenderer 组件
            spriteRenderer.sprite = desertSprite;  // 将沙漠精灵赋值给 SpriteRenderer
        }
    }
}
