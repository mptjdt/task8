using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace 墨心 {
    public class 矿石类 {
        public enum 地块类型{
            铜矿
        }
        public 地块类型 类型;
        public int 数量;
    }
    public static partial class GameManager {
        public static 矿石类 创建铜矿地块() {
            矿石类 矿石层 = new 矿石类();
            矿石层.类型 = 矿石类.地块类型.铜矿;
            矿石层.数量 = 3;
            return 矿石层;
        }
        public static void 初始化矿石层(int 单个矿堆矿石数, int 矿堆个数) {
            for (int i = 0; i < 矿堆个数; i++) {
                int 初始点横坐标 = UnityEngine.Random.Range(0, 后台实例.Width);
                int 初始点纵坐标 = UnityEngine.Random.Range(0, 后台实例.Height);
                while (后台实例.Grid[初始点横坐标, 初始点纵坐标].矿石层 != null) {
                    初始点横坐标 = UnityEngine.Random.Range(0, 后台实例.Width);
                    初始点纵坐标 = UnityEngine.Random.Range(0, 后台实例.Height);
                }
                传染矿石(初始点横坐标, 初始点纵坐标, 单个矿堆矿石数);
            }
        }
        public static void 传染矿石(int x, int y, int 剩余传染次数) {
            if (剩余传染次数 <= 0 || x < 0 || y < 0 || x >= 后台实例.Width || y >= 后台实例.Height) return;
            后台实例.Grid[x, y].矿石层 = 创建铜矿地块();
            剩余传染次数--;
            List<(int, int)> 邻居方向 = new List<(int, int)> {
              (0, 1),  // 上
              (0, -1), // 下
              (1, 0),  // 右
              (-1, 0)  // 左
            };
            var 随机方向 = 邻居方向[UnityEngine.Random.Range(0, 邻居方向.Count)];
            传染矿石(x + 随机方向.Item1, y + 随机方向.Item2, 剩余传染次数);
        }
    }
}
