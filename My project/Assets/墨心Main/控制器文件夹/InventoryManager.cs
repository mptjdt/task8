using System;
using System.Collections.Generic;
using UnityEngine;

namespace 墨心main // 添加命名空间
{
    // 管理背包中的物品
    public class InventoryManager
    {
        // 存储单例的静态变量
        private static InventoryManager _instance;

        // 公开的属性用于访问单例实例
        public static InventoryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventoryManager(); // 创建新实例
                }
                return _instance;
            }
        }

        public List<Item> items = new List<Item>(); // 存储物品的列表

        // 声明事件
        public event Action OnInventoryChanged;

        // 添加物品
        public void AddItem(Item newItem)
        {
            items.Add(newItem); // 将新物品添加到列表
            OnInventoryChanged?.Invoke(); // 触发事件，通知背包已更新
        }

        // 移除物品
        public void RemoveItem(Item itemToRemove)
        {
            items.Remove(itemToRemove); // 从列表中移除物品
            OnInventoryChanged?.Invoke(); // 触发事件
        }

        // 根据物品名称修改物品
        public void ModifyItem(string itemName, Item updatedItem)
        {
            // 找到列表中物品名称相同的物品并进行修改
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == itemName) // 修改此处，使用大写的 Name
                {
                    items[i] = updatedItem;
                    OnInventoryChanged?.Invoke(); // 触发事件
                    break;
                }
            }
        }

        // 根据物品名称找到物品
        public Item FindItem(string itemName)
        {
            return items.Find(item => item.Name == itemName); // 修改此处，使用大写的 Name
        }
    }
}