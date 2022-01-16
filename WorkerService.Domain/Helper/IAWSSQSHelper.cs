using Amazon.SQS.Model;
using WorkerService.Domain.Class;

namespace WorkerService.Domain.Helper;

public interface IAWSSQSHelper
{
    Task<bool> SendMessageAsync(UserDetail userDetail);  
    Task<List<Message>> ReceiveMessageAsync();  
    Task<bool> DeleteMessageAsync(string messageReceiptHandle);  
}