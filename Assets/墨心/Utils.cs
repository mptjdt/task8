using UnityEngine;

namespace 墨心{
    //工具文件
    public static class Utils{
        // 加载精灵的静态方法
        public static Sprite LoadSprite(string path){
            Sprite sprite = Resources.Load<Sprite>(path);

            if (sprite == null){
                HandleError($"Failed to load sprite at {path}. Sprite is null.");  // 记录错误信息
            }

            return sprite;  // 返回null如果加载失败
        }

        // 错误处理方法
        public static void HandleError(string message){
            Debug.LogError(message);  // 记录错误信息
        }
    }
}
