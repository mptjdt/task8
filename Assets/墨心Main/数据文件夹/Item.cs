namespace 墨心main // 添加命名空间
{
    public class Item
    {
        // 属性：物品名称
        public string Name { get; set; }

        // 属性：物品的图像路径
        public string SpritePath { get; set; }

        // 构造函数：初始化物品名称和图像路径
        public Item(string name, string spritePath)
        {
            Name = name;
            SpritePath = spritePath;
        }
    }
}