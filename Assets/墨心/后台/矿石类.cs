namespace 墨心 {
    public class 矿石类 {
        public enum 地块类型{
            铜矿
        }
        public 地块类型 类型;
        public int 数量;
    }
    public static partial class GameManager {
        public static 矿石类 创建矿石地块() {
            矿石类 矿石层 = new 矿石类();
            矿石层.类型 = 矿石类.地块类型.铜矿;
            矿石层.数量 = -1;
            return 矿石层;
        }
    }
}
