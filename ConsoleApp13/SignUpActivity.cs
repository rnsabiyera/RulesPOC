using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Models;

namespace ConsoleApp13
{
    public class SignUpActivity : Activity
    {
        public bool Condition { get; set; } = default!;
        public IActivity? Then { get; set; }
        public IActivity? Else { get; set; }
        protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
        {
            var result = Condition;

            var nextActivity = result ? Then : Else;

            await context.ScheduleActivityAsync(nextActivity, OnChildCompleted);
        }

        private async ValueTask OnChildCompleted(ActivityCompletedContext context)
        {
            await context.CompleteActivityAsync();
        }
    }

    public class BankAccountVerifyActivity : Activity
    {
        public bool Condition { get; set; } = default!;
        public IActivity? Then { get; set; }
        public IActivity? Else { get; set; }

        
        protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
        {
            var result = Condition;

            var nextActivity = result ? Then : Else;

            await context.ScheduleActivityAsync(nextActivity, OnChildCompleted);
        }

        private async ValueTask OnChildCompleted(ActivityCompletedContext context)
        {
            await context.CompleteActivityAsync();
        }
    }

    public class  AddressVerifyActivity : Activity
    {
        public bool Condition { get; set; } = default!;
        public IActivity? Then { get; set; }
        public IActivity? Else { get; set; }
        protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
        {
            var result = Condition;

            var nextActivity = result ? Then : Else;

            await context.ScheduleActivityAsync(nextActivity, OnChildCompleted);
        }

        private async ValueTask OnChildCompleted(ActivityCompletedContext context)
        {
            await context.CompleteActivityAsync();
        }
    }

    public class CustomerNameMatchActivity : Activity
    {
        public bool Condition { get; set; } = default!;
        public IActivity? Then { get; set; }
        public IActivity? Else { get; set; }
        protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
        {
            var result = Condition;

            var nextActivity = result ? Then : Else;

            await context.ScheduleActivityAsync(nextActivity, OnChildCompleted);
        }

        private async ValueTask OnChildCompleted(ActivityCompletedContext context)
        {
            await context.CompleteActivityAsync();
        }
    }

    public class CreateNewEnquiryActivity : CodeActivity
    {
        protected override async void Execute(ActivityExecutionContext context)
        {
            Console.WriteLine("New Enquiry is Created");

            await context.CompleteActivityAsync();
        }
    }

    public class CreateNewCustomerAndContractActivity : CodeActivity
    {
        protected override async void Execute(ActivityExecutionContext context)
        {
            Console.WriteLine("New Customer and Contract is Created");

            await context.CompleteActivityAsync();
        }
    }

    public class AddNewContractActivity : CodeActivity
    {
        protected override async void Execute(ActivityExecutionContext context)
        {
            Console.WriteLine("New Contract Added!");

            await context.CompleteActivityAsync();
        }
    }
}
