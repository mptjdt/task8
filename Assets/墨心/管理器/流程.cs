using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Object;

namespace ī�� {
    public static partial class GameManager {
        public static void ��ʼ����̨() {
            ��̨����.��������(10, 10);
            ��̨����.���ɳĮ();
            ��̨����.����ͭ��(3, 3);
            ��̨����.Player = ��̨�����.InitializePlayer(5f, 5f);
        }
        public static void ��ʼ��ǰ̨() {
            ǰ̨���� = MainCamera.AddComponent<ǰ̨������>();
            ǰ̨���� = MainCamera.AddComponent<ǰ̨������>();
            ��Ϣ��� = MainCamera.AddComponent<��Ϣ���ϵͳ>();
        }
        public static void ������������() {
            ǰ̨����.���еؿ� = new Dictionary<Vector2Int, GameObject>();
            for (int i = 0; i < ��̨����.Width; i++) {
                for (int j = 0; j < ��̨����.Height; j++) {
                    ǰ̨����.�������ʲ�(i, j, ��̨����.Grid[i, j]);
                    GameObject ��ʯ����� = ǰ̨����.������ʯ��(i, j, ��̨����.Grid[i, j]);
                    ǰ̨����.���еؿ�.Add(��̨����.Grid[i, j].λ��, ��ʯ�����);
                }
            }
            ǰ̨����.PlayerObj = ǰ̨����.CreatePlayer(��̨����.Player);
        }
        public static void �����¼�����() {
            Event.OnPlayerPositionUpdated += (Vector2 position, float rotation) => {
                ǰ̨����.PlayerObj.transform.position = position;
                ǰ̨����.PlayerObj.transform.rotation = Quaternion.Euler(0, 0, rotation);
            };
            Event.on�ؿ�ɹ� += (Vector2Int X) => {
                if (ǰ̨����.���еؿ�.TryGetValue(X, out GameObject ɾ���ؿ�)) {
                    ǰ̨����.���еؿ�.Remove(X);
                    Destroy(ɾ���ؿ�);
                }
            };
            Event.�ؿ��� += (string SoilType, int ����) => {
                ��Ϣ���.GetComponentInChildren<Text>().text = $"�ؿ�����: {SoilType}\n����: {����}";
            };
        }
    }
}