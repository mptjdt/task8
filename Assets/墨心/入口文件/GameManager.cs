using System.Diagnostics;
using UnityEngine;
//项目入口文件
namespace 墨心{
    // 部分类：包含入口函数
    public static partial class GameManager{
        public static World WorldInstance { get; private set; }  // 存储后台世界的实例
        public static FrontendWorld FrontendInstance { get; private set; }  // 存储前台世界的实例

        // 主方法，程序入口
        public static void Mainstart(){
            // 创建后台世界
            WorldInstance = new World();
            // 创建前台世界
            FrontendInstance = new FrontendWorld();
            // 调用流程创建世界
            CreateWorld(10,10);
        }
    }
   
}
