using System;
using System.IO;
using Newtonsoft.Json; // 引入 Newtonsoft.Json 命名空间
using UnityEngine;
using static 墨心.GameManager;

namespace 墨心 {
    public class 存档管理器 {
        private string 存档文件路径 = Path.Combine(Application.persistentDataPath, "saveFile.json");
        public void 存档() {
            //SaveData data = new SaveData {
            //    WorldData = 世界,
            //    InventoryData = 背包
            //};
            //JsonSerializerSettings settings = new JsonSerializerSettings {
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore, 
            //    TypeNameHandling = TypeNameHandling.Objects 
            //};
            //string json = JsonConvert.SerializeObject(data, Formatting.Indented, settings);
            //try {
            //    File.WriteAllText(存档文件路径, json);
            //}
            //catch (Exception e) {
            //    Debug.LogError("存档失败: " + e.Message);
            //}
            FileWrite(存档文件路径, 后台世界);
        }
        public void 读档() {
            //世界 = new 后台世界类();
            //背包 = new 后台背包类();
            //if (!File.Exists(存档文件路径)) {
            //    Debug.LogWarning("存档文件不存在，初始化默认数据。");
            //    return;
            //}
            //try {
            //    string json = File.ReadAllText(存档文件路径);
            //    JsonSerializerSettings settings = new JsonSerializerSettings {
            //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //        TypeNameHandling = TypeNameHandling.Objects 
            //    };
            //    SaveData data = JsonConvert.DeserializeObject<SaveData>(json, settings); 
            //    世界 = data.WorldData;
            //    背包 = data.InventoryData;
            //}
            //catch (Exception e) {
            //    Debug.LogError("读档失败: " + e.Message);
            //}
            后台世界 = FileRead<后台世界类>(存档文件路径);
        }
    }
}
