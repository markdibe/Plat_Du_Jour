using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            RatingImages = new HashSet<RatingImage>();
        }

        [Key]
        public int OrderId { get; set; }
        [ForeignKey(nameof(DailyPlate))]
        [Required]
        public int DailyPlateId { get; set; }
        [Required]
        [Range(1,20)]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ClientId { get; set; }
        public decimal? Rating { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(20000)]
        public string RatingDescription { get; set; }
        public bool Approved { get; set; }

        public virtual ApplicationUser Client { get; set; }
        public virtual DailyPlate DailyPlate { get; set; }
        public virtual ICollection<RatingImage> RatingImages { get; set; }
    }
}
