using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class FileUpload
    {
        [Key]
        public int FileId { get; set; }

        [Required]
        public int ClaimId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public byte[] FileContent { get; set; }
    }
}
