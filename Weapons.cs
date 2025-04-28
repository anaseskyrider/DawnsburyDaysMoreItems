using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Core.Mechanics.Treasure;
using Dawnsbury.Display.Illustrations;
using Dawnsbury.Modding;
using MoreItems;

namespace MoreItems;

public static class Weapons
{
    public static void Load()
    {
        
        // Butchering Axe
        ModManager.RegisterNewItemIntoTheShop(
            "MoreItems.Weapons.ButcheringAxe",
            itemName => new Item(
                    itemName,
                    new ModdedIllustration("ItemAssets/battle-axe.png"),
                    "Butchering Axe",
                    0,
                    8,
                    [Trait.Uncommon, Trait.Orc, Trait.Shove, Trait.Sweep, Trait.TwoHanded, Trait.Axe, Trait.Advanced, ModTraits.ModName /* <-- Last trait in list */, ])
                .WithWeaponProperties(new WeaponProperties("1d12", DamageKind.Slashing)));
    }

    /// <summary>
    /// Turns an item into a Modular item.
    /// </summary>
    public static Item WithModular(Item itemToModify, params DamageKind[] modulars)
    {
        // Correlate params array with traits?
        // Or perhaps just replace that with a Trait parameter.
        
        // Extra item behavior here?
        // Or perhaps a RegisterActionOn type logic is needed to add core rule behavior to items that are modular?
        
        return itemToModify;
    }
    
    /// <summary>
    /// Turns an item into one with a Two Hand dX trait.
    /// </summary>
    public static Item WithTwoHandable(Item itemToModify, Trait twoHTrait)
    {
        itemToModify.Traits.Add(ModTraits.TwoHandable); // See ModTraits for definition.
        
        // Extra item behavior here?
        // Or perhaps a RegisterActionOn type logic is needed to add core rule behavior to items that are twohandable?
        
        return itemToModify;
    }
}