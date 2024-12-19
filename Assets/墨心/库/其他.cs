using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace 墨心 {
    public static partial class GameManager {
        public static Sprite LoadSprite(string path) => Resources.Load<Sprite>(path) ?? throw new System.Exception($"图片不存在：{path}");
        public static T Choice<T>(params T[] X) => X[UnityEngine.Random.Range(0, X.Length)];
        public static void Print(string X) => Debug.Log(X);
        public static GameObject _MainCamera;
        public static GameObject MainCamera => _MainCamera ?? (_MainCamera = Camera.main.gameObject);
    }
}