using UnityEngine;

namespace 墨心 {
    public class 后台物品类 : I物品 {
        public string 名称 { get; set; }
        public int 数量 {  get; set; }
        public Vector2Int 坐标 { get; set; }
    }
}
