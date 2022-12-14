using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Text.Json.Serialization;

namespace EFashion.Web.Models
{
    [Table(name: "Items")]
    public class Item
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int ItemId { get; set; }

        [Required]
        [StringLength(150)]
        virtual public string ItemName { get; set; }

        [Required]
        [StringLength(20)]
        virtual public string ItemType { get; set; }

        [StringLength(350)]
        virtual public string ItemDescription { get; set; }

        [Required]
        [DefaultValue(true)]
        virtual public bool IsAvailable { get; set; }

        [Required]
        virtual public decimal? Price { get; set; }

      

        #region Navigation Properties to the Item category model

        virtual public int ItemCategoryId { get; set; }
        [JsonIgnore]

        [ForeignKey(nameof(Item.ItemCategoryId))]

        public ItemCategory ItemCategory { get; set; }

        #endregion

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
       
       
        [JsonIgnore]
        public ICollection<Payment> Payments { get; set; }

    }
}
