namespace Utilities.ExpressionBuilder
{
    public enum Operator
    {
        //[Display(Name = nameof(Language.Equal), ResourceType = typeof(Language))]
        Equals = 1,
        //[Display(Name = nameof(Language.NotEqual), ResourceType = typeof(Language))]
        NotEqual = 2,
        //[Display(Name = nameof(Language.Contains), ResourceType = typeof(Language))]
        Contains = 3,
        //[Display(Name = nameof(Language.StartsWith), ResourceType = typeof(Language))]
        StartsWith = 4,
        //[Display(Name = nameof(Language.EndsWith), ResourceType = typeof(Language))]
        EndsWith = 5,
        //[Display(Name = nameof(Language.GreaterThan), ResourceType = typeof(Language))]
        GreaterThan = 6,
        //[Display(Name = nameof(Language.GreaterOrEqualThan), ResourceType = typeof(Language))]
        GreaterOrEqualThan = 7,
        //[Display(Name = nameof(Language.LessThan), ResourceType = typeof(Language))]
        LessThan = 8,
        //[Display(Name = nameof(Language.LessOrEqualThan), ResourceType = typeof(Language))]
        LessOrEqualThan = 9
    }
}
