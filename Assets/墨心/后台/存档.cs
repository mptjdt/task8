using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // 引入 Newtonsoft.Json 命名空间
using UnityEngine;
using static 墨心.GameManager;
using static 墨心.Task8.GameManager;

namespace 墨心.Task8 {
    public class 存档管理器 {
        private string 世界文件路径;
        private string 笔记文件路径;
        public 存档管理器() {
            if (Application.isEditor) {
                世界文件路径 = Path.Combine(Application.dataPath, "worldFile.json");
                笔记文件路径 = Path.Combine(Application.dataPath, "notesFile.json");
            }
            else {
                世界文件路径 = Path.Combine(Application.persistentDataPath, "worldFile.json");
                笔记文件路径 = Path.Combine(Application.persistentDataPath, "notesFile.json");
            }
        }
        public void 存档() {
            FileWrite(世界文件路径, 后台世界);
            FileWrite(笔记文件路径, 笔记);
        }
        public bool 读档() {
            if (!File.Exists(世界文件路径)) {
                后台世界 = null;
                return false;
            }
            if (!File.Exists(笔记文件路径)) {
                笔记 = null;
                return false;
            }
            后台世界 = FileRead<后台世界类>(世界文件路径);
            笔记 = FileRead<笔记类>(笔记文件路径);
            if (后台世界 == null||笔记==null) {
                return false;
            }
            return true;
        }
    }
}
