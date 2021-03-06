namespace Core.Entities
{
    public class Business : BaseEntity
    {   
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PIN { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public BusinessCategory BusinessCategory { get; set; }
        public int BusinessCategoryId { get; set; }

    }
}