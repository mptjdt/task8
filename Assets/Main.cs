using UnityEngine;

public class Main : MonoBehaviour {
    public void Start() {
        墨心.GameManager.MainStart();  // 启动游戏管理器
    }
    public void Update() {
        墨心.GameManager.OnAppUpdateCallback?.Invoke();
    }
}