using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.Dto
{
    public class VillaDTO
    {
        public VillaDTO()
        {
            Name = string.Empty;
            ImageUrl = string.Empty;
            Details = string.Empty;
            Amenity = string.Empty;
        }

        public VillaDTO(Villa villa)
        {
            Id= villa.Id;
            Name= villa.Name;
            Details= villa.Details;
            Rate= villa.Rate;
            Sqft= villa.Sqft;
            Occupancy= villa.Occupancy;
            ImageUrl= villa.ImageUrl;
            Amenity= villa.Amenity;
        }        

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
