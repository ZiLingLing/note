using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemType", menuName = "Inventory/Item Type")]
public class ItemType : ScriptableObject
{
    [Header("共享的内部状态")]
    public string itemName;//道具名称
    public Sprite icon;//图标
    public GameObject prefab;//预制体
    public int maxStack = 1;//堆叠上限
    public float value;//价值

    [TextArea]
    public string description;// 描述文本

    // 共享的行为方法
    public virtual void Use(ItemInstance instance)
    {
        Debug.Log($"使用 {itemName}");
        // TODO:该类道具共用的逻辑
    }
}
