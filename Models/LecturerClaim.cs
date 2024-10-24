using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class LecturerClaim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalAmount => HoursWorked * HourlyRate;

        public string AdditionalNotes { get; set; }

        public string FileName { get; set; }

        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;

        public DateTime SubmissionDate { get; set; } = DateTime.Now;
    }

    public enum ClaimStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
