using Dawnsbury.Core;
using Dawnsbury.Core.CombatActions;
using Dawnsbury.Core.Creatures;
using Dawnsbury.Core.Mechanics.Core;
using Dawnsbury.Core.Mechanics;
using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Core.Mechanics.Targeting;
using Dawnsbury.Core.Mechanics.Treasure;
using Dawnsbury.Modding;

namespace MoreItems;

public class Armors
{
    public static void Load()
    {
        ModManager.RegisterNewItemIntoTheShop("MoreItems.Armors.BastionPlate", (ItemName itemName) =>
        {
            var item = new Item(itemName, IllustrationName.FullPlate, "Bastion Plate", 2, 33, Trait.HeavyArmor, Trait.Bulwark, ModTraits.ModName)
            .WithArmorProperties(new(6, 0, 3, -3, 18));

            return AddEntrench(item, Trait.Melee, ModTraits.EntrenchMelee);
        });
    }

    #region Armor Methods

    public static Item AddEntrench(Item item, Trait traitToSelectOn, Trait traitToAdd)
    {
        item.Traits.Add(traitToAdd);

        return item.WithItemAction((Item _, Creature wearer) =>
        {
            return new CombatAction(wearer, item.Illustration, "Entrench", [], $"You gain a +1 circumstance bonus to AC against {traitToSelectOn.ToString().ToLower()} attacks until the start of your next turn.", Target.Self())
                .WithActionCost(1)
                .WithSoundEffect(Dawnsbury.Audio.SfxName.RaiseShield)
                .WithEffectOnSelf(async (CombatAction _, Creature user) =>
                {
                    user.AddQEffect(new("Entrenched", $"You have a +1 circumstance bonus to AC against {traitToSelectOn.ToString().ToLower()} attacks.", ExpirationCondition.ExpiresAtStartOfSourcesTurn, user, item.Illustration)
                    {
                        BonusToDefenses = (QEffect _, CombatAction? action, Defense defense) =>
                        {
                            if (action == null || !action.HasTrait(traitToSelectOn) || !action.HasTrait(Trait.Attack) || defense != Defense.AC)
                            {
                                return null;
                            }

                            return new(1, BonusType.Circumstance, "entrenched", true);
                        }
                    });
                });
        }, (_, _) => true);
    }

    #endregion
}