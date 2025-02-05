using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static 墨心.LocalStorage;

namespace 墨心.Task8 {
    public class UI系统 :IUI系统{
        public GameObject 信息面板 { get; set; }
        public Dictionary<int, GameObject> 所有物品 { get; set; } = new();
        public GameObject 背包面板 { get; set; }
        public GameObject 角色面板 { get; set; }
        public void 创建信息面板() {
            信息面板 = MainPanel.创建矩形(0.8f, 0, 0.2f, 0.2f);  // 左80% 上0 宽20% 高20%。右上角
            信息面板.SetColor(Color.white);
            信息面板.SetText("");
        }
        public void 创建背包面板(bool X) {
            背包面板 = MainPanel.创建矩形(0, 0, 0.4f, 0.6f);
            背包面板.SetGrid();
            背包面板.SetColor(Color.white);
            背包面板.SetActive(X);
        }
        public void 创建角色面板() {
            角色面板 = MainPanel.创建矩形(0.9f, 0.9f, 0.1f, 0.1f);
            角色面板.SetColor(Color.white);
            角色面板.SetText("");
        }
        public void 更新背包显示(I背包 X) {
            背包面板.Clear();
            for (int i = 0; i < X.物品列表.Count; i++) {
                背包面板.创建背包格子(X.物品列表[i]);
            }
        }
        public void 开关背包(bool X) {
            背包面板.SetActive(X);
        }
    }
    public static partial class LocalStorage {
        public static 背包格子驱动 创建背包格子(this GameObject X, I物品 Y) {
            var A= X.创建矩形().AddComponent<背包格子驱动>().SetData(Y);
            A.transform.SetParent(X.transform, false);
            return A;
        }
    }
    public class 背包格子驱动 : MonoBehaviour {
        public GameObject 垫子层;
        public GameObject 道具层;
        public 背包格子驱动 SetData(I物品 X = null) {
            Destroy(垫子层);
            Destroy(道具层);
            垫子层 = gameObject.创建矩形().SetColor(Color.gray);
            if (X != null) {
                道具层 = 垫子层.创建矩形().SetSprite("背包" + X.名称);
            }
            return this;
        }
    }
}