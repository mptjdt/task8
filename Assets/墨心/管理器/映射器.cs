using UnityEngine;

namespace ī�� {
    public static partial class GameManager {
        public static ��̨�ؿ��� ��ȡ��ǰ�ؿ�(Vector2 screenPosition) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector2 worldPos = new Vector2(worldPosition.x, worldPosition.y);// ʹ������ͷ����Ļ����ת��Ϊ��������
            int gridX = Mathf.FloorToInt(worldPos.x);  // ȡ��ת��Ϊ��������
            int gridY = Mathf.FloorToInt(worldPos.y);  // ȡ��ת��Ϊ��������          
            gridX = Mathf.Clamp(gridX, 0, ��̨����.Width - 1);
            gridY = Mathf.Clamp(gridY, 0, ��̨����.Height - 1); // ����������ת��Ϊ��������                                                                     // �ж��Ƿ�����Ч�ؿ鷶Χ��
            if (gridX < 0 || gridX >= ��̨����.Width || gridY < 0 || gridY >= ��̨����.Height) {
                return null;  // ���������Χ������ null ��������ʾ��Ч��ֵ
            }
            return ��̨����.Grid[gridX, gridY];// �������������ȡ��ǰ�ؿ鲢����
        }
    }
}