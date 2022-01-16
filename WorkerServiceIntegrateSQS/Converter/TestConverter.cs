using WorkerService.Domain.Class;
using WorkerService.Domain.Service;

namespace WorkerService.Service;

public class TestConverter
{
    private readonly IAWSSQSService _AWSSQSService;  
  
    public TestConverter(IAWSSQSService AWSSQSService)  
    {  
        _AWSSQSService = AWSSQSService;  
    }
    
    public async Task<bool> PostMessageAsync(User user)  
    {  
        var result = await _AWSSQSService.PostMessageAsync(user);
        return result;
    }
    
    public async Task<List<AllMessage>> GetAllMessagesAsync()  
    {  
        var result = await _AWSSQSService.GetAllMessagesAsync();
        return result;
    }
    
    public async Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage)  
    {  
        var result = await _AWSSQSService.DeleteMessageAsync(deleteMessage);  
        return result;  
    }
    
}