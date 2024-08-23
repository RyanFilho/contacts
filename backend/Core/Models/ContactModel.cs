namespace Core.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }

        public int UserId { get; set; }

        public decimal Name { get; set; }

        public required string PhoneNumber { get; set; }        

        public DateTime SaveDate { get; set; }
    }
}
