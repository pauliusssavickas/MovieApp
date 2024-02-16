namespace MovieApp.Models
{
    public class Category
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "name field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]

        public string Name { get; set; }   
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
