using System.Text.RegularExpressions;

namespace ConversorDeMoeda
{
    internal class ValidacaoDeMoedas
    {
        public ValidacaoDeMoedas()
        {
        }

        // A moeda só é considerada válida se a moedaOrigem for diferente da moedaDestino
        // e se ela possui exatamente 3 caracteres alfabéticos.
        public bool ValidaMoeda(string moedaOrigem, string moedaDestino)
        {
            var moedaVerificadaSeIgual = VerificaMoedaIgual(moedaOrigem, moedaDestino);
            var moedaVerificadaSeCaractere = ValidaCaractereDaMoeda(moedaOrigem, moedaDestino);

            if (moedaVerificadaSeIgual && moedaVerificadaSeCaractere)
            {
                return true;
            }
            return false;
        }

        private bool VerificaMoedaIgual(string moedaOrigem, string moedaDestino)
        {
            if (moedaOrigem != moedaDestino) return true;

            else
            {
                Console.WriteLine($"A moeda {moedaOrigem}, que deseja converter deve ser diferente!");
                Console.WriteLine();
                return false;
            }
        }

        private bool ValidaCaractereDaMoeda(string moedaOrigem, string moedaDestino)
        {
            // Expressão regular regex, que verifica se a string tem os caracteres de 'a - z' ou 'A - Z'
            // e se tem 3 caracteres.
            string regexVerifica = "^[a-z|A-Z]{3}$";
            var regexOrigemVerificado = Regex.IsMatch(moedaOrigem, regexVerifica);
            var regexDestinoVerificado = Regex.IsMatch(moedaDestino, regexVerifica);

            if (regexOrigemVerificado && regexDestinoVerificado) return true;

            else
            {
                Console.WriteLine($"As moedas: '{moedaOrigem}' e '{moedaDestino}' devem ter exatamente 3 caracteres de 'a - z' ou 'A - Z'");
                Console.WriteLine();
                return false;
            }
        }
    }
}
