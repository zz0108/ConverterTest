using WorkerService.Domain.Class;

namespace WorkerService.Domain.Service;

public interface IAWSSQSService
{
    Task<bool> PostMessageAsync(User user);  
    Task<List<AllMessage>> GetAllMessagesAsync();  
    Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage);  
}