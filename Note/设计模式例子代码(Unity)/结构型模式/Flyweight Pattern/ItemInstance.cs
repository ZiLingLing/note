using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
    //�ⲿ״̬����ʵ�����е��ⲿ���޸ĵ��ֶ�
    public int quantity;// ����

    // �������ڲ�״̬����
    public ItemType itemType;//ָ��������

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
