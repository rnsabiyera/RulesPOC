using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class ExperiencedDriverDiscountRule : Rule
    {
        public override void Define()
        {
            InsuranceQuote quote = default!;

            When()
                .Match(() => quote, q => CheckDriverExperience(q));

            Then()
                .Do(ctx => quote.ApplyDiscount(50));
        }

        bool CheckDriverExperience(InsuranceQuote quote)
        {
            return quote.Driver.YearsOfExperience > 5;
        }
    }

    public class YoungDriverSurchargeRule : Rule
    {
        public override void Define()
        {
            InsuranceQuote quote = default!;

            When()
                .Match(() => quote, q => CheckDriverAge(q));

            Then()
                .Do(ctx => quote.ApplySurcharge(100));
        }

        bool CheckDriverAge(InsuranceQuote quote)
        {
            return quote.Driver.Age < 25;
        }
    }    


    public class TrafficViolationSurchargeRule : Rule
    {
        public override void Define()
        {
            InsuranceQuote quote = default!;
            IEnumerable<TrafficViolation> violations = default!;
            int totalViolations = 0;

            When()
                .Match(() => quote)
                .Query(() => violations, q => q
                    .Match<TrafficViolation>()
                    .Where(v => v.Driver == quote.Driver,
                        v => v.ViolationType != "Parking",
                        v => v.Date >= DateTime.Now.AddYears(-2))
                    .Collect())
                .Let(() => totalViolations, () => violations.Count())
                .Having(() => totalViolations > 1);

            Then()
                .Do(ctx => quote.ApplySurcharge(20 * totalViolations));
        }
    }

    //public class ValidBankAccountRule : Rule
    //{
    //    public override void Define()
    //    {
    //        Enquiry enquiry = default!;
    //        When()
    //            .Match(() => enquiry, e => e.ValidBankAccount == false);
    //        Then()
    //            .Do(ctx => enquiry.CreateNewEnquiry());
    //    }
    //}

    //public class ValidAddressRule : Rule
    //{
    //    public override void Define()
    //    {
    //        Enquiry enquiry = default!;
    //        When()
    //            .Match(() => enquiry, e => e.ValidBankAccount == true)
    //            .Match(() => enquiry, e => e.ValidAddress == true)
    //            .Match(() => enquiry, e => e.CustomerNamesMatch == false);
    //        Then()
    //            .Do(ctx => enquiry.CreateNewCustomerContract());
    //    }
    //}

    //public class ValidAddressRule : Rule
    //{
    //    public override void Define()
    //    {
    //        Enquiry enquiry = default!;
    //        When()
    //            .Match(() => enquiry, e => e.ValidBankAccount == false)
    //            .Match(() => enquiry, e => e.ValidAddress != false);
    //        Then()
    //            .Do(ctx => enquiry.CreateNewEnquiry());
    //    }
    //}
}
