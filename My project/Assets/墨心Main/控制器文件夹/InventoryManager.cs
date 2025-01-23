using System;
using System.Collections.Generic;
using UnityEngine;

namespace ī��main // ��������ռ�
{
    // �������е���Ʒ
    public class InventoryManager
    {
        // �洢�����ľ�̬����
        private static InventoryManager _instance;

        // �������������ڷ��ʵ���ʵ��
        public static InventoryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventoryManager(); // ������ʵ��
                }
                return _instance;
            }
        }

        public List<Item> items = new List<Item>(); // �洢��Ʒ���б�

        // �����¼�
        public event Action OnInventoryChanged;

        // �����Ʒ
        public void AddItem(Item newItem)
        {
            items.Add(newItem); // ������Ʒ��ӵ��б�
            OnInventoryChanged?.Invoke(); // �����¼���֪ͨ�����Ѹ���
        }

        // �Ƴ���Ʒ
        public void RemoveItem(Item itemToRemove)
        {
            items.Remove(itemToRemove); // ���б����Ƴ���Ʒ
            OnInventoryChanged?.Invoke(); // �����¼�
        }

        // ������Ʒ�����޸���Ʒ
        public void ModifyItem(string itemName, Item updatedItem)
        {
            // �ҵ��б�����Ʒ������ͬ����Ʒ�������޸�
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == itemName) // �޸Ĵ˴���ʹ�ô�д�� Name
                {
                    items[i] = updatedItem;
                    OnInventoryChanged?.Invoke(); // �����¼�
                    break;
                }
            }
        }

        // ������Ʒ�����ҵ���Ʒ
        public Item FindItem(string itemName)
        {
            return items.Find(item => item.Name == itemName); // �޸Ĵ˴���ʹ�ô�д�� Name
        }
    }
}