using System.Collections.Generic;
using UnityEngine;
using static 墨心.GameManager;

namespace 墨心.Task8 {
    public class 后台背包类 : I背包 {
        public List<I物品> 物品列表 { get; set; }
        public int 芥子上限 { get; set; }
        public void 创建背包(int X) {
            Print("正在创建背包...");
            芥子上限 = X;
            物品列表 = new List<I物品>();
            for (int i = 0; i < X; i++) {
                物品列表.Add(null);
            }
        }
        public bool 添加物品(I物品 X) {
            for (int i = 0; i < 物品列表.Count; i++) {
                if (物品列表[i] == null) {
                    物品列表[i] = X;
                    X.槽位 = i;
                    Print("物品 " + X.名称 + " 已添加到背包 " + X.槽位);
                    return true;
                }
            }
            Print("背包已满，无法添加物品");
            return false;
        }
    }
}
