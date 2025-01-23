using UnityEngine;
using UnityEngine.UI;
namespace 墨心main // 添加命名空间
{
    public class InventoryPanel : MonoBehaviour
    {
        private GameObject panel; // 背包面板
        private GameObject background; // 背景
        private GameObject grid; // 网格
        private InventoryManager inventoryManager; // 引用背包管理器

        public Color backgroundColor = Color.grey; // 背景颜色
        public int rows = 4; // 网格行数
        public int columns = 5; // 网格列数
        public float cellSize = 80f; // 每个格子的大小

        private bool isPanelVisible = false; // 背包面板是否可见

        private void Start()
        {

            CreateCanvas(); // 创建 Canvas
            CreateInventoryPanel(); // 创建背包面板
            CreateBackground(); // 创建背景
            CreateGrid(); // 创建格子
            HidePanel(); // 初始时隐藏面板

            inventoryManager = InventoryManager.Instance; // 获取背包管理器实例
            inventoryManager.OnInventoryChanged += UpdateInventoryUI; // 订阅事件
        }

        private void CreateCanvas()
        {
            // 创建一个新的 Canvas
            GameObject canvas = new GameObject("Canvas");
            Canvas canvasComponent = canvas.AddComponent<Canvas>();
            canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;

            // 创建 CanvasScaler 组件
            CanvasScaler canvasScaler = canvas.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            // 创建 GraphicRaycaster 组件
            canvas.AddComponent<GraphicRaycaster>();
        }

        private void CreateInventoryPanel()
        {
            // 创建面板
            panel = new GameObject("InventoryPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(400, 600); // 设置面板大小
            panelRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // 中心锚点
            panelRectTransform.anchorMax = new Vector2(0.5f, 0.5f); // 中心锚点
            panelRectTransform.anchoredPosition = Vector2.zero; // 位置在中心

            // 设置面板为 UI 元素
            panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }

        private void CreateBackground()
        {
            // 创建背景
            background = new GameObject("Background");
            RectTransform backgroundRectTransform = background.AddComponent<RectTransform>();
            backgroundRectTransform.sizeDelta = new Vector2(400, 600); // 设置大小与面板一致
            backgroundRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // 中心锚点
            backgroundRectTransform.anchorMax = new Vector2(0.5f, 0.5f); // 中心锚点
            backgroundRectTransform.anchoredPosition = Vector2.zero; // 位置在中心

            // 添加背景图像
            Image backgroundImage = background.AddComponent<Image>();
            backgroundImage.color = backgroundColor; // 使用设置的背景颜色

            // 设置背景为面板的子对象
            background.transform.SetParent(panel.transform, false);
        }

        private void CreateGrid()
        {
            // 创建网格对象
            grid = new GameObject("Grid");
            RectTransform gridRectTransform = grid.AddComponent<RectTransform>();
            gridRectTransform.sizeDelta = new Vector2(400, 600); // 网格大小
            gridRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // 中心锚点
            gridRectTransform.anchorMax = new Vector2(0.5f, 0.5f); // 中心锚点
            gridRectTransform.anchoredPosition = Vector2.zero; // 位置在中心

            // 添加 GridLayoutGroup 组件
            GridLayoutGroup gridLayout = grid.AddComponent<GridLayoutGroup>();
            gridLayout.cellSize = new Vector2(cellSize, cellSize); // 设置格子大小
            gridLayout.spacing = new Vector2(5, 5); // 设置格子间隔
            gridLayout.startCorner = GridLayoutGroup.Corner.UpperLeft; // 从左上角开始
            gridLayout.startAxis = GridLayoutGroup.Axis.Horizontal; // 水平排列
            gridLayout.childAlignment = TextAnchor.MiddleCenter; // 子元素对齐方式

            // 将网格设置为面板的子对象
            grid.transform.SetParent(panel.transform, false);

            // 创建格子
            for (int i = 0; i < rows * columns; i++)
            {
                GameObject cell = new GameObject($"Cell_{i + 1}");
                RectTransform cellRectTransform = cell.AddComponent<RectTransform>();
                cellRectTransform.sizeDelta = new Vector2(cellSize, cellSize); // 设置格子大小

                // 添加白色背景
                Image cellImage = cell.AddComponent<Image>();
                cellImage.color = Color.white; // 设置为白色

                // 将方格设置为网格的子对象
                cell.transform.SetParent(grid.transform, false);
            }
        }

        public void TogglePanel() // 确保 TogglePanel 为 public
        {
            isPanelVisible = !isPanelVisible; // 切换可见状态
            panel.SetActive(isPanelVisible); // 设置面板的激活状态
            background.SetActive(isPanelVisible); // 同时控制背景的可见状态
        }

        private void HidePanel()
        {
            panel.SetActive(false); // 隐藏面板
            background.SetActive(false); // 隐藏背景
        }


        private void UpdateInventoryUI()
        {
            // 清空现有格子
            foreach (Transform child in grid.transform)
            {
                Destroy(child.gameObject); // 删除当前格子
            }

            // 根据 inventoryManager 中的物品重新生成格子
            foreach (var item in inventoryManager.items) // 从背包管理器中获取每个物品
            {
                GameObject cell = new GameObject($"Cell_{item.Name}"); // 创建新的格子
                RectTransform cellRectTransform = cell.AddComponent<RectTransform>();
                cellRectTransform.sizeDelta = new Vector2(cellSize, cellSize); // 设置格子大小
                cellRectTransform.SetParent(grid.transform, false); // 将格子设置为网格的子对象

                // 添加图像组件并设置图像
                Image cellImage = cell.AddComponent<Image>();



                // 加载物品图像并设置为格子的背景
                Sprite itemSprite = Resources.Load<Sprite>(item.Name); // 假设 item.name 为路径字符串
                cellImage.sprite = itemSprite; // 设置为物品图像
                cellImage.preserveAspect = true; // 保持图像的宽高比


            }

            // 创建额外的格子，如果需要，使用 rows 和 columns
            int r = 4; // 假设行数
            int c = 5; // 假设列数
            int itemCount = inventoryManager.items.Count; // 获取物品数量
            for (int i = 0; i < r * c - inventoryManager.items.Count; i++)
            {
                GameObject extraCell = new GameObject($"ExtraCell_{i + 1}"); // 创建额外的格子
                RectTransform extraCellRectTransform = extraCell.AddComponent<RectTransform>();
                extraCellRectTransform.sizeDelta = new Vector2(cellSize, cellSize); // 设置格子大小

                // 添加白色背景
                Image extraCellImage = extraCell.AddComponent<Image>();
                extraCellImage.color = Color.white; // 设置为白色

                // 将额外格子设置为网格的子对象
                extraCell.transform.SetParent(grid.transform, false);
            }



        }



    }
}




