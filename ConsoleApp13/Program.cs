// See https://aka.ms/new-console-template for more information
using ConsoleApp13;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddElsa(
    el => el.UseWorkflowManagement());

var serviceProvider =  services.BuildServiceProvider();

var workflowRunner = serviceProvider.GetRequiredService<IWorkflowRunner>();

var workFlow = new Workflow
{
    Root = new SignUpActivity
    {
        Condition = true, // start the flow

        Then = new SignUpActivity
        {
            Condition = true, // Check Bank Account is Valid           

            Then = new AddressVerifyActivity
            {
                Condition = false, // Check Address is Valid

                Then = new CustomerNameMatchActivity
                {
                    Condition = true, // Check Names

                    Then = new WriteLine("TBC Activity!!"),

                    Else = new CreateNewCustomerAndContractActivity()
                },

                Else = new CreateNewEnquiryActivity()
            },

            Else = new CreateNewEnquiryActivity()

        },
        Else = new CreateNewEnquiryActivity()
    }
};

await workflowRunner.RunAsync(workFlow);

Console.WriteLine("Hello, World!");


