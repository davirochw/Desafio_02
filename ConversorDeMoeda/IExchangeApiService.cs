using Refit;

namespace ConversorDeMoeda
{
    internal interface IExchangeApiService
    {
        [Get("/convert?from={moedaOrigem}&to={moedaDestino}&amount={valor}")]
        Task<ConversorResponse> GetConversaoMoedaAsync(string moedaOrigem, string moedaDestino, double valor);
    }
}
