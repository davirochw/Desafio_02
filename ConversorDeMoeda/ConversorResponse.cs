using System.Text.Json.Serialization;

namespace ConversorDeMoeda
{
    internal class ConversorResponse
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("result")]
        public double Resultado { get; set; }
    }

    internal class Info
    {
        [JsonPropertyName("rate")]
        public double Taxa { get; set; }
    }
}
