namespace 墨心 {
    public class 土质类 {
        public enum 地块类型 {
            沙漠,
            淡水
        }
        public 地块类型 类型;
        public int 数量;
    }
    public static partial class GameManager {
        public static 土质类 创建沙漠地块() {
            土质类 土质层 = new 土质类();
            土质层.类型 = 土质类.地块类型.沙漠;
            土质层.数量 = -1;
            return 土质层;
        }
    }
}
