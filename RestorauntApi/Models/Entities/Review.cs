using System.ComponentModel.DataAnnotations;

namespace RestorauntApi.Models.Entities
{
    public class Review
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateOnly DateOfVisit { get; set; }
     
        public int? NumberOfGuests { get; set; }
        
        public int? TableNumber { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public bool IsAccepted { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
