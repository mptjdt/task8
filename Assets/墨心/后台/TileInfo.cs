using ī��;

namespace ī��{
    public class TileInfo{
        // �ؿ�����������ֶ�
        public string SoilType { get; set; }   
    }
    // ��̬���������ڳ�ʼ�� TileInfo ����
    public static partial class GameManager{
        public static TileInfo ����ɳĮ�ؿ�(){
            TileInfo tileInfo = new TileInfo();
            tileInfo.SoilType = "desert";  // Ĭ����������ΪɳĮ
            return tileInfo;
        }
    }
}