namespace WizardAcademyDropouts.Domain.Entities.Base;

using System.ComponentModel.DataAnnotations;

public class EntityBase : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public bool IsNew => Id == 0;

    public override string ToString() => Name;

    public EntityBase() { Id = 0; }

    public EntityBase(int id, string name)
    {
        Id = id;
        Name = name;
    }

}