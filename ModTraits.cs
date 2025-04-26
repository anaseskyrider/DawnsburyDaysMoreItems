using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Modding;

namespace MoreItems;

public static class ModTraits // (Anase) TODO: double check that static is the keyword I want. Maybe abstract. Might have a LoadTraits() func in this class to actually register these enums?
{
    public static Trait ModName = ModManager.RegisterTrait(
        "MoreItems", // (Anase) IDE hints say this is called displayName, but this is a technical string, right? Should this be something like Mods.MoreItems?
        new TraitProperties(
            "More Items",
            true));

    // Technical trait which signifies that the item can change from 1h to 2h grip.
    public static Trait TwoHandable = ModManager.RegisterTrait(
        "TwoHandable",
        new TraitProperties(
            "Two-Handable",
            false));
}