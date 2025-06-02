using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemType", menuName = "Inventory/Item Type")]
public class ItemType : ScriptableObject
{
    [Header("������ڲ�״̬")]
    public string itemName;//��������
    public Sprite icon;//ͼ��
    public GameObject prefab;//Ԥ����
    public int maxStack = 1;//�ѵ�����
    public float value;//��ֵ

    [TextArea]
    public string description;// �����ı�

    // �������Ϊ����
    public virtual void Use(ItemInstance instance)
    {
        Debug.Log($"ʹ�� {itemName}");
        // TODO:������߹��õ��߼�
    }
}
