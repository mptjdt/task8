using UnityEngine;

namespace 墨心.Task8 {
    public static partial class GameManager {
        public static 后台世界类 后台世界 = new();
        public static 世界系统 前台世界 = new();
        public static UI系统 UI = new();
        public static 存档管理 存档管理器 = new();
        public static 笔记类 笔记= new();
        public static void MainStart() {
            if (!存档管理器.读档()) {
                创建世界流程(new 世界设定类());
                创建笔记流程(new 笔记设定类());
            }
            运行世界流程();
            绘制世界流程();
            绘制UI流程();
            注册指令流程();
        }
    }
}