namespace ī��main // ��������ռ�
{
    public class Item
    {
        // ���ԣ���Ʒ����
        public string Name { get; set; }

        // ���ԣ���Ʒ��ͼ��·��
        public string SpritePath { get; set; }

        // ���캯������ʼ����Ʒ���ƺ�ͼ��·��
        public Item(string name, string spritePath)
        {
            Name = name;
            SpritePath = spritePath;
        }
    }
}