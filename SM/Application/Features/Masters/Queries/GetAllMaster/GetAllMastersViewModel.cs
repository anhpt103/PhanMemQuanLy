namespace Application.Features.Masters.Queries.GetAllMaster
{
    public class GetAllMastersViewModel
    {
        public int Id { get; set; }
        public int TypeMasters { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public long? Parent { get; set; }
        public string Describe { get; set; }
        public virtual bool IsDelete { get; set; }
    }
}
