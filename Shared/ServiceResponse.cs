using Newtonsoft.Json;

namespace TaskAPI.Shared;

public class ServiceResponse
{
    [JsonProperty("succeeded")]
    public bool Succeeded { get; set; }
    [JsonProperty("error")]
    public string Error { get; set; }
    [JsonProperty("data")]
    public object Data { get; set; }

    public static ServiceResponse SucceededInstance()
    {
        return new ServiceResponse() {Succeeded = true};
    }

    public static ServiceResponse SucceededInstance(object data)
    {
        return new ServiceResponse() {Data = data, Succeeded = true};
    }

    public static ServiceResponse FailedInstance(string error)
    {
        return new ServiceResponse() {Error = error};
    }
    public static ServiceResponse FailedInstance()
    {
        return new ServiceResponse();
    }
}