using UnityEngine;
using UnityEngine.UI;
namespace ī��main // ��������ռ�
{
    public class InfoPanel : MonoBehaviour
    {
        private Text infoText; // ��ʾ��Ϣ���ı���
        private int desertCount = -1; // ɳĮ������������ʾΪ -1
        private int stoneCount = 100; // ʯͷ��������ʼΪ 100
        private GameObject panel; // ��Ϣ������

        private void Start()
        {
            CreateInfoPanel(); // ������Ϣ���
            UpdateInfoText(); // ��ʼʱ������Ϣ��������

            // ���ĵؿ����¼�
            TileClickHandler.OnTileClicked += UpdateInfo;
        }

        private void CreateInfoPanel()
        {
            // ������Ϣ������
            panel = new GameObject("InfoPanel");
            RectTransform panelRectTransform = panel.AddComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(120, 60); // ��������С

            // ��������ê�㵽���Ͻ�
            panelRectTransform.anchorMin = new Vector2(1, 1);
            panelRectTransform.anchorMax = new Vector2(1, 1);
            panelRectTransform.anchoredPosition = new Vector2(-30, -30); // ����ƫ��30������ƫ��30

            // ��ӱ���ͼ��
            Image panelImage = panel.AddComponent<Image>();
            panelImage.color = Color.white; // ������ɫ

            // �����ı���
            GameObject textObject = new GameObject("InfoText");
            infoText = textObject.AddComponent<Text>();
            infoText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // ʹ����������
            infoText.fontSize = 14; // �����С
            infoText.color = Color.black; // ������ɫΪ��ɫ

            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.SetParent(panel.transform, false);
            textRectTransform.sizeDelta = new Vector2(110, 50); // �����ı����С
            textRectTransform.anchoredPosition = Vector2.zero; // ����

            // ������Ϣ���Ϊ�����е��Ӷ���
            panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }

        public void UpdateInfo(string tileType)
        {
            if (tileType == "stone") // ���ʯͷʱ��������
            {
                if (stoneCount > 0)
                {
                    stoneCount--; // ÿ��ʹ��ʯͷ������1
                }
            }

            // ������ʾ��Ϣ
            UpdateInfoText(); // �����ı�����
        }

        private void UpdateInfoText()
        {
            // ������ʾ��Ϣ
            string message = $"ɳĮ����: {desertCount}, ʯͷ����: {stoneCount}";
            infoText.text = message; // �����ı�����
            ShowInfoPanel(); // ��ʾ��Ϣ���
        }

        private void ShowInfoPanel()
        {
            panel.SetActive(true); // ��ʾ��Ϣ���
        }

        private void HideInfoPanel()
        {
            panel.SetActive(false); // ������Ϣ���
        }

        private void OnDestroy()
        {
            // ȡ�������¼�
            TileClickHandler.OnTileClicked -= UpdateInfo;
        }
    }
}