using UnityEngine;

namespace ī��{
    // �����ļ�
    public static partial class GameManager{
        // ���ؾ���ľ�̬����
        public static Sprite LoadSprite(string path) =>
            Resources.Load<Sprite>(path) ?? throw new System.Exception($"Failed to load sprite at {path}. Sprite is null.");
    }
}
