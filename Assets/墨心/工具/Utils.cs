using System.Diagnostics;
using UnityEngine;

namespace 墨心{
    // 工具文件
    public static partial class GameManager{
        // 加载精灵的静态方法
        public static Sprite LoadSprite(string path){
            Sprite sprite = Resources.Load<Sprite>(path);
            // 如果精灵加载失败，抛出异常
            if (sprite == null){
                throw new System.Exception($"Failed to load sprite at {path}. Sprite is null.");  // 抛出异常
            }
            return sprite;  // 返回加载的精灵
        }
    }
}
