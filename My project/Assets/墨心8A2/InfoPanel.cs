using UnityEngine;
using UnityEngine.UI;

namespace 墨心8A2
{
    public class InfoPanel : MonoBehaviour
    {
        private Text infoText; // 显示信息的文本框
        private GameObject panel; // 信息面板对象
        private GameObject canvasObject; // 画布对象

        private void Start()
        {
            CreateCanvas(); // 创建画布
            CreatePanel(); // 创建信息面板
            CreateBackground(); // 创建背景
            CreateTextBox(); // 创建文本框

            // 订阅地块点击事件
            Main.OnTileClicked += UpdateInfo;
            HideInfoPanel(); // 初始状态隐藏信息面板
        }

        // 创建画布
        private void CreateCanvas()
        {
            canvasObject = new GameObject("InfoCanvas");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay; // 设置为屏幕空间

            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize; // 适配屏幕尺寸
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        // 创建信息面板
        private void CreatePanel()
        {
            panel = new GameObject("InfoPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(120, 60); // 设置面板大小
            panelRectTransform.anchorMin = new Vector2(1, 1);
            panelRectTransform.anchorMax = new Vector2(1, 1);
            panelRectTransform.anchoredPosition = new Vector2(-70, -35); // 偏移位置

            // 将面板设置为画布的子对象
            panel.transform.SetParent(canvasObject.transform, false);
        }

        // 添加背景图像
        private void CreateBackground()
        {
            Image panelImage = panel.AddComponent<Image>();
            panelImage.color = Color.white; // 背景颜色
        }

        // 创建文本框
        private void CreateTextBox()
        {
            GameObject textObject = new GameObject("InfoText");
            infoText = textObject.AddComponent<Text>();
            infoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // 使用内置字体
            infoText.fontSize = 14; // 字体大小
            infoText.color = Color.black; // 字体颜色为黑色

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.SetParent(panel.transform, false);
            textRectTransform.sizeDelta = new Vector2(110, 50); // 设置文本框大小
            textRectTransform.anchoredPosition = Vector2.zero; // 居中
        }

        // 当接收到地块点击事件时，更新文本框内容
        private void UpdateInfo(string imageName, int layerType) // layerType 类型保持为 int
        {
            if (infoText != null && panel != null)
            {
                infoText.text = $"层级: {layerType}\n图片名称: {imageName}"; // 更新文本框内容
                ShowInfoPanel(); // 显示信息面板
            }
        }


        private void ShowInfoPanel()
        {
            if (panel != null)
            {
                panel.SetActive(true); // 显示信息面板
            }
        }

        private void HideInfoPanel()
        {
            if (panel != null)
            {
                panel.SetActive(false); // 隐藏信息面板
            }
        }

        private void OnDestroy()
        {
            TileClickHandler.OnTileClicked -= UpdateInfo; // 取消事件订阅
        }
    }
}
