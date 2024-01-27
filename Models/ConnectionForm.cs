using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Models
{
    public class ConnectionForm
    {
        public int Id { get; set; }

        [ForeignKey("ConnectionType")]
        [Display(Name = "Connection Type")]
        [Required]
        public int ConnectionTypeId { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Customer_Name { get; set; }

        [Display(Name = "S/O, D/O, W/O")]
        [Required]
        public string FamilyName { get; set; }

        [Display(Name = "Town, Village, Sector")]
        [Required(ErrorMessage = "Please fill this field")]
        public string TownAddress { get; set; }

        [Display(Name = "City/District")]
        [Required(ErrorMessage = "Please fill this field")]
        public string City { get; set; }

        [Display(Name = "Nearest Place (LandMark)")]
        [Required(ErrorMessage = "Please fill this field")]
        public string NearestPlace { get; set; }

        [Display(Name = "Landline No")]
        [DataType(DataType.PhoneNumber)]
        public string TelePhone { get; set; }

        [Display(Name = "Cell No")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression("^(\\+923)[0-4]{1}[0-9]{1}[0-9]{7}$", ErrorMessage = "Cell Number is invalid")]
        public string CellNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [StringLength(15)]
        [Required]
        public string CNIC { get; set; }

        [Required]
        [Display(Name = "Natural Gas Required For")]
        public string RequiredFor { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Nearest SNGPL Consumer No")]
        [StringLength(11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Consumer Number must be numeric")]
        public string NearestConsumerNo { get; set; }

        [Display(Name = "Owner of Premises (if you're not)")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner's CNIC")]
        public string OwnerCNIC { get; set; }

        [DisplayName("Nearest Gas Bill")]
        public string NearestGasBillImage { get; set; }

        [NotMapped]
        [Display(Name = "Nearest Consumer Gas Bill")]
        [Required(ErrorMessage = "Nearest Gas Bill is Required")]
        public IFormFile NearestGasBillFile { get; set; }

        [Display(Name = "Electricity Bill")]
        public string ElectricityBillImage { get; set; }

        [NotMapped]
        [Display(Name = "Electricity Bill")]
        [Required(ErrorMessage = "Electricity Bill is Required")]
        public IFormFile ElectricityBillFile { get; set; }

        public DateTime DateSubmitted { get; set; }
        public string Status { get; set; }

        public int Token { get; set; }

        public ConnectionType ConnectionType { get; set; }
    }
}