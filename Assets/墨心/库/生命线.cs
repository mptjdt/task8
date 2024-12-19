using System;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static Action OnAppUpdateCallback;
        public static void OnAppUpdate(Action callback) {
            if (MainCamera.GetComponent<LifeLine>() == null) {
                MainCamera.AddComponent<LifeLine>();
            }
            OnAppUpdateCallback += callback;
        }
    }
    public class LifeLine : MonoBehaviour {
        void Update() {
            墨心.GameManager.OnAppUpdateCallback?.Invoke();
        }
        void OnDestroy() {
            墨心.Event.游戏退出();
        }
    }
}