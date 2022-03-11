using Newtonsoft.Json;

namespace Feriados.Dominio.Respostas
{
    public class FeriadoResposta
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("legislation")]
        public string Legislation { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("variableDates")]
        public VariableDatesResposta VariableDates { get; set; }
    }

    public class VariableDatesResposta
    {
        [JsonProperty("2015")]
        public string Ano2015 { get; set; }

        [JsonProperty("2016")]
        public string Ano2016 { get; set; }

        [JsonProperty("2017")]
        public string Ano2017 { get; set; }

        [JsonProperty("2018")]
        public string Ano2018 { get; set; }

        [JsonProperty("2019")]
        public string Ano2019 { get; set; }

        [JsonProperty("2020")]
        public string Ano2020 { get; set; }
    }
}
