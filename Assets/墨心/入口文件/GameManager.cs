using System.Diagnostics;
using UnityEngine;
//��Ŀ����ļ�
namespace ī��{
    // �����ࣺ������ں���
    public static partial class GameManager{
        public static World WorldInstance { get; private set; }  // �洢��̨�����ʵ��
        public static FrontendWorld FrontendInstance { get; private set; }  // �洢ǰ̨�����ʵ��

        // ���������������
        public static void Mainstart(){
            // ������̨����
            WorldInstance = new World();
            // ����ǰ̨����
            FrontendInstance = new FrontendWorld();
            // �������̴�������
            CreateWorld(10,10);
        }
    }
   
}
