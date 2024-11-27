﻿using UnityEngine;

namespace 墨心 {
    // 工具文件
    public static partial class GameManager {
        // 加载精灵的静态方法
        public static Sprite LoadSprite(string path) => Resources.Load<Sprite>(path) ?? throw new System.Exception($"图片不存在：{path}");
    }
}
