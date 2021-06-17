using Newtonsoft.Json;

namespace CotacaoDolarHG
{
    public class Market
    {
        //PARA DESSERIALIZAR UM JSON, DEVEMOS RESPEITAR OS NÍVEIS
        public Market()
        {
            this.Currency = new Currency();
        }

        [JsonProperty(PropertyName = "currencies")]
        public Currency Currency { get; set; }
    }
}
