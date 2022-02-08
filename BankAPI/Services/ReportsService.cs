﻿using System;
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
        public static Dictionary<DateTime, decimal> GenerateReportDay(Contract contract) =>
            GenerateReportWithInterval(1, contract);

        public static Dictionary<DateTime, decimal> GenerateReportMonth(Contract contract) =>
            GenerateReportWithInterval(Constants.Intervals.Month, contract);

        private static Dictionary<DateTime, decimal> GenerateReportWithInterval(int daysInterval, Contract contract)
        {
            var result = new Dictionary<DateTime, decimal>();

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