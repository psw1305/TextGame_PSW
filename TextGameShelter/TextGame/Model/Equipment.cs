using Shelter.Core;

namespace Shelter.Model;

public enum EquipSlot
{
    Weapon,
    Armor,
}

public class Equipment
{
    public Dictionary<EquipSlot, Item_Equip> equipped = new();
    public IReadOnlyDictionary<EquipSlot, Item_Equip> Equipped => equipped;

    public Equipment() 
    {
        var slots = Enum.GetValues<EquipSlot>();

        foreach (var slot in slots)
        {
            if (equipped.GetValueOrDefault(slot) != null) continue;

            equipped[slot] = Item_Equip.Empty;
        }
    }

    /// <summary>
    /// 장비에서 아이템 장착
    /// </summary>
    /// <param name="slot">장비 슬롯</param>
    /// <param name="itemEquip">장착할 아이템</param>
    /// <returns></returns>
    public Item_Equip Equip(EquipSlot slot, Item_Equip itemEquip)
    {
        var unEquipped = Item_Equip.Empty;

        // 해당 장비창이 비어있지 않은가?
        if (!equipped[slot].IsEmptyItem())
        {
            unEquipped = UnEquip(slot);
            Equip(slot, itemEquip);
        }
        else
        {
            equipped[slot] = itemEquip;
        }

        return unEquipped;
    }

    /// <summary>
    /// 해당 장비 슬롯 장착 해제
    /// </summary>
    /// <param name="slot"></param>
    /// <returns></returns>
    public Item_Equip UnEquip(EquipSlot slot)
    {
        equipped.TryGetValue(slot, out var item);
        equipped[slot] = Item_Equip.Empty;
        return item ?? Item_Equip.Empty;
    }
}