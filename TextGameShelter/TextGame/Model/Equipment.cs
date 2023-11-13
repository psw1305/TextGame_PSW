using Shelter.Core;
using Shelter.Model.Item;

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
        equipped.TryGetValue(slot, out var item);

        // 같은 장비를 착용중 인가?
        if (item == itemEquip)
        {
            Unequip(slot);
            return;
        }

        // 해당 장비창이 비어있지 않은가?
        if (!equipped[slot].IsEmptyItem())
        {
            Unequip(slot);
        }

        equipped[slot] = itemEquip;
        AddStat(equipped[slot].StatType, equipped[slot].Stat);
        equipped[slot].IsEquipped = true;
    }

    /// <summary>
    /// 해당 장비 슬롯 장착 해제
    /// </summary>
    /// <param name="slot"></param>
    public void Unequip(EquipSlot slot)
    {
        MinusStat(equipped[slot].StatType, equipped[slot].Stat);
        equipped[slot].IsEquipped = false;
        equipped[slot] = ItemEquip.Empty;
    }

    private void AddStat(StatType statType, int stat)
    {
        switch (statType)
        {
            case StatType.ATK:
                Game.Player.Atk += stat;
                break;
            case StatType.DEF:
                Game.Player.Def += stat;
                break;
            case StatType.ACC:
                Game.Player.Acc += stat;
                break;
            case StatType.EVA:
                Game.Player.Eva += stat;
                break;
        }
    }

    private void MinusStat(StatType statType, int stat)
    {
        switch (statType)
        {
            case StatType.ATK:
                Game.Player.Atk -= stat;
                break;
            case StatType.DEF:
                Game.Player.Def -= stat;
                break;
            case StatType.ACC:
                Game.Player.Acc -= stat;
                break;
            case StatType.EVA:
                Game.Player.Eva -= stat;
                break;
        }
    }
}