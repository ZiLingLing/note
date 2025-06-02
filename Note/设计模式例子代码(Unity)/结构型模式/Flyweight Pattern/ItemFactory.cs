using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static ItemFactory Instance { get; private set; }

    [SerializeField]
    private List<ItemType> itemTypes;//所有可创建的道具类型

    private Dictionary<string, ItemType> itemTypeDict = new Dictionary<string, ItemType>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        // 初始化内部状态字典
        foreach (var type in itemTypes)
        {
            itemTypeDict[type.itemName] = type;
        }
    }

    // 创建道具实例(应用外部状态)
    public ItemInstance CreateItem(string itemName, int quantity = 1)
    {
        if (itemTypeDict.TryGetValue(itemName, out ItemType type))
        {
            return new ItemInstance(type, quantity);
        }
        return null;
    }

    // 获取共享的内部状态
    public ItemType GetItemType(string itemName)
    {
        itemTypeDict.TryGetValue(itemName, out ItemType type);
        return type;
    }
}
