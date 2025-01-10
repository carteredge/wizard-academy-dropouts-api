namespace WizardAcademyDropouts.Domain.Entities;

using Base;

public enum KnackType
{
    Bardic = 1,
    Clairvoyant,
    Legacy,
    Scrappy,
    Sturdy,
    Windborne,
}

public class Knack(int id, string name, string description) : SelectEntity(id, name)
{
    public static readonly Knack Bardic = new Knack(
        (int)KnackType.Bardic, KnackType.Bardic.ToString(),
        "Outside of combat, you can use double the number of words for a spell if the words are phrased as a rhyming couplet.");
    public static readonly Knack Clairvoyant = new Knack(
        (int)KnackType.Clairvoyant, KnackType.Clairvoyant.ToString(),
        "You can sense the magic around you. You see auras of magic and can feel magic radiating off of items and spells. " +
        "You get +1 to knowledge rolls for anything you can see or touch.");
    public static readonly Knack Legacy = new Knack(
        (int)KnackType.Legacy, KnackType.Legacy.ToString(),
        "One or both of your parents is a Wizard Academy graduate and a generous donor. " +
        "You start with one extra item from the common loot table.");
    public static readonly Knack Scrappy = new Knack(
        (int)KnackType.Scrappy, KnackType.Scrappy.ToString(),
        "When all else fails, you aren't afraid to resort to good, old fashioned fisticuffs. " +
        "You're stronger than the average wizard, and you can make a physical attack against an enemy as an action, " +
        "dealing 1 damage to them. The enemy must be within striking damage or you must have something potentially " +
        "dangerous to throw.");
    public static readonly Knack Sturdy = new Knack(
        (int)KnackType.Sturdy, KnackType.Sturdy.ToString(),
        "You are remarkably resilient. You have +2 max HP.");
    public static readonly Knack Windborne = new Knack(
        (int)KnackType.Windborne, KnackType.Windborne.ToString(),
        "Whether with wings or an innate affinity for wind, you can fly.");
    public string Description { get; set; } = description;

    public static Knack FromId(int id) => FromId<Knack>(id);

    public static Knack FromName(string name) => FromName<Knack>(name);
    public static Knack FromNameIgnoreCase(string name) => FromNameIgnoreCase<Knack>(name);

    // public static Knack? FromId(int id) {
    //     switch (id) {
    //         case (int)KnackType.Bardic:
    //             return Bardic;
    //         case (int)KnackType.Clairvoyant:
    //             return Clairvoyant;
    //         case (int)KnackType.Legacy:
    //             return Legacy;
    //         case (int)KnackType.Scrappy:
    //             return Scrappy;
    //         case (int)KnackType.Sturdy:
    //             return Sturdy;
    //         case (int)KnackType.Windborne:
    //             return Windborne;
    //         default:
    //             return null;
    //     }
    // }

    // public static Knack? FromName(string name) {
    //     var knackType = KnackTypeFromName(name);
    //     switch (knackType) {
    //         case KnackType.Bardic:
    //             return Bardic;
    //         case KnackType.Clairvoyant:
    //             return Clairvoyant;
    //         case KnackType.Legacy:
    //             return Legacy;
    //         case KnackType.Scrappy:
    //             return Scrappy;
    //         case KnackType.Sturdy:
    //             return Sturdy;
    //         case KnackType.Windborne:
    //             return Windborne;
    //         default:
    //             return null;
    //     }
    // }

    // private static KnackType KnackTypeFromName(string name) {
    //     KnackType knackType;
    //     Enum.TryParse(name, out knackType);
    //     return knackType;
    // }
}