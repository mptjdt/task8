namespace ī��{
    public class TileInfo{
        // �ؿ�����������ֶ�
        public string SoilType { get; private set; }
        // ��̬���������ڳ�ʼ�� TileInfo ����
        public static TileInfo CreateTileInfo(){
            TileInfo tileInfo = new TileInfo();
            tileInfo.SoilType = "desert";  // Ĭ����������ΪɳĮ
            return tileInfo;
        }
    }
}

