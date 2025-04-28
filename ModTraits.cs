using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Modding;

namespace MoreItems;

public static class ModTraits // (Anase) TODO: double check that static is the keyword I want. Maybe abstract. Might have a LoadTraits() func in this class to actually register these enums?
{
    public readonly static Trait EntrenchMelee = ModManager.RegisterTrait("MoreItems.EntrenchMelee", new TraitProperties("Entrench Melee", true, "While wearing this armor, you can spend a single action to gain a +1 circumstance bonus to AC against melee attacks until the start of your next turn."));

    public readonly static Trait Hefty14 = ModManager.RegisterTrait("MoreItems.Armors.Hefty14", new TraitProperties("Hefty 14", true, "While holding this item, you have a -10 foot penalty to your speed unless you meet have at least 14 strength."));

    public readonly static Trait ModName = ModManager.RegisterTrait(
        "MoreItems", // (Anase) IDE hints say this is called displayName, but this is a technical string, right? Should this be something like Mods.MoreItems?
        new TraitProperties(
            "More Items",
            true));

    // Technical trait which signifies that the item can change from 1h to 2h grip.
    public readonly static Trait TwoHandable = ModManager.RegisterTrait(
        "TwoHandable",
        new TraitProperties(
            "Two-Handable",
            false));
}