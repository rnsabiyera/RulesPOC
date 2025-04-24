using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Driver(string name, int age, int yearsOfExperience)
    {
        public string Name { get; } = name;
        public int Age { get; } = age;
        public int YearsOfExperience { get; } = yearsOfExperience;
    }

    public class InsuranceQuote(Driver driver, decimal basePremium)
    {
        public Driver Driver { get; } = driver;
        public decimal BasePremium { get; } = basePremium;
        public decimal FinalPremium { get; private set; } = basePremium;

        public void ApplySurcharge(decimal amount) => FinalPremium += amount;
        public void ApplyDiscount(decimal amount) => FinalPremium -= amount;
    }

    public class TrafficViolation(Driver driver, DateTime date, string violationType)
    {
        public Driver Driver { get; } = driver;
        public DateTime Date { get; } = date;
        public string ViolationType { get; } = violationType;
    }

    public class Enquiry(bool validBankAccount, bool validAddress, bool customerNamesMatches)
    {
        public bool ValidBankAccount { get; } = validBankAccount;
        public bool ValidAddress { get; } = validAddress;
        public bool CustomerNamesMatch { get; } = customerNamesMatches;
        public void CreateNewEnquiry() => Console.WriteLine("New enquiry created.");
        public void CreateNewCustomerContract() => Console.WriteLine("New Contract, New Customer.");
        public void AddNewContractToExistingCustomer() => Console.WriteLine("Add New Contract, Existing Customer.");

    }
}