using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace 墨心 {
    public class 矿石类:I层级 {
        public enum 地块类型 {
            无,
            铜矿,
            铁矿,
        }
        public 地块类型 类型;
        public int 数量;
        public static 矿石类 创建铜矿地块() {
            var A = new 矿石类();
            A.类型 = 地块类型.铜矿;
            A.数量 = 3;
            return A;
        }
    }
}