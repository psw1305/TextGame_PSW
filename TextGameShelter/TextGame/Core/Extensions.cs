using Shelter.Model.Item;

namespace Shelter.Core;

public static class Extensions
{
    // 아이템 이름이 비어있는 경우 => Null
    public static bool IsEmptyItem(this IItem item) => string.IsNullOrEmpty(item.Name);

    // 아이템 타입 => 문자열 변환
    public static string TypeToString(this ItemType type)
    {
        return type switch
        {
            ItemType.Equipment => "장비",
            ItemType.Useable => "소모품",
            _ => string.Empty
        };
    }

    // 장비 타입 => 문자열 변환
    public static string TypeToString(this EquipType type)
    {
        return type switch
        {
            EquipType.Weapon => "무기",
            EquipType.Armor => "방어구",
            _ => string.Empty
        };
    }

    // 아이템 능력치 => 문자열 변환
    public static string StatToString(this ItemEquip item)
    {
        return item.StatType switch
        {
            StatType.ATK => "공격 +" + item.Stat,
            StatType.DEF => "방어 +" + item.Stat,
            StatType.ACC => "명중 +" + item.Stat,
            StatType.EVA => "회피 +" + item.Stat,
            _ => string.Empty
        };
    }

    // 아이템 착용 여부 확인
    public static string EquippedToString(this ItemEquip item)
    {
        if (item.IsEquipped)
        {
            return "착용중";
        }
        else
        {
            return string.Empty;
        }
    }

    public static int ToPrice(this IItem item)
    {
        return (int)(item.Price * 0.8f);
    }
}
