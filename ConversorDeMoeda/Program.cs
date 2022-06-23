using ConversorDeMoeda;
using Refit;

class MainClass
{
    static async Task Main(string[] args)
    {
        var validaMoeda = new ValidacaoDeMoedas();
        var validaValor = new ValidacaoDeValor();

        try
        {
            while (true)
            {
                var exchangerate = RestService.For<IExchangeApiService>("https://api.exchangerate.host");

                Console.Write("Moeda Origem: ");
                string moedaOrigem = Console.ReadLine();

                // Se o valor informado for nulo ou vazio, o programa é encerrado
                if (String.IsNullOrEmpty(moedaOrigem)) return;

                Console.Write("Moeda Destino: ");
                string moedaDestino = Console.ReadLine();

                Console.Write("Valor: ");
                string valor = Console.ReadLine();

                // Inicia métodos para validação de moedas e do valor a ser convertido.
                var moedaValidada = validaMoeda.ValidaMoeda(moedaOrigem, moedaDestino);
                double valorValidado = validaValor.ValidaValor(valor);
                var valorFalso = 0;

                // A conversão só começa se a moeda e o valor forem válidos.
                if (moedaValidada && valorValidado != valorFalso)
                {
                    var converteMoedas = await exchangerate.GetConversaoMoedaAsync(moedaOrigem, moedaDestino, valorValidado);

                    // Recebe o valor da taxa e retorna a taxa com 6 casas decimais.
                    var taxaComCasasDecimais = Math.Round(converteMoedas.Info.Taxa, 6);
                    var varlorComCasasDecimais = Math.Round(converteMoedas.Resultado, 2);

                    Console.WriteLine();
                    Console.WriteLine($"" +
                        $"{moedaOrigem} {valorValidado} => {moedaDestino} {varlorComCasasDecimais}\n" +
                        $"Taxa: {taxaComCasasDecimais}\n");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
        }
    }
}
