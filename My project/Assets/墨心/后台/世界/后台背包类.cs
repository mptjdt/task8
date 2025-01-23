using System.Collections.Generic;
using UnityEngine;
using static 墨心.LocalStorage;

namespace 墨心.Task8 {
    public class 后台背包类 : I背包 {
        public List<I物品> 物品列表 { get; set; }
        public int 体积限制 { get; set; }
        public int 重量限制 { get; set; }
        public void 创建背包(int X,int Y) {
            Print("正在创建背包...");
            体积限制 = X;
            重量限制 = Y;
            物品列表 = new List<I物品>();
        }
        private int 当前总重量() {
            int 总重量 = 0;
            foreach (var 物品 in 物品列表) {
                if (物品 != null) {
                    总重量 += 物品.重量;
                }
            }
            return 总重量;
        }
        private int 当前总体积() {
            int 总体积 = 0;
            foreach (var 物品 in 物品列表) {
                if (物品 != null) {
                    总体积 += 物品.体积;
                }
            }
            return 总体积;
        }
        public bool 添加物品(I物品 X) {
            if (当前总体积() + X.体积 > 体积限制) {
                Print("背包体积已满，无法添加物品 " + X.名称);
                return false;
            }
            if (当前总重量() + X.重量 > 重量限制) {
                Print("背包超重，无法添加物品 " + X.名称);
                return false;
            }

            物品列表.Add(X);
            X.槽位 = 物品列表.Count - 1;
            Print("物品 " + X.名称 + " 已添加到背包 " + X.槽位);
            return true;
        }
    }
}
