namespace 墨心 {
    public class 土质类 :I层级 {
        public enum 地块类型 {
            虚空,
            沙漠,
            淡水,
        }
        public 地块类型 类型 { get; set; }
        public static 土质类 创建沙漠地块() {
            var A = new 土质类();
            A.类型 = 地块类型.沙漠;
            return A;
        }
    }
}