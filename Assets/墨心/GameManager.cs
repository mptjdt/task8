using UnityEngine;  
namespace ī��  
{
    public static class GameManager  
    {
        public static World WorldInstance { get; private set; }  // �洢��̨�����ʵ��
        public static FrontendWorld FrontendInstance { get; private set; }  // �洢ǰ̨�����ʵ��

        // ���������������
        public static void Main()
        {
            // ������̨����
            WorldInstance = new World(10,10);

            // ����ǰ̨���磬����ʾ�ؿ�
            FrontendInstance = new FrontendWorld(WorldInstance);  // ��Worldʵ�����ݸ�FrontendWorld
        }
    }
}
