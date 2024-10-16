using UnityEngine;
using UnityEngine.UI;
namespace ī��main // ��������ռ�
{
    public class InventoryPanel : MonoBehaviour
    {
        private GameObject panel; // �������
        private GameObject background; // ����
        private GameObject grid; // ����
        private InventoryManager inventoryManager; // ���ñ���������

        public Color backgroundColor = Color.grey; // ������ɫ
        public int rows = 4; // ��������
        public int columns = 5; // ��������
        public float cellSize = 80f; // ÿ�����ӵĴ�С

        private bool isPanelVisible = false; // ��������Ƿ�ɼ�

        private void Start()
        {

            CreateCanvas(); // ���� Canvas
            CreateInventoryPanel(); // �����������
            CreateBackground(); // ��������
            CreateGrid(); // ��������
            HidePanel(); // ��ʼʱ�������

            inventoryManager = InventoryManager.Instance; // ��ȡ����������ʵ��
            inventoryManager.OnInventoryChanged += UpdateInventoryUI; // �����¼�
        }

        private void CreateCanvas()
        {
            // ����һ���µ� Canvas
            GameObject canvas = new GameObject("Canvas");
            Canvas canvasComponent = canvas.AddComponent<Canvas>();
            canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;

            // ���� CanvasScaler ���
            CanvasScaler canvasScaler = canvas.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            // ���� GraphicRaycaster ���
            canvas.AddComponent<GraphicRaycaster>();
        }

        private void CreateInventoryPanel()
        {
            // �������
            panel = new GameObject("InventoryPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(400, 600); // ��������С
            panelRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // ����ê��
            panelRectTransform.anchorMax = new Vector2(0.5f, 0.5f); // ����ê��
            panelRectTransform.anchoredPosition = Vector2.zero; // λ��������

            // �������Ϊ UI Ԫ��
            panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }

        private void CreateBackground()
        {
            // ��������
            background = new GameObject("Background");
            RectTransform backgroundRectTransform = background.AddComponent<RectTransform>();
            backgroundRectTransform.sizeDelta = new Vector2(400, 600); // ���ô�С�����һ��
            backgroundRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // ����ê��
            backgroundRectTransform.anchorMax = new Vector2(0.5f, 0.5f); // ����ê��
            backgroundRectTransform.anchoredPosition = Vector2.zero; // λ��������

            // ��ӱ���ͼ��
            Image backgroundImage = background.AddComponent<Image>();
            backgroundImage.color = backgroundColor; // ʹ�����õı�����ɫ

            // ���ñ���Ϊ�����Ӷ���
            background.transform.SetParent(panel.transform, false);
        }

        private void CreateGrid()
        {
            // �����������
            grid = new GameObject("Grid");
            RectTransform gridRectTransform = grid.AddComponent<RectTransform>();
            gridRectTransform.sizeDelta = new Vector2(400, 600); // �����С
            gridRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // ����ê��
            gridRectTransform.anchorMax = new Vector2(0.5f, 0.5f); // ����ê��
            gridRectTransform.anchoredPosition = Vector2.zero; // λ��������

            // ��� GridLayoutGroup ���
            GridLayoutGroup gridLayout = grid.AddComponent<GridLayoutGroup>();
            gridLayout.cellSize = new Vector2(cellSize, cellSize); // ���ø��Ӵ�С
            gridLayout.spacing = new Vector2(5, 5); // ���ø��Ӽ��
            gridLayout.startCorner = GridLayoutGroup.Corner.UpperLeft; // �����Ͻǿ�ʼ
            gridLayout.startAxis = GridLayoutGroup.Axis.Horizontal; // ˮƽ����
            gridLayout.childAlignment = TextAnchor.MiddleCenter; // ��Ԫ�ض��뷽ʽ

            // ����������Ϊ�����Ӷ���
            grid.transform.SetParent(panel.transform, false);

            // ��������
            for (int i = 0; i < rows * columns; i++)
            {
                GameObject cell = new GameObject($"Cell_{i + 1}");
                RectTransform cellRectTransform = cell.AddComponent<RectTransform>();
                cellRectTransform.sizeDelta = new Vector2(cellSize, cellSize); // ���ø��Ӵ�С

                // ��Ӱ�ɫ����
                Image cellImage = cell.AddComponent<Image>();
                cellImage.color = Color.white; // ����Ϊ��ɫ

                // ����������Ϊ������Ӷ���
                cell.transform.SetParent(grid.transform, false);
            }
        }

        public void TogglePanel() // ȷ�� TogglePanel Ϊ public
        {
            isPanelVisible = !isPanelVisible; // �л��ɼ�״̬
            panel.SetActive(isPanelVisible); // �������ļ���״̬
            background.SetActive(isPanelVisible); // ͬʱ���Ʊ����Ŀɼ�״̬
        }

        private void HidePanel()
        {
            panel.SetActive(false); // �������
            background.SetActive(false); // ���ر���
        }


        private void UpdateInventoryUI()
        {
            // ������и���
            foreach (Transform child in grid.transform)
            {
                Destroy(child.gameObject); // ɾ����ǰ����
            }

            // ���� inventoryManager �е���Ʒ�������ɸ���
            foreach (var item in inventoryManager.items) // �ӱ����������л�ȡÿ����Ʒ
            {
                GameObject cell = new GameObject($"Cell_{item.Name}"); // �����µĸ���
                RectTransform cellRectTransform = cell.AddComponent<RectTransform>();
                cellRectTransform.sizeDelta = new Vector2(cellSize, cellSize); // ���ø��Ӵ�С
                cellRectTransform.SetParent(grid.transform, false); // ����������Ϊ������Ӷ���

                // ���ͼ�����������ͼ��
                Image cellImage = cell.AddComponent<Image>();



                // ������Ʒͼ������Ϊ���ӵı���
                Sprite itemSprite = Resources.Load<Sprite>(item.Name); // ���� item.name Ϊ·���ַ���
                cellImage.sprite = itemSprite; // ����Ϊ��Ʒͼ��
                cellImage.preserveAspect = true; // ����ͼ��Ŀ�߱�


            }

            // ��������ĸ��ӣ������Ҫ��ʹ�� rows �� columns
            int r = 4; // ��������
            int c = 5; // ��������
            int itemCount = inventoryManager.items.Count; // ��ȡ��Ʒ����
            for (int i = 0; i < r * c - inventoryManager.items.Count; i++)
            {
                GameObject extraCell = new GameObject($"ExtraCell_{i + 1}"); // ��������ĸ���
                RectTransform extraCellRectTransform = extraCell.AddComponent<RectTransform>();
                extraCellRectTransform.sizeDelta = new Vector2(cellSize, cellSize); // ���ø��Ӵ�С

                // ��Ӱ�ɫ����
                Image extraCellImage = extraCell.AddComponent<Image>();
                extraCellImage.color = Color.white; // ����Ϊ��ɫ

                // �������������Ϊ������Ӷ���
                extraCell.transform.SetParent(grid.transform, false);
            }



        }



    }
}




