using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace 墨心 {
    public static partial class GameManager {
        public static 后台世界类 后台世界 = new();
        public static 世界系统 前台世界 = new();
        public static UI系统 信息面板 = new();
        public static void MainStart() {
            创建世界流程();
            绘制世界流程();
            初始化快捷指令();
            订阅事件流程();
        }
    }
}