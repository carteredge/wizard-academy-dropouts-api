namespace WizardAcademyDropouts.Domain.Entities;

using Base;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

public enum Grade
{
    A = 3,
    B = 2,
    C = 1,
    D = 0,
    F = -1,
}

public class Character : EntityBase
{
    public int Hp { get; set; } = 5;

    public int HpMax { get; set; } = 5;

    [ForeignKey(nameof(Failure))]
    public int FailureId { get; set; }

    public Failure? Failure { get; set; }

    [ForeignKey(nameof(Knack))]
    public int KnackId { get; set; }

    public Knack? Knack { get; set; }

    public Grade Conjuration { get; set; }

    public Grade Elementalism { get; set; }

    public Grade Enchantment { get; set; }

    public Grade Illusion { get; set; }

    public Grade Naturalism { get; set; }

    public Grade Necromancy { get; set; }
    
    public ICollection<Item> Inventory { get; set; } = new List<Item>();

    public int UserId { get; set; }

    public Character(
        int id,
        string name,
        int hp,
        int hpMax,
        int failureId,
        int knackId,
        Grade conjuration,
        Grade elementalism,
        Grade enchantment,
        Grade illusion,
        Grade naturalism,
        Grade necromancy,
        int userId)
    {
        Id = id;
        Name = name;
        Hp = hp;
        HpMax = hpMax;
        FailureId = failureId;
        KnackId = knackId;
        Conjuration = conjuration;
        Elementalism = elementalism;
        Enchantment = enchantment;
        Illusion = illusion;
        Naturalism = naturalism;
        Necromancy = necromancy;
        Inventory = new List<Item>();
        UserId = userId;
    }

    public Character() {}

    // public Character (string name, int? hp, int? hpMax, Failure? failure, Knack? knack, Grade conjuration,
    //     Grade elementalism, Grade enchantment, Grade illusion, Grade naturalism, Grade necromancy, List<Item>? inventory)
    //     : base(name)
    // {
    //     Name = name;
    //     Hp = hp ?? 5;
    //     HpMax = hpMax ?? 5;
    //     Failure = failure;
    //     Knack = knack;
    //     Conjuration = conjuration;
    //     Elementalism = elementalism;
    //     Enchantment = enchantment;
    //     Illusion = illusion;
    //     Naturalism = naturalism;
    //     Necromancy = necromancy;
    //     Inventory = inventory ?? new();
    // }

    // public Character (string name, int? hp, int? hpMax, int failureId, int knackId,
    //     int conjurationModifier, int elementalismModifier, int enchantmentModifier,
    //     int illusionModifier, int naturalismModifier, int necromancyModifier, List<Item> inventory) :
    //     this(name, hp, hpMax, Failure.FromId(failureId), Knack.FromId(knackId),
    //     (Grade)conjurationModifier, (Grade)elementalismModifier, (Grade)enchantmentModifier,
    //     (Grade)illusionModifier, (Grade)naturalismModifier, (Grade)necromancyModifier, inventory) { }
    
    // public Character (string name, int? hp, int? hpMax, string failureName, string knackName,
    //     string conjurationGrade, string elementalismGrade, string enchantmentGrade,
    //     string illusionGrade, string naturalismGrade, string necromancyGrade, List<Item> inventory) :
    //     this(name, hp, hpMax, Failure.FromNameIgnoreCase(failureName), Knack.FromNameIgnoreCase(knackName),
    //     GradeFromLetter(conjurationGrade), GradeFromLetter(elementalismGrade), GradeFromLetter(enchantmentGrade),
    //     GradeFromLetter(illusionGrade), GradeFromLetter(naturalismGrade), GradeFromLetter(necromancyGrade), inventory) { }

    public static Grade GradeFromLetter(string letterGrade)
    {
        Grade grade;
        Enum.TryParse(letterGrade, out grade);
        return grade;
    }

    public void AddInventoryItem(string name)
    {
        Inventory.Add(new Item(0, name, Id));
    }

    public void AddInventoryItems(IEnumerable<string> names)
    {
        Inventory.ToList().AddRange(names.Select(name => new Item(0, name, Id)));
    }
}