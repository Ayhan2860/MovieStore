namespace MovieStoreUI.Common.Results
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}