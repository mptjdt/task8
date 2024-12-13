using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static 墨心.GameManager;

namespace 墨心 {
    public class UI系统 {
        public GameObject 信息面板;
        public Dictionary<Vector2Int, GameObject> 所有物品 = new();
        public bool 背包是否打开 = false;
        public GameObject 背包面板;
        public void 创建信息面板() {
            信息面板 = MainPanel.创建矩形(0.8f, 0, 0.2f, 0.2f);  // 左80% 上0 宽20% 高20%。右上角
            信息面板.SetColor(Color.white);
            信息面板.SetText("");
        }
        public void 创建背包面板(int X, int Y) {
            背包面板 = MainPanel.创建矩形(0.5f, 0.5f, 0.4f, 0.6f);
            背包面板.SetColor(Color.white);
            背包面板.SetGrid(X, Y);
            背包面板.SetActive(false);
        }
        public void 更新背包显示(I物品[,] X) {
            for (int i = 0; i < X.GetLength(0); i++) {
                for (int j = 0; j < X.GetLength(1); j++) {
                    所有物品[new Vector2Int(i, j)] = 背包面板.transform.GetChild(i * X.GetLength(1) + j).gameObject;
                    if (X[i, j] != null) {
                        所有物品[new Vector2Int(i, j)].GetComponent<Image>().sprite = Resources.Load<Sprite>("背包" + X[i, j].名称);
                    }
                }
            }
        }
    }
}