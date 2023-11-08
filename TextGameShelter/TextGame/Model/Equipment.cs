using Shelter.Core;

namespace Shelter.Model;

public enum EquipSlot
{
    Weapon,
    Armor,
}

public class Equipment
{
    private Dictionary<EquipSlot, ItemEquip> equipped = new();

    public Equipment() 
    {
        var slots = Enum.GetValues<EquipSlot>();

        foreach (var slot in slots)
        {
            if (equipped.GetValueOrDefault(slot) != null) continue;
            equipped[slot] = ItemEquip.Empty;
        }
    }

    /// <summary>
    /// 장비에서 아이템 장착
    /// </summary>
    /// <param name="slot">장비 슬롯</param>
    /// <param name="itemEquip">장착할 아이템</param>
    public void Equip(EquipSlot slot, ItemEquip itemEquip)
    {
        // 해당 장비창이 비어있지 않은가?
        if (!equipped[slot].IsEmptyItem())
        {
            Unequip(slot);
        }

        equipped[slot] = itemEquip;
        equipped[slot].IsEquipped = true;
    }

    /// <summary>
    /// 해당 장비 슬롯 장착 해제
    /// </summary>
    /// <param name="slot"></param>
    public void Unequip(EquipSlot slot)
    {
        equipped[slot].IsEquipped = false;
        equipped[slot] = ItemEquip.Empty;
    }
}