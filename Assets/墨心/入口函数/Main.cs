using UnityEngine;
using 墨心;

public class Main : MonoBehaviour{
    void Start(){
        GameManager.Mainstart();  // 启动游戏管理器

        // 创建一个 GameObject 并直接附加 PlayerController
        GameObject playerObject = new GameObject("PlayerController");
        playerObject.AddComponent<PlayerController>();  // 动态添加 PlayerController 脚本
    }
}
