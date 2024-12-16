using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static 后台世界类 后台世界 = new();
        public static 世界系统 前台世界 = new();
        public static UI系统 UI = new();
        public static 存档管理器 存档管理器 = new();
        public static 笔记类 笔记= new();
        public static void MainStart() {
            存档管理器.读档();
            if (后台世界.Grid == null || 后台世界.Player == null) {
                创建世界流程(new 世界设定类());
                创建笔记流程(new 笔记设定类());
            }
            绘制世界流程();
            绘制UI流程();
            注册指令流程();
            订阅事件流程();
        }
    }
}