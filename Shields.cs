using Dawnsbury.Core;
using Dawnsbury.Core.CombatActions;
using Dawnsbury.Core.Creatures;
using Dawnsbury.Core.Mechanics;
using Dawnsbury.Core.Mechanics.Core;
using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Core.Mechanics.Treasure;
using Dawnsbury.Modding;

namespace MoreItems;

public class Shields
{
    public static void Load()
    {
        ModManager.RegisterNewItemIntoTheShop("MoreItems.Shields.FortresShield", (ItemName itemName) =>
        {
            return new Item(itemName, IllustrationName.TowerShield, "Fortress Shield", 1, 20, Trait.Shield, Trait.Martial, Trait.Melee, ModTraits.Hefty14, ModTraits.ModName)
            {
                StateCheckWhenWielded = (Creature user, Item _) =>
                {
                    user.AddQEffect(new(ExpirationCondition.Ephemeral)
                    {
                        BonusToAllSpeeds = (QEffect _) => user.Abilities.Strength < 2 ? new Bonus(-4, BonusType.Untyped, "fortress shield", false) : new Bonus(-2, BonusType.Untyped, "fortress shield", false),
                        BonusToDefenses = (QEffect _, CombatAction? _, Defense defense) => defense == Defense.AC && user.HasEffect(QEffectId.RaisingAShield) ? new(3, BonusType.Circumstance, "fortress shield raised", true) : null
                    });
                }
            }
            .WithMainTrait(Trait.SteelShield)
            .WithWeaponProperties(new WeaponProperties("1d6", DamageKind.Bludgeoning))
            .WithShieldProperties(6)
            .WithDescription("This portable wall is slightly larger than a tower shield. Raising it gives you a +3 circumstance bonus to AC, but its size reduces your speed by 10 feet.");
        });
    }
}