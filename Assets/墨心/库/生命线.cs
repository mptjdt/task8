using System;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static Action OnAppUpdateCallback;
        public static void OnAppUpdate(Action callback) {
            EnsureLifeLineComponent();
            OnAppUpdateCallback += callback;
        }
        public static Action OnAppDestroyCallback;
        public static void OnAppDestroy(Action callback) {
            EnsureLifeLineComponent();
            OnAppDestroyCallback += callback;
        }
        private static void EnsureLifeLineComponent() {
            if (MainCamera.GetComponent<LifeLine>() == null) {
                MainCamera.AddComponent<LifeLine>();
            }
        }
    }
    public class LifeLine : MonoBehaviour {
        void Update() {
            墨心.GameManager.OnAppUpdateCallback?.Invoke();
        }
        void OnDestroy() {
            墨心.GameManager.OnAppDestroyCallback?.Invoke();
        }
    }
}