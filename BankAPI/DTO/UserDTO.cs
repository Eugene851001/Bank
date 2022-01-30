using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Sex { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string PassportId { get; set; }
        public string BirthPlace { get; set; }
        public int? ResidenceCity { get; set; }
        public string ResidenceAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public byte? MaritalStatus { get; set; }
        public byte? Citizenship { get; set; }
        public short? Disability { get; set; }
        public bool? IsRetiree { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public bool? IsConscripted { get; set; }
    }
}
