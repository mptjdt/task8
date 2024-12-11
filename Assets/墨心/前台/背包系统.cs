using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static 墨心.GameManager;

namespace 墨心 {
    public class 背包系统 {
        public Dictionary<Vector2Int, GameObject> 所有物品 = new();
        public bool 背包是否打开 = false;
        public GameObject 背包面板;
        public void 创建背包面板(int X, int Y) {
            背包面板 = MainPanel.创建矩形(0.5f, 0.5f, 0.4f, 0.6f);
            背包面板.SetColor(Color.white);
            背包面板.SetGrid(X, Y);
            背包面板.SetActive(false);
        }
        public void 更新背包显示(I物品[,] X) {
            for (int i = 0; i < X.GetLength(0); i++) {
                for (int j = 0; j < X.GetLength(1); j++) {
                    var A = X[i, j];
                    var B = 背包面板.transform.GetChild(i * X.GetLength(1) + j).gameObject;
                    if (A != null) {
                        B.GetComponent<Image>().sprite= Resources.Load<Sprite>("背包" + A.名称);
                        所有物品[new Vector2Int(i, j)] = B;
                    }
                }
            }
        }
    }
}