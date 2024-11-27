using UnityEngine;

namespace 墨心 {
    // 工具文件
    public static partial class GameManager {
        // 加载精灵的静态方法
        public static Sprite LoadSprite(string path) => Resources.Load<Sprite>(path) ?? throw new System.Exception($"图片不存在：{path}");
        public static T Choice<T>(params T[] X) => X[Random.Range(0, X.Length)];
        public static void Print(string X) => Debug.Log(X);
        public static GameObject _MainCamera;
        public static GameObject MainCamera => _MainCamera ?? (_MainCamera = Camera.main.gameObject);
    }
}