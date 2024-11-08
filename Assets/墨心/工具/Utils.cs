using System.Diagnostics;
using UnityEngine;

namespace ī��{
    // �����ļ�
    public static partial class GameManager{
        // ���ؾ���ľ�̬����
        public static Sprite LoadSprite(string path){
            Sprite sprite = Resources.Load<Sprite>(path);
            // ����������ʧ�ܣ��׳��쳣
            if (sprite == null){
                throw new System.Exception($"Failed to load sprite at {path}. Sprite is null.");  // �׳��쳣
            }
            return sprite;  // ���ؼ��صľ���
        }
    }
}
