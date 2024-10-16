using UnityEngine;
using UnityEngine.UI;
namespace 墨心main // 添加命名空间
{
    public class InfoPanel : MonoBehaviour
    {
        private Text infoText; // 显示信息的文本框
        private int desertCount = -1; // 沙漠数量，无穷大表示为 -1
        private int stoneCount = 100; // 石头数量，初始为 100
        private GameObject panel; // 信息面板对象

        private void Start()
        {
            CreateInfoPanel(); // 创建信息面板
            UpdateInfoText(); // 初始时更新信息面板的文字

            // 订阅地块点击事件
            TileClickHandler.OnTileClicked += UpdateInfo;
        }

        private void CreateInfoPanel()
        {
            // 创建信息面板对象
            panel = new GameObject("InfoPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(120, 60); // 设置面板大小

            // 设置面板的锚点到右上角
            panelRectTransform.anchorMin = new Vector2(1, 1);
            panelRectTransform.anchorMax = new Vector2(1, 1);
            panelRectTransform.anchoredPosition = new Vector2(-30, -30); // 向左偏移30，向下偏移30

            // 添加背景图像
            Image panelImage = panel.AddComponent<Image>();
            panelImage.color = Color.white; // 背景颜色

            // 创建文本框
            GameObject textObject = new GameObject("InfoText");
            infoText = textObject.AddComponent<Text>();
            infoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // 使用内置字体
            infoText.fontSize = 14; // 字体大小
            infoText.color = Color.black; // 字体颜色为黑色

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.SetParent(panel.transform, false);
            textRectTransform.sizeDelta = new Vector2(110, 50); // 设置文本框大小
            textRectTransform.anchoredPosition = Vector2.zero; // 居中

            // 设置信息面板为场景中的子对象
            panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }

        public void UpdateInfo(string tileType)
        {
            if (tileType == "stone") // 点击石头时减少数量
            {
                if (stoneCount > 0)
                {
                    stoneCount--; // 每次使用石头数量减1
                }
            }

            // 更新显示信息
            UpdateInfoText(); // 更新文本内容
        }

        private void UpdateInfoText()
        {
            // 更新显示信息
            string message = $"沙漠数量: {desertCount}, 石头数量: {stoneCount}";
            infoText.text = message; // 更新文本内容
            ShowInfoPanel(); // 显示信息面板
        }

        private void ShowInfoPanel()
        {
            panel.SetActive(true); // 显示信息面板
        }

        private void HideInfoPanel()
        {
            panel.SetActive(false); // 隐藏信息面板
        }

        private void OnDestroy()
        {
            // 取消订阅事件
            TileClickHandler.OnTileClicked -= UpdateInfo;
        }
    }
}