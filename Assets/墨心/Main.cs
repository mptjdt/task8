using UnityEngine;

namespace 墨心.Task8 {
    public static partial class LocalStorage {
        public static I世界 后台世界 = new 后台世界类();
        public static I世界系统 前台世界 = new 世界系统();
        public static IUI系统 UI = new UI系统();
        public static I存档管理 存档管理器 = new 存档管理();
        public static I笔记 笔记= new 笔记类();
        public static void MainStart() {
            //if (!存档管理器.读档()) {
                创建世界流程(new 世界设定类());
                创建笔记流程(new 笔记设定类());
            //}
            运行世界流程();
            绘制世界流程();
            绘制UI流程();
            注册指令流程();
        }
    }
}