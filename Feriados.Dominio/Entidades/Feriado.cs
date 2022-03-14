using System.Collections.Generic;
using Feriados.Dominio.Respostas;
using Newtonsoft.Json;

namespace Feriados.Dominio.Entidades
{
    public class Feriado
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Legislation { get; set; }

        public string Type { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        [JsonIgnore]
        public VariableDates VariableDates { get; set; }
        public int VariableId { get; set; }

        public static explicit operator Feriado(FeriadoResposta feriado)
        {
            return new Feriado
            {
                Date = feriado.Date,
                Description = feriado.Description,
                EndTime = feriado.EndTime == string.Empty? "23:59" : feriado.EndTime,
                Legislation = feriado.Legislation,
                StartTime = feriado.StartTime == string.Empty? "00:00" : feriado.StartTime,
                Title = feriado.Title,
                Type = feriado.Type
            };
        }
    }

    public class VariableDates
    {
        public int Id { get; set; }

        public string Ano2015 { get; set; }

        public string Ano2016 { get; set; }

        public string Ano2017 { get; set; }

        public string Ano2018 { get; set; }

        public string Ano2019 { get; set; }

        public string Ano2020 { get; set; }

        public ICollection<Feriado> Feriados { get; set; }

        public static explicit operator VariableDates(VariableDatesResposta datas)
        {
            return new VariableDates
            {
                Ano2015 = datas.Ano2015,
                Ano2016 = datas.Ano2016,
                Ano2017 = datas.Ano2017,
                Ano2018 = datas.Ano2018,
                Ano2019 = datas.Ano2019,
                Ano2020 = datas.Ano2020
            };
        }
    }
}
