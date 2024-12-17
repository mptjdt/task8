using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // 引入 Newtonsoft.Json 命名空间
using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class 存档管理器 {
        private string 世界文件路径 = Path.Combine(Application.persistentDataPath, "worldFile.json");
        private string 笔记文件路径 = Path.Combine(Application.persistentDataPath, "notesFile.json");
        public void 存档() { 
            FileWrite(世界文件路径, 后台世界);
            FileWrite(笔记文件路径, 笔记);
        }
        public void 读档() {
            后台世界 = FileRead<后台世界类>(世界文件路径);
            笔记 = FileRead<笔记类>(笔记文件路径) ?? new 笔记类();
        }
    }
}
