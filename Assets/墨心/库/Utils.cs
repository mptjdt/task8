using System;
using UnityEngine;
using UnityEngine.UI;

namespace 墨心 {
    // 工具文件
    public static partial class GameManager {
        public static Sprite LoadSprite(string path) => Resources.Load<Sprite>(path) ?? throw new System.Exception($"图片不存在：{path}");
        public static T Choice<T>(params T[] X) => X[UnityEngine.Random.Range(0, X.Length)];
        public static void Print(string X) => Debug.Log(X);
        public static GameObject _MainCamera;
        public static GameObject MainCamera => _MainCamera ?? (_MainCamera = Camera.main.gameObject);
        public static Canvas _MainPanel;
        public static Canvas MainPanel => _MainPanel ?? (_MainPanel = new GameObject("MainPanel").AddComponent<Canvas>());
        public static void SetColor(this GameObject obj, Color color) {
            obj.GetComponent<Image>().color = color;
        }
        public static void SetText(this GameObject obj, string text) {
            var A = obj.GetComponentInChildren<Text>();
            var 文本框属性 = A.GetComponent<RectTransform>();
            文本框属性.anchorMin = 文本框属性.anchorMax = new Vector2(0, 0);
            文本框属性.sizeDelta = obj.GetComponent<RectTransform>().sizeDelta;
            文本框属性.anchoredPosition = Vector2.zero;
            A.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            A.color = Color.black;
            A.fontSize = 14;
            A.text = text;
        }
        public static GameObject 创建矩形(this Canvas canvas, float 左, float 上, float 宽度, float 高度) {
            var 矩形 = new GameObject("矩形");
            Text text = new GameObject("文本框").AddComponent<Text>();
            var 矩形属性 = 矩形.AddComponent<RectTransform>();
            矩形.AddComponent<Image>();
            矩形.transform.SetParent(canvas.transform, false);
            text.transform.SetParent(矩形.transform, false);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            矩形属性.anchorMin = 矩形属性.anchorMax = new Vector2(1, 1);
            矩形属性.sizeDelta = new Vector2(Screen.width * 宽度, Screen.height * 高度);
            矩形属性.anchoredPosition = new Vector2(-Screen.width * 左, -Screen.height * 上);
            return 矩形;
        }
        public static Action OnAppUpdateCallback;
        public static void OnAppUpdate(Action callback) {
            if (MainCamera.GetComponent<AppUpdate>() == null) {
                MainCamera.AddComponent<AppUpdate>();
            }
            OnAppUpdateCallback += callback;
        }
    }
    public class AppUpdate : MonoBehaviour {
        void Update() {
            墨心.GameManager.OnAppUpdateCallback?.Invoke();
        }
    }
}