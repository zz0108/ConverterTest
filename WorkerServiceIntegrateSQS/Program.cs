using Amazon.SQS;
using WorkerService;
using WorkerService.Business.Helper;
using WorkerService.Business.Service;
using WorkerService.Domain.Helper;
using WorkerService.Domain.Service;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddAWSService<IAmazonSQS>();
        services.AddTransient<IAWSSQSService,AWSSQSService>();
        services.AddTransient<IAWSSQSHelper, AWSSQSHelper>();
    })
    .Build();

await host.RunAsync();