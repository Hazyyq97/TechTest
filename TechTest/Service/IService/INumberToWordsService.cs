namespace TechnicalTest.Service.IService
{
    public interface INumberToWordsService 
    {
        Task<string> ConvertNumberToWordsAsync(double number);

    }
}
