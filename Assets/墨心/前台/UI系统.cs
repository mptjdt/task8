using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static 墨心.GameManager;

namespace 墨心.Task8 {
    public class UI系统 {
        public GameObject 信息面板;
        public Dictionary<int, GameObject> 所有物品 = new();
        public GameObject 背包面板;
        public GameObject 角色面板;
        public void 创建信息面板() {
            信息面板 = MainPanel.创建矩形(0.8f, 0, 0.2f, 0.2f);  // 左80% 上0 宽20% 高20%。右上角
            信息面板.SetColor(Color.white);
            信息面板.SetText("");
        }
        public void 创建背包面板(int X, int Y,bool Z) {
            背包面板 = MainPanel.创建矩形(0.5f, 0.5f, 0.4f, 0.6f);         
            背包面板.SetGrid(X, Y);
            背包面板.SetColorDirectly(Color.white);
            背包面板.SetActive(Z);
        }
        public void 创建角色面板() {
            角色面板 = MainPanel.创建矩形(1f, 0.9f, 0.1f, 0.1f);
            角色面板.SetColor(Color.white);
            角色面板.SetText("");
        }
        public void 更新背包显示(I背包 X) {
            for (int i = 0; i < X.Width * X.Height; i++) {
                所有物品[i] = 背包面板.transform.GetChild(i).gameObject;
                if (X.物品列表[i] != null) {
                    所有物品[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("背包" + X.物品列表[i].名称);
                }
                //背包面板.Clear();
                //for (int i = 0; i < X.物品列表.Count; i++) {
                //背包面板.创建矩形().SetColor(Color.gray).SetSprite("背包" + X.物品列表[i].名称);
            }
        }
        public void 开关背包(bool X) {
            背包面板.SetActive(X);
        }
    }
}