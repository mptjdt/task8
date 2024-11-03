using UnityEngine;  
namespace 墨心  
{
    public static class GameManager  
    {
        public static World WorldInstance { get; private set; }  // 存储后台世界的实例
        public static FrontendWorld FrontendInstance { get; private set; }  // 存储前台世界的实例

        // 主方法，程序入口
        public static void Main()
        {
            // 创建后台世界
            WorldInstance = new World(10,10);

            // 创建前台世界，并显示地块
            FrontendInstance = new FrontendWorld(WorldInstance);  // 将World实例传递给FrontendWorld
        }
    }
}
