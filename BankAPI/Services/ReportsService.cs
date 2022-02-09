using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Helpers;
using BankDatabase;
using Excel = Microsoft.Office.Interop.Excel;

namespace BankAPI.Services
{
    public class ReportsService
    {
        public static Dictionary<DateTime, decimal> GenerateReportDay(Deposit contract) =>
            GenerateReportWithInterval(1, contract);

        public static Dictionary<DateTime, decimal> GenerateReportMonth(Deposit contract) =>
            GenerateReportWithInterval(Constants.Intervals.Month, contract);

        private static Dictionary<DateTime, decimal> GenerateReportWithInterval(int daysInterval, Deposit contract)
        {
            var result = new Dictionary<DateTime, decimal>();

            if (!contract.Revocable)
            {
                result.Add(contract.EndDate, contract.Sum + (decimal)contract.Percent * contract.Sum / 100);
                return result;
            }

            int totalDays = (contract.EndDate - contract.StartDate).Days;
            int totalIntervals = totalDays / daysInterval;
            decimal intervalPayment = contract.Sum * ((decimal)contract.Percent / 100) * daysInterval / totalDays;
            for (int i = 1; i <= totalIntervals; i++)
            {
                result.Add(contract.StartDate.AddDays(daysInterval *  i), intervalPayment);
            }

            int remainDays = (contract.EndDate - contract.StartDate).Days % daysInterval;
            
            if (remainDays == 0)
            {
                result[contract.EndDate] += contract.Sum;
                return result;
            }

            decimal lastPayment = contract.Sum * (decimal)contract.Percent / 100 / remainDays + contract.Sum;

            result.Add(contract.EndDate, lastPayment);

            return result;
        }

        private static Dictionary<DateTime, decimal> GenerateCreditReport(Credit credit)
        {
            var result = new Dictionary<DateTime, decimal>();

            DateTime currentDate = credit.StartDate.AddDays(Constants.Intervals.Month);

            while (currentDate <= credit.EndDate)
            {
                decimal sum = credit.Annuity ? 
                    GetTotalSum(credit, Constants.Intervals.Month) 
                    : GetPercentSum(credit, Constants.Intervals.Month);

                result.Add(currentDate, sum);

                currentDate = currentDate.AddDays(Constants.Intervals.Month);
            }

            int remainDays = (credit.EndDate - credit.StartDate).Days % Constants.Intervals.Month;

            if (remainDays == 0)
            {
                if (!credit.Annuity)
                {
                    result.Add(credit.EndDate, credit.Sum);
                }
            }
            else
            {
                decimal sum = credit.Annuity ?
                    GetTotalSum(credit, remainDays)
                    : GetPercentSum(credit, remainDays) + credit.Sum;

                result.Add(credit.EndDate, sum);
            }

            return result;
        }

        private static decimal GetTotalSum(Credit credit, int days) =>
            (credit.Sum * (decimal)credit.Percent / 100 + credit.Sum) * days /
                (credit.EndDate - credit.StartDate).Days;

        private static decimal GetPercentSum(Credit credit, int days) =>
            (credit.Sum * (decimal)credit.Percent / 100) * days /
                (credit.EndDate - credit.StartDate).Days;

    }
}
