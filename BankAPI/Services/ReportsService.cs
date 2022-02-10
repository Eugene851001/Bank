using System;
using System.Collections.Generic;
using BankAPI.Helpers;
using BankDatabase;

namespace BankAPI.Services
{
    public class ReportsService
    {

        public static Dictionary<DateTime, decimal> GenerateDepositReport(Deposit contract) =>
            GenerateReportWithInterval(Constants.Intervals.Month, contract);

        public static Dictionary<DateTime, decimal> GenerateCreditReport(Credit credit)
        {
            var result = new Dictionary<DateTime, decimal>();

            DateTime currentDate = credit.StartDate.AddDays(Constants.Intervals.Month);
            int totalDays = (credit.EndDate - credit.StartDate).Days;
            decimal mainAccountSum = 0;

            while (currentDate <= credit.EndDate)
            { 
                decimal sum = (credit.Sum) * Constants.Intervals.Month / totalDays;
                decimal tempSum = sum;
                if (credit.Annuity)
                {
                    sum += credit.Sum * (decimal)credit.Percent * Constants.Intervals.Month / (100 * totalDays);
                }
                else
                {
                    sum += (credit.Sum - mainAccountSum) * (decimal)credit.Percent * Constants.Intervals.Month / (100 * totalDays);
                }

                mainAccountSum += tempSum;

                result.Add(currentDate, sum);
                currentDate = currentDate.AddDays(Constants.Intervals.Month);
            }

            int remainDays = (credit.EndDate - credit.StartDate).Days % Constants.Intervals.Month;


            if (remainDays != 0)
            {
                decimal sum = (credit.Sum) * remainDays / totalDays;
                if (credit.Annuity)
                {
                    sum += credit.Sum * (decimal)credit.Percent * remainDays / (100 * totalDays);
                }
                else
                {
                    sum += (credit.Sum - mainAccountSum) * (decimal)credit.Percent * remainDays / (100 * totalDays);
                }

                result.Add(credit.EndDate, sum);
            }

            return result;
        }

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

    }
}
