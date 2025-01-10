namespace WizardAcademyDropouts.Domain.Entities;

using Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Item : EntityBase
{
    [Required]
    [ForeignKey(nameof(Character))]
    public int CharacterId { get; set; }

    [JsonIgnore]
    public Character Character { get; set; }

    public Item() { }

    public Item (int id, string name, int characterId) {
        Id = id;
        Name = name;
        CharacterId = characterId;
    }
}