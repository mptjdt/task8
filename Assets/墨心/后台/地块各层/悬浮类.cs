using System;
using System.Collections.Generic;

namespace 墨心.Task8 {
    public class 悬浮类 : I悬浮层 {
        public Dictionary<string, int> 道具们 { get; set; } = new Dictionary<string, int>();
        public static I悬浮层 To悬浮(string X) {
            if (string.IsNullOrEmpty(X)) {
                return null;
            }
            var A = new 悬浮类();
            var B = X.Split('*');
            if (B.Length == 2) {
                string key = B[0];
                if (int.TryParse(B[1], out int value)) {
                    A.道具们.Add(key, value);
                }
            }
            return A;
        }
    }
}