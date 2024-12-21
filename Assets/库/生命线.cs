using System;
using UnityEngine;

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
    }
}