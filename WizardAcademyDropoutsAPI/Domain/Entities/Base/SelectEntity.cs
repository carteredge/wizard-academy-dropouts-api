namespace WizardAcademyDropouts.Domain.Entities.Base;

using System.Reflection;

public class SelectEntity(int id, string name) : EntityBase(id, name)
{
    public static IEnumerable<T> GetOptions<T>() where T : SelectEntity =>
        typeof(T).GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(info => info.GetValue(null) as T).Where(value => value != null).Select(value => value!);
    
    public static T FromId<T>(int id) where T : SelectEntity =>
        GetOptions<T>().FirstOrDefault(option => option.Id == id)
            ?? throw new KeyNotFoundException($"{id} is not a valid ID in {typeof(T)}");

    public static T FromName<T>(string name) where T : SelectEntity => 
        GetOptions<T>().FirstOrDefault(option => option.Name == name)
            ?? throw new KeyNotFoundException($"{name} is not a valid name in {typeof(T)}");

    public static T FromNameIgnoreCase<T>(string name) where T : SelectEntity => 
        GetOptions<T>().FirstOrDefault(option => option.Name.ToLower() == name.ToLower())
            ?? throw new KeyNotFoundException($"{name} is not a valid name in {typeof(T)}");
}