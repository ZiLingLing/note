using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public static ItemFactory Instance { get; private set; }

    [SerializeField]
    private List<ItemType> itemTypes;//���пɴ����ĵ�������

    private Dictionary<string, ItemType> itemTypeDict = new Dictionary<string, ItemType>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        // ��ʼ���ڲ�״̬�ֵ�
        foreach (var type in itemTypes)
        {
            itemTypeDict[type.itemName] = type;
        }
    }

    // ��������ʵ��(Ӧ���ⲿ״̬)
    public ItemInstance CreateItem(string itemName, int quantity = 1)
    {
        if (itemTypeDict.TryGetValue(itemName, out ItemType type))
        {
            return new ItemInstance(type, quantity);
        }
        return null;
    }

    // ��ȡ������ڲ�״̬
    public ItemType GetItemType(string itemName)
    {
        itemTypeDict.TryGetValue(itemName, out ItemType type);
        return type;
    }
}
