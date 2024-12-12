using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static 后台世界类 后台世界 = new();
        public static 世界系统 前台世界 = new();
        public static UI系统 信息面板 = new();
        public static 后台背包类 后台背包 = new();
        public static 背包系统 背包面板 = new();
        public static 存档管理器 存档管理器=new();
        public static void MainStart() {
            存档管理器.读档(out 后台世界, out 后台背包);
            if (后台世界.Grid == null || 后台背包.Grid == null || 后台世界.Player == null) {
                创建世界流程(new 世界设定类());             
                创建背包流程(new 背包设定类());               
            }
            绘制世界流程();
            初始化快捷指令();
            订阅事件流程();
            绘制背包流程();
            Application.quitting += () => 存档管理器.存档(后台世界, 后台背包);
        }
    }
}
