using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace 墨心 {
    public static partial class GameManager {
        public static Sprite LoadSprite(string path) => Resources.Load<Sprite>(path) ?? throw new System.Exception($"图片不存在：{path}");
        public static T Choice<T>(params T[] X) => X[UnityEngine.Random.Range(0, X.Length)];
        public static void Print(string X) => Debug.Log(X);
        public static GameObject _MainCamera;
        public static GameObject MainCamera => _MainCamera ?? (_MainCamera = Camera.main.gameObject);
        public static void Tremble(this GameObject obj) {
            obj.GetComponent<SpriteRenderer>().transform.localScale = Vector3.Lerp(obj.GetComponent<SpriteRenderer>().transform.localScale, obj.GetComponent<SpriteRenderer>().transform.localScale * 0.25f, Time.deltaTime * 5f);
            obj.GetComponent<SpriteRenderer>().transform.localScale = Vector3.Lerp(obj.GetComponent<SpriteRenderer>().transform.localScale, Vector3.one, Time.deltaTime * 5f);
        }
    }
    public class Timer {
        private float elapsedTime = 0f;
        public void Update(float interval, Action callback) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= interval) {
                callback?.Invoke();
                elapsedTime = 0f;
            }
        }
    }
}