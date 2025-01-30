using System.Collections.Generic;
using UnityEngine;

namespace 墨心.Task8 {
    public interface I存档管理 {
        public void 存档();
        public bool 读档();
    }
    public interface I笔记 {
        bool 背包是否打开 { get; set; }
    }
}