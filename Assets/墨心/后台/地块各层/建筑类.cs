namespace 墨心.Task8 {
    public class 建筑类 : I建筑层 {
        public 建筑种类 类型 { get; set; }
        public int 耐久 { get; set; }
        public static I建筑层 创建树木地块() {
            var A = new 建筑类();
            A.类型 = 建筑种类.树木;
            A.耐久 = 10;
            return A;
        }
    }
}