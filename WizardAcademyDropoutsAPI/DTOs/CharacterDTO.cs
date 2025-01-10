namespace WizardAcademyDropouts.DTOs;

public class CharacterDTO : BaseDTO
{
    public int Hp { get; set; }
    public int HpMax { get; set; }
    public string Failure { get; set; }
    public string Knack { get; set; }
    public string Conjuration { get; set; }
    public string Elementalism { get; set; }
    public string Enchantment { get; set; }
    public string Illusion { get; set; }
    public string Naturalism { get; set; }
    public string Necromancy { get; set; }
    public List<string> Inventory { get; set; } = new();
}