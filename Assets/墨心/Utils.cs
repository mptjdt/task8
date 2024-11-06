using UnityEngine;

namespace ī��{
    //�����ļ�
    public static class Utils{
        // ���ؾ���ľ�̬����
        public static Sprite LoadSprite(string path){
            Sprite sprite = Resources.Load<Sprite>(path);

            if (sprite == null){
                HandleError($"Failed to load sprite at {path}. Sprite is null.");  // ��¼������Ϣ
            }

            return sprite;  // ����null�������ʧ��
        }

        // ��������
        public static void HandleError(string message){
            Debug.LogError(message);  // ��¼������Ϣ
        }
    }
}
