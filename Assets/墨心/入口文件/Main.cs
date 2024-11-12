using UnityEngine;
using 墨心;

public class Main : MonoBehaviour{
    void Start(){
        GameManager.Mainstart();  // 启动游戏管理器
    }
    void Update(){
        GameManager.BindKeyCommands();
    }

}
