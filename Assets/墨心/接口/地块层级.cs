using UnityEngine;

namespace ī�� {
    public interface I�㼶 {

    }
    public interface I�ذ�� : I�㼶 {
        public �ذ����� ���� { get; set; }
        public int ���� { get; set; }
    }
    public interface I������ : I�㼶 {
        public �������� ���� { get; set; }
        public int ���� { get; set; }
    }
    public interface I��ʯ�� : I�㼶 {
        public ��ʯ���� ���� { get; set; }
        public int ���� { get; set; }
    }
    public interface I���ʲ� : I�㼶 {
        public �������� ���� { get; set; }
    }
    public interface I������ : I�㼶 {
        public �������� ���� { get; set; }
        public int ���� { get; set; }
    }
    public enum �ذ����� {
        ��,
        ʯ�ذ�,
    }
    public enum �������� {
        ��,
        ��ľ,
        ����,
    }
    public enum ��ʯ���� {
        ��,
        ͭ��,
        ����,
    }
    public enum �������� {
        ���,
        ɳĮ,
        ��ˮ,
    }
    public enum �������� {
        ��,
    }
}