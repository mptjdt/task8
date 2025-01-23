using UnityEngine;
using UnityEngine.UI;

namespace ī��8A2
{
    public class InfoPanel : MonoBehaviour
    {
        private Text infoText; // ��ʾ��Ϣ���ı���
        private GameObject panel; // ��Ϣ������
        private GameObject canvasObject; // ��������

        private void Start()
        {
            CreateCanvas(); // ��������
            CreatePanel(); // ������Ϣ���
            CreateBackground(); // ��������
            CreateTextBox(); // �����ı���

            // ���ĵؿ����¼�
            Main.OnTileClicked += UpdateInfo;
            HideInfoPanel(); // ��ʼ״̬������Ϣ���
        }

        // ��������
        private void CreateCanvas()
        {
            canvasObject = new GameObject("InfoCanvas");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay; // ����Ϊ��Ļ�ռ�

            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize; // ������Ļ�ߴ�
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        // ������Ϣ���
        private void CreatePanel()
        {
            panel = new GameObject("InfoPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(120, 60); // ��������С
            panelRectTransform.anchorMin = new Vector2(1, 1);
            panelRectTransform.anchorMax = new Vector2(1, 1);
            panelRectTransform.anchoredPosition = new Vector2(-70, -35); // ƫ��λ��

            // ���������Ϊ�������Ӷ���
            panel.transform.SetParent(canvasObject.transform, false);
        }

        // ��ӱ���ͼ��
        private void CreateBackground()
        {
            Image panelImage = panel.AddComponent<Image>();
            panelImage.color = Color.white; // ������ɫ
        }

        // �����ı���
        private void CreateTextBox()
        {
            GameObject textObject = new GameObject("InfoText");
            infoText = textObject.AddComponent<Text>();
            infoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // ʹ����������
            infoText.fontSize = 14; // �����С
            infoText.color = Color.black; // ������ɫΪ��ɫ

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.SetParent(panel.transform, false);
            textRectTransform.sizeDelta = new Vector2(110, 50); // �����ı����С
            textRectTransform.anchoredPosition = Vector2.zero; // ����
        }

        // �����յ��ؿ����¼�ʱ�������ı�������
        private void UpdateInfo(string imageName, int layerType) // layerType ���ͱ���Ϊ int
        {
            if (infoText != null && panel != null)
            {
                infoText.text = $"�㼶: {layerType}\nͼƬ����: {imageName}"; // �����ı�������
                ShowInfoPanel(); // ��ʾ��Ϣ���
            }
        }


        private void ShowInfoPanel()
        {
            if (panel != null)
            {
                panel.SetActive(true); // ��ʾ��Ϣ���
            }
        }

        private void HideInfoPanel()
        {
            if (panel != null)
            {
                panel.SetActive(false); // ������Ϣ���
            }
        }

        private void OnDestroy()
        {
            TileClickHandler.OnTileClicked -= UpdateInfo; // ȡ���¼�����
        }
    }
}
