using Newtonsoft.Json;

namespace CotacaoDolarHG
{
    public class Currency
    {
        //PARA DESSERIALIZAR UM JSON, DEVEMOS RESPEITAR OS NÍVEIS 
        //MARCAÇÃO DE PROPRIEDADE DO JSON
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "buy")]
        public decimal Buy { get; set; }

        [JsonProperty(PropertyName = "sell")]
        public decimal Sell { get; set; }

        [JsonProperty(PropertyName = "variation")]
        public decimal Variation { get; set; }
    }
}
