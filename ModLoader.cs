using Dawnsbury.Modding;

namespace MoreItems;

public class ModLoader
{
    [DawnsburyDaysModMainMethod]
    public static void LoadMod()
    {
        //////////////////////
        // Class File Loads //
        //////////////////////
        Weapons.Load();
        Armors.Load();
        Shields.Load();
    }

    // (Anase) I propose that generalized methods for altering items are done in the style of With() methods. For now, these funcs
    // can just go int the most appropriate class folder -- like Modular for Weapons.cs. Using such a function would look like:
    /*
     * Item newWeapon = new Item(stuff);
     * newWeapon = Weapons.WithModular(
     *   newWeapon,
     *   new DamageKind[]{DamageKind.Bludgeoning, DamageKind.Piercing, DamageKind.Slashing});
     */
    
    // (Anase) How should our registry strings look? I propose:
    /*
     * "MoreItems.<appropriate class, e.g. Weapons>.<object name, e.g. ButcheringAxe">
     */
    
    // (Anase) TODO: Do not forget that the OGL copyright file is incomplete.
    // If we can just list all the authors alphabetically, then:
    // - Anase Skyrider
    // - Jake Marohl (that's Dinglebob)
    // - Kyle Coop (that's Coopo)
    // - NathanielDev
    // - SudoTrainer
}