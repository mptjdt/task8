using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace 墨心 {
    public class 矿石类:I层级 {     
        public 矿石种类 类型;
        public int 数量;
        public static I矿石层 创建铜矿地块() {
            var A = new 矿石类();
            A.类型 = 矿石种类.铜矿;
            A.数量 = 3;
            return (I矿石层)A;
        }
    }
}