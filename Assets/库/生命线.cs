using System;
using UnityEngine;
using System.Collections;

namespace 墨心 {
    public static partial class GameManager {
        public static Action OnAppUpdateCallback;
        public static void OnAppUpdate(Action X) {
            EnsureLifeLineComponent();
            OnAppUpdateCallback += X;
        }
        public static Action OnAppDestroyCallback;
        public static void OnAppDestroy(Action X) {
            EnsureLifeLineComponent();
            OnAppDestroyCallback += X;
        }      
        public static void OnAppSeconds(float X, Action Y) {
            EnsureLifeLineComponent();
            MainCamera.GetComponent<LifeLine>().StartCoroutine(MainCamera.GetComponent<LifeLine>().OnAppSecondsCoroutine(X, Y));
        }
        private static void EnsureLifeLineComponent() {
            if (MainCamera.GetComponent<LifeLine>() == null) {
                MainCamera.AddComponent<LifeLine>();
            }
        }
    }
    public class LifeLine : MonoBehaviour {
        public void Update() {
            GameManager.OnAppUpdateCallback?.Invoke();
        }
        public void OnDestroy() {
            GameManager.OnAppDestroyCallback?.Invoke();
        }
        public IEnumerator OnAppSecondsCoroutine(float X , Action Y) {
            while (true) {
                yield return new WaitForSeconds(X);
                Y.Invoke();
            }
        }
    }
}