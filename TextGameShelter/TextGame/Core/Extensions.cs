using Shelter.Model;

namespace Shelter.Core;

public static class Extensions
{
    // 아이템 이름이 비어있는 경우 => Null
    public static bool IsEmptyItem(this IItem item) => string.IsNullOrEmpty(item.Name);

    // 아이템 타입 => 문자열 변환
    public static string TypeToString(this EquipType type)
    {
        return type switch
        {
            EquipType.Weapon => "주 무기",
            EquipType.Armor => "방어구",
            _ => string.Empty
        };
    }

    // 아이템 능력치 => 문자열 변환
    public static string StatToString(this ItemEquip item)
    {
        return item.Type switch
        {
            EquipType.Weapon => "공격력 +" + item.Stat,
            EquipType.Armor => "방어력 +" + item.Stat,
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
}
