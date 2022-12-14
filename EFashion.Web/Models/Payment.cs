using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace EFashion.Web.Models
{
    [Table(name:"Payments")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int PaymentId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string PaymentName { get; set; }

       


        #region Navigation Properties to the Customer Model 
        virtual public int CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Payment.CustomerId))]

        public Customer Customer { get; set; }


        #endregion

        #region Navigation properties to the Item Name
        [Display(Name = "Order Date")]
        virtual public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(Payment.OrderId))]
        virtual public Order Order { get; set; }

        [Required]
        virtual public int ItemId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(Payment.ItemId))]
        virtual public Item Item { get; set; }

        #endregion

        [Required]
        [StringLength(10)]
        virtual public string MobileNumber { get; set; }

        [Required]
        virtual public decimal AmountPaid { get; set; }

    }
}
