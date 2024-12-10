using UnityEngine;
using UnityEngine.UI;
using static 墨心.GameManager;

namespace 墨心 {
    public class UI系统 {
        public GameObject 信息面板 = 创建信息面板();
        public GameObject 背包面板;
        public static GameObject 创建信息面板() {
            var A = MainPanel.创建矩形(0.8f, 0, 0.2f, 0.2f);  // 左80% 上0 宽20% 高20%。右上角
            A.SetColor(Color.white);
            A.SetText("");
            return A;
        }
    }
}