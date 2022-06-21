namespace Domain
{
    public class Setting : Identifier
    {
        public string Key { get; set; }
        public string ObjectType { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
