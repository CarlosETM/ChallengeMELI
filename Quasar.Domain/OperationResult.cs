using Quasar.Domain.Aggregation;
using System;
using System.Threading.Tasks;

public class OperationResult<T>
{
    private readonly ILogService _logService;

    public OperationResult()
    {
        this.Error_Message = string.Empty;
        this.Data = Activator.CreateInstance<T>();
    }

    public OperationResult(ILogService logService)
    {
        _logService = logService;
        this.Error_Message = string.Empty;
        this.Data = Activator.CreateInstance<T>();
    }

    public T Data { get; set; }

    public bool Success { get; set; }

    public string Error_Message { get; set; }

    public int Error_Code { get; set; }

    public async Task<OperationResult<T>> AsyncRun(Func<Task<T>> func)
    {
        try
        {
            Data = await func.Invoke();
            Success = true;
        }
        catch (Exception e)
        {
            Success = false;
            Error_Message = e.Message;
          //  Error_Code = e.Code; // 20
                                 //_logService.WriteException(e.ToString());
        }
       
        return this;
    }
}


