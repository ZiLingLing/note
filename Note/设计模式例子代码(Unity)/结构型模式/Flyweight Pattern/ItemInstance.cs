using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
    //外部状态，即实例持有的外部可修改的字段
    public int quantity;// 数量

    // 关联的内部状态引用
    public ItemType itemType;//指向共享数据

    public ItemInstance(ItemType type, int quantity = 1)
    {
        this.itemType = type;
        this.quantity = quantity;
    }

    public void Use()
    {
        if (quantity > 0)
        {
            itemType.Use(this);
            quantity--;
        }
    }
}
