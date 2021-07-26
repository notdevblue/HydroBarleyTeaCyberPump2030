using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ���� (�Ǵ� ���)
public class InventoryBase : MonoBehaviour
{

    static private InventoryBase                inst            = null;                                // static �Լ� ��
           private Dictionary<ItemEnum, ItemVO> inventory       = new Dictionary<ItemEnum, ItemVO>();  // �κ��丮 ��ųʸ�

    #region init, includes Awake

    private void Awake()
    {
        inst = this;

        SetItemData(true);
    }

    #endregion

    #region Item

    /// <summary>
    /// ������ �⺻ �����͸� �κ��丮�� ����
    /// </summary>
    private void SetItemData(bool debug = false)
    {
        int count = 0;

        if (debug)
        {
            count = 1;
        }

        inventory.Add(ItemEnum.Star,     new ItemVO(ItemEnum.Star,     count, 0));
        inventory.Add(ItemEnum.Mermaid,  new ItemVO(ItemEnum.Mermaid,  count, 0));
        inventory.Add(ItemEnum.Flower,   new ItemVO(ItemEnum.Flower,   count, 0));
        inventory.Add(ItemEnum.WolfTear, new ItemVO(ItemEnum.WolfTear, count, 0));
        inventory.Add(ItemEnum.Fog,      new ItemVO(ItemEnum.Fog,      count, 0));
        inventory.Add(ItemEnum.Moon,     new ItemVO(ItemEnum.Moon,     count, 0));
    }



    /// <summary>
    /// ������ ������ �� �ִ��� Ȯ���ϴ� �Լ�
    /// </summary>
    /// <param name="itemEnum">������ ������</param>
    /// <param name="itemVO">������ �� ���� �� ������ �������� ������ ���</param>
    /// <returns>false when item count is 0 or less</returns>
    static public bool TryGetItem(ItemEnum itemEnum, ref ItemVO itemVO)
    {
        if (!inst.inventory.ContainsKey(itemEnum))
        {
            Debug.LogError($"Request key: {itemEnum} does not exists");
            return false;
        }

        if (inst.inventory[itemEnum].count < 1) 
        {
            itemVO = null;
            return false;
        }

        itemVO = inst.inventory[itemEnum];
        
        return true;
    }

    /// <summary>
    /// �������� ���� ������ ������ �� ����
    /// </summary>
    /// <param name="itemEnum"></param>
    /// <returns>inventory[itemEnum]</returns>
    static public ItemVO CheckItem(ItemEnum itemEnum)
    {
        if (!inst.inventory.ContainsKey(itemEnum))
        {
            Debug.LogError($"Inventory: Request ItemEnum does not exist.\r\nItemEnum: {itemEnum}");
            return null;
        }

        return new ItemVO(inst.inventory[itemEnum].itemEnum, inst.inventory[itemEnum].count, inst.inventory[itemEnum].weight);
    }

    /// <summary>
    /// �������� �߰���
    /// </summary>
    /// <param name="vo">�߰��� �������� vo</param>
    /// <returns>false when fail</returns>
    static public bool AddItem(ItemVO vo)
    {
        if (inst.inventory.ContainsKey(vo.itemEnum))
        {
            inst.inventory[vo.itemEnum].count = 1;
            return true;
        }

        Debug.LogError($"AddItem: Cannot find key: {vo.itemEnum}");
        return false;
    }

    /// <summary>
    /// �������� �ϳ� �߰���
    /// </summary>
    /// <param name="itemEnum">�߰��� �������� enums</param>
    /// <returns>false when fail</returns>
    static public bool AddItem(ItemEnum itemEnum)
    {
        if (inst.inventory.ContainsKey(itemEnum))
        {
            inst.inventory[itemEnum].count = 1;
            return true;
        }

        Debug.LogError($"AddItem: Cannot find key: {itemEnum}");
        return false;
    }

    #endregion
}