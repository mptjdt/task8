using System;
using Newtonsoft.Json;
using System.IO;

namespace 墨心 {
    public static partial class GameManager {
        public static void FileWrite<T>(string X, T Y) {
            JsonSerializerSettings settings = new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Objects,
                 ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver {
                     DefaultMembersSearchFlags = System.Reflection.BindingFlags.Public |
                                        System.Reflection.BindingFlags.NonPublic |
                                        System.Reflection.BindingFlags.Instance
                 }
            };
            string json = JsonConvert.SerializeObject(Y, Formatting.Indented, settings);          
            try {
                File.WriteAllText(X, json);
                Print($"{typeof(T).Name} 保存成功！");
            }
            catch (Exception e) {
                Print("保存失败: " + e.Message);
            }
        }
        public static T FileRead<T>(string X) {
            if (!File.Exists(X)) {
                Print($"文件 {X} 未找到，返回默认值");
                return default(T);
            }
            else {
                Print($"{typeof(T).Name}读档成功");
            }
            string json = File.ReadAllText(X);
            JsonSerializerSettings settings = new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Objects,
                 ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver {
                     DefaultMembersSearchFlags = System.Reflection.BindingFlags.Public |
                                        System.Reflection.BindingFlags.NonPublic |
                                        System.Reflection.BindingFlags.Instance
                 }
            };
            try {
                T result = JsonConvert.DeserializeObject<T>(json, settings);
                return result;
            }
            catch (Exception e) {
                Print("读档失败: " + e.Message);
                throw;
            }
        }
    }
}