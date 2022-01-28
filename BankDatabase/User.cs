using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sex { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }
        public string PassportId { get; set; }
        public string BirthPlace { get; set; }
        public int ResidenceCity { get; set; }
        public string ResidenceAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public byte MaritalStatus { get; set; }
        public byte Citizenship { get; set; }
        public short Disability { get; set; }
        public bool IsRetiree { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public bool IsConscripted { get; set; }

        public virtual Country CitizenshipNavigation { get; set; }
        public virtual Disability DisabilityNavigation { get; set; }
        public virtual MaritalStatus MaritalStatusNavigation { get; set; }
        public virtual City ResidenceCityNavigation { get; set; }
    }
}
