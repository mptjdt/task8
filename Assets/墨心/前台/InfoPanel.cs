using UnityEngine;
using UnityEngine.UI;

namespace 墨心 {
    public class InfoPanel : MonoBehaviour {
        private GameObject panel;
        public void CreateInfoPanel() {           
            GameObject canvasObj = new GameObject("Canvas");
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            GraphicRaycaster raycaster = canvasObj.AddComponent<GraphicRaycaster>();// 创建 Canvas 对象           
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;// 设置 Canvas 以屏幕空间渲染           
            panel = new GameObject("InfoPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();// 创建信息面板对象
            panelRectTransform.sizeDelta = new Vector2(120, 60); // 设置面板大小          
            panelRectTransform.anchorMin = new Vector2(1, 1);
            panelRectTransform.anchorMax = new Vector2(1, 1); // 设置面板的锚点到右上角
            panelRectTransform.anchoredPosition = new Vector2(-30, -30); // 向左偏移30，向下偏移30         
            Image panelImage = panel.AddComponent<Image>(); // 添加背景图像
            panelImage.color = Color.white; // 背景颜色          
            GameObject textObject = new GameObject("InfoText");
            Text infoText = textObject.AddComponent<Text>();// 创建文本框
            infoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // 使用内置字体
            infoText.fontSize = 14; // 字体大小
            infoText.color = Color.black; // 字体颜色为黑色
            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.SetParent(panel.transform, false);
            textRectTransform.sizeDelta = new Vector2(110, 50); // 设置文本框大小
            textRectTransform.anchoredPosition = Vector2.zero; // 居中          
            panel.transform.SetParent(canvas.transform, false);// 设置信息面板为 Canvas 的子对象
        }
        // 显示信息面板
        public void ShowInfoPanel() {
            if (panel != null){
                panel.SetActive(true); // 激活面板
            }
        }
        // 隐藏信息面板
        public void HideInfoPanel() {
            if (panel != null){
                panel.SetActive(false); // 隐藏面板
            }
        }
    }
}
