using UnityEngine;
using UnityEngine.UI;
using static 墨心.GameManager;

namespace 墨心 {
    public class 信息面板类 : MonoBehaviour {
        public GameObject panel;
        public GameObject 创建信息面板() {
            var A = MainPanel.创建矩形(0.8f,0,0.2f,0.2f);  // 左80% 上0 宽20% 高20%。右上角
            A.SetColor(Color.white);
            A.SetText("");
            return A;
        }
    }
    public static partial class GameManager {
        public static void 修改信息面板(string SoilType, int 数量) {
            信息面板.panel.GetComponentInChildren<Text>().text = $"地块类型: {SoilType}\n数量: {数量}";
        }
    }
}