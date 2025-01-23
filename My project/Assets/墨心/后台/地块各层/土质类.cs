namespace 墨心.Task8 {
    public class 土质类 : I土质层 {
        public 土质种类 类型 { get; set; }
        public static I土质层 创建沙漠地块() {
            var A = new 土质类();
            A.类型 = 土质种类.沙漠;
            return A;
        }
        public static I土质层 创建草地地块() {
            var A = new 土质类();
            A.类型 = 土质种类.草地;
            return A;
        }
    }
}