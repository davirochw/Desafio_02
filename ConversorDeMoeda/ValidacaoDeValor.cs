namespace ConversorDeMoeda
{
    internal class ValidacaoDeValor
    {
        public ValidacaoDeValor()
        {
        }

        public double ValidaValor(string valor)
        {
            var retornoFalso = 0;

            try
            {
                var valorDecimal = Convert.ToDouble(valor);
                var valorVerificadoMaiorQueZero = VerificaValorMaiorQueZero(valorDecimal);

                // Se o valor for maior que 0, ele retornará o valor convertido.
                if (valorVerificadoMaiorQueZero) return valorDecimal;
                else return retornoFalso;
            }
            catch
            {
                Console.WriteLine($"O valor: '{valor}' que deseja converter deve ser um valor numérico!");
                Console.WriteLine();
                return retornoFalso;
            }
            return retornoFalso;
        }

        private bool VerificaValorMaiorQueZero(double valor)
        {
            if (valor > 0) return true;

            else
            {
                Console.WriteLine($"O valor: '{valor}' que deseja converter deve ser maior que 0");
                Console.WriteLine();
                return false;
            }

        }
    }
}
