using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;

namespace 墨心 {
    public static partial class GameManager {
        public static Sprite LoadSprite(string path) => Resources.Load<Sprite>(path) ?? throw new System.Exception($"图片不存在：{path}");
        public static T Choice<T>(params T[] X) => X[UnityEngine.Random.Range(0, X.Length)];
        public static void Print(string X) => Debug.Log(X);
        public static GameObject _MainCamera;
        public static GameObject MainCamera => _MainCamera ?? (_MainCamera = Camera.main.gameObject);
        public static void Tremble(this GameObject obj) {
            float[] array = new float[] { 0,0.2f,0.4f,0.6f,0.8f,1,0.8f,0.6f,0.4f,0.2f,0};
            var A = obj.GetComponent<SpriteRenderer>().transform.localScale;
            for (int i = 0; i < array.Length; i++) {
                obj.GetComponent<SpriteRenderer>().transform.localScale = Vector3.Lerp(A, A * 0.01f, array[i]);
            }
        }
    }
    public class Timer {
        private float 当前时间 = 0f;
        public void Update(float X, Action Y) {
            当前时间 += Time.deltaTime;
            if (当前时间 >= X) {
                Y?.Invoke();
                当前时间 = 0f;
            }
        }
    }
}