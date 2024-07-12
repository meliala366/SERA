namespace PostTestSERA.Model
{
    public class GetResponse
    {
        public int Id { get; set; }
        public string customerName { get; set; }
        public string customerCode { get; set; }
        public string customerAddress { get; set; }
        public int createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedAt { get; set; }
    }
}
