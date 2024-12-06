using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static 后台世界类 后台世界 = new();
        public static 前台世界类 前台世界;
        public static UI系统 信息面板;
        public static void MainStart() {
            初始化后台();
            初始化前台();
            绘制世界流程();
            初始化快捷指令();
            订阅事件流程();
        }
    }
}