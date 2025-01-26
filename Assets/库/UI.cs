using UnityEngine.UI;
using UnityEngine;

namespace 墨心 {
    public static partial class LocalStorage {
        public static Canvas _MainPanel;
        public static Canvas MainPanel => _MainPanel ?? (_MainPanel = new GameObject("MainPanel").AddComponent<Canvas>());
        public static GameObject SetColor(this GameObject obj, Color color) {
            var A = new GameObject("背景").AddComponent<Image>();
            A.transform.SetParent(obj.transform, false);
            var 背景属性 = A.GetComponent<RectTransform>();
            背景属性.anchorMin = 背景属性.anchorMax = new Vector2(0, 0);
            背景属性.sizeDelta = obj.GetComponent<RectTransform>().sizeDelta;
            背景属性.anchoredPosition = Vector2.zero;
            A.color = color;
            return obj;
        }
        public static GameObject SetColorDirectly(this GameObject obj, Color color) {
            (obj.GetComponent<Image>() ?? obj.AddComponent<Image>()).color = color;
            return obj;
        }
        public static GameObject SetGrid(this GameObject obj,int 列数=4,int 行数=5) {
            var A = obj.GetComponent<GridLayoutGroup>() ?? obj.AddComponent<GridLayoutGroup>();
            var B = obj.GetComponent<RectTransform>();
            A.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            A.constraintCount = 列数;
            A.spacing = new Vector2(0, 0);
            A.cellSize = new Vector2(B.rect.width/列数, B.rect.height/行数);
            return obj;
        }
        public static GameObject SetText(this GameObject obj, string text) {
            var A = new GameObject("文本框").AddComponent<Text>();
            A.transform.SetParent(obj.transform, false);
            var 文本框属性 = A.GetComponent<RectTransform>();
            文本框属性.anchorMin = 文本框属性.anchorMax = new Vector2(0, 0);
            文本框属性.sizeDelta = obj.GetComponent<RectTransform>().sizeDelta;
            文本框属性.anchoredPosition = Vector2.zero;
            A.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            A.color = Color.black;
            A.fontSize = 14;
            A.text = text;
            return obj;
        }
        public static GameObject SetSprite(this GameObject obj,string X) {
            (obj.GetComponent<Image>() ?? obj.AddComponent<Image>()).sprite = Resources.Load<Sprite>(X);
            return obj;
        }
        public static GameObject 创建矩形(this Canvas canvas, float 左, float 上, float 宽度, float 高度) {
            var 矩形 = new GameObject("矩形");
            var 矩形属性 = 矩形.AddComponent<RectTransform>();
            矩形.transform.SetParent(canvas.transform, false);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            矩形属性.anchorMin = 矩形属性.anchorMax = new Vector2(1, 1);
            矩形属性.sizeDelta = new Vector2(Screen.width * 宽度, Screen.height * 高度);
            矩形属性.anchoredPosition = new Vector2(-Screen.width * 左, -Screen.height * 上);
            return 矩形;
        }
        public static GameObject 创建矩形(this GameObject obj) {
            var 矩形 = new GameObject("矩形");
            var 矩形属性 = 矩形.AddComponent<RectTransform>();
            矩形.transform.SetParent(obj.transform, false);
            return 矩形;
        }
        public static void Clear(this GameObject obj) {
            foreach (Transform child in obj.transform) {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}