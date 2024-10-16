using UnityEngine;

namespace 墨心8A2
{
    public class TileInfo : MonoBehaviour
    {
        // 地块层级类型
        public enum LayerType
        {
            Stone,
            Desert = 1,  // 沙漠层
            边墙 = 3,    // 边墙层
            虚空 = 5      // 虚空层
        }

        // 属性
        public GameObject TileObject { get; private set; } // 对应的游戏对象
        public LayerType Layer { get; private set; } // 层类型
        public int ID { get; private set; } // ID

        // 构造函数
        public TileInfo(GameObject tileObject, LayerType layer, int id)
        {
            TileObject = tileObject; // 赋值游戏对象
            Layer = layer; // 设置层级
            ID = id; // 设置ID
        }
        


    }
}
