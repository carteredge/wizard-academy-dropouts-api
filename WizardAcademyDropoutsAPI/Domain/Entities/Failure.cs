namespace WizardAcademyDropouts.Domain.Entities;

using Base;

public enum FailureType
{
    DroppedOut = 1,
    KickedOut,
    FailedOut,
}

public class Failure(int id, string name, string summary, string description) : SelectEntity(id, name)
{
    public static readonly Failure DroppedOut = new Failure(
        (int)FailureType.DroppedOut, FailureType.DroppedOut.ToString(), "I dropped out.",
        "I couldn't focus, and I changed my specialty constantly until my professors couldn't take it anymore. " +
        "When you make a roll, you can drop the grade for the discipline of that roll by one letter" +
        "and raise the grade of another discipline by one letter.");
    public static readonly Failure KickedOut = new Failure(
        (int)FailureType.KickedOut, FailureType.KickedOut.ToString(), "I was kicked out.",
        "My spells are extra dangerous. I was kicked out for being a danger to the academy, myself, and everyone around me. " +
        "My spells do +1 damage.");
    public static readonly Failure FailedOut = new Failure(
        (int)FailureType.FailedOut, FailureType.FailedOut.ToString(), "I failed out.",
        "I'm so bad at magic, I'm resistant to it. Prevent 1 magical damage each round.");
    public string Summary { get; set; } = summary;
    public string Description { get; set; } = description;

    public static Failure FromId(int id) => FromId<Failure>(id);

    public static Failure FromName(string name) => FromName<Failure>(name);
    public static Failure FromNameIgnoreCase(string name) => FromNameIgnoreCase<Failure>(name);

    // public static Failure? FromId(int id) {
    //     switch (id) {
    //         case (int)FailureType.DroppedOut:
    //             return DroppedOut;
    //         case (int)FailureType.FailedOut:
    //             return FailedOut;
    //         case (int)FailureType.KickedOut:
    //             return KickedOut;
    //     }
    //     return null;
    // }
    
    // public static Failure? FromName(string name) {
    //     var failureType = FailureTypeFromName(name);
    //     switch (failureType) {
    //         case FailureType.DroppedOut:
    //             return DroppedOut;
    //         case FailureType.FailedOut:
    //             return FailedOut;
    //         case FailureType.KickedOut:
    //             return KickedOut;
    //     }
    //     return null;
    // }

    // private static FailureType FailureTypeFromName(string name) {
    //     FailureType failureType;
    //     Enum.TryParse(name, out failureType);
    //     return failureType;
    // }
}