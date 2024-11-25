using UnityEngine;
using UnityEngine.UI;

namespace 墨心 {
    public class InfoPanel : MonoBehaviour {
        public GameObject panel;
        public GameObject CreateInfoPanel() {           
            Canvas canvas = new GameObject("Canvas").AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;// 创建 Canvas 并设置渲染模式           
            GameObject panel = new GameObject("Panel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();// 创建信息面板并设置属性
            panelRectTransform.sizeDelta = new Vector2(120, 60); // 面板大小
            panelRectTransform.anchorMin = panelRectTransform.anchorMax = new Vector2(1, 1); // 锚点设置为右上角
            panelRectTransform.anchoredPosition = new Vector2(-30, -30); // 偏移位置
            Image panelImage = panel.AddComponent<Image>();// 添加背景图像
            panelImage.color = Color.white; // 设置背景颜色为白色         
            Text infoText = new GameObject("InfoText").AddComponent<Text>(); // 创建并设置文本框
            infoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            infoText.fontSize = 14; // 字体大小
            infoText.color = Color.black; // 字体颜色
            RectTransform textRectTransform = infoText.GetComponent<RectTransform>();
            textRectTransform.SetParent(panel.transform, false); // 将文本框作为面板的子物体
            textRectTransform.sizeDelta = new Vector2(110, 50); // 文本框大小
            textRectTransform.anchoredPosition = Vector2.zero; // 文本框居中           
            panel.transform.SetParent(canvas.transform, false);// 设置面板的父物体为 Canvas
            return panel;
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
    public static partial class GameManager {
        public static void 修改信息面板(string SoilType, int 数量) {
            PanelInstance.panel.GetComponentInChildren<Text>().text = $"土壤类型: {SoilType}\n数量: {数量}";
        }
    }
}
