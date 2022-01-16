using Newtonsoft.Json;
using WorkerService.Domain.Class;
using WorkerService.Domain.Service;
using WorkerService.Service;

namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IAWSSQSService _awssqsService;

    public Worker(ILogger<Worker> logger,
        IAWSSQSService awssqsService)
    {
        _logger = logger;
        _awssqsService = awssqsService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var _testConverter = new TestConverter(_awssqsService);
        int index = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            
            var user = new User
            {
                FirstName = $"{index}_Test",
                LastName = "Test",
                UserName = "Test0108",
                EmailId = "Test@gmail.com"
            };
            var post_res = await _testConverter.PostMessageAsync(user);
            if(!post_res)
                _logger.LogInformation("寫入失敗");
            var get_res = await _testConverter.GetAllMessagesAsync();
            if(!get_res.Any())
                _logger.LogInformation("讀取失敗");
        
            _logger.LogInformation($"{JsonConvert.SerializeObject(get_res)}");
            var deleteReq = new DeleteMessage
            {
                ReceiptHandle = get_res.FirstOrDefault().ReceiptHandle
            };
            var delete = await _testConverter.DeleteMessageAsync(deleteReq);
            if(!delete)
                _logger.LogInformation("刪除失敗");
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            index++;
            await Task.Delay(10000, stoppingToken);
        }
    }
}