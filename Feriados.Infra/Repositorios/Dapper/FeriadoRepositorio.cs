using System.Collections.Generic;
using System.Threading.Tasks;
using Feriados.Dominio.Entidades;
using Feriados.Dominio.Interfaces.Repositorios;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Feriados.Infra.Repositorios.Dapper
{
    public class FeriadoRepositorio : IFeriadoRepositorio
    {
        private readonly string _connectionString;

        public FeriadoRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AdicionarDatas(VariableDates datas)
        {
            var sql = @"INSERT INTO [FeriadosDb].[dbo].[VariableDates]
                            ([Ano2015]
                            ,[Ano2016]
                            ,[Ano2017]
                            ,[Ano2018]
                            ,[Ano2019]
                            ,[Ano2020])
                        VALUES
                            (
                             @Ano2015
                            ,@Ano2016
                            ,@Ano2017
                            ,@Ano2018
                            ,@Ano2019
                            ,@Ano2020)
                     SELECT CAST(SCOPE_IDENTITY() as int)";

            using var conexao = new SqlConnection(_connectionString);

            var resultado = await conexao.QuerySingleAsync<int>(sql,
                new
                {
                    datas.Ano2015,
                    datas.Ano2016,
                    datas.Ano2017,
                    datas.Ano2018,
                    datas.Ano2019,
                    datas.Ano2020
                }, commandType: System.Data.CommandType.Text);

            return resultado;
        }

        public async Task<int> AdicionarFeriado(Feriado feriado)
        {
            var sql = @"INSERT INTO [FeriadosDb].[dbo].[Feriados]
                            ([Date]
                            ,[Title]
                            ,[Description]
                            ,[Legislation]
                            ,[Type]
                            ,[StartTime]
                            ,[EndTime]
                            ,[VariableId])
                        VALUES
                            (
                             @Date
                            ,@Title
                            ,@Description
                            ,@Legislation
                            ,@Type
                            ,@StartTime
                            ,@EndTime
                            ,@VariableId)
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            using var conexao = new SqlConnection(_connectionString);

            var resultado = await conexao.QuerySingleAsync<int>(sql,
                new
                {
                    feriado.Date,
                    feriado.Title,
                    feriado.Description,
                    feriado.Legislation,
                    feriado.Type,
                    feriado.StartTime,
                    feriado.EndTime,
                    feriado.VariableId
                }, commandType: System.Data.CommandType.Text);

            return resultado;
        }

        public async Task<bool> EditarFeriado(Feriado feriado)
        {
            var sql = @"UPDATE [FeriadosDb].[dbo].[Feriados]
                            SET [Title] = @Title
                            ,[Description] = @Description
                            ,[Legislation] = @Legislation
                            ,[Type] = @Type
                            ,[StartTime] = @StartTime
                            ,[EndTime] = @EndTime
                            ,[Date] = @Date
                        WHERE Id = @Id";

            using var conexao = new SqlConnection(_connectionString);

            var resultado = await conexao.ExecuteAsync(sql,
                new
                {
                    feriado.Title,
                    feriado.Description,
                    feriado.Legislation,
                    feriado.Type,
                    feriado.StartTime,
                    feriado.EndTime,
                    feriado.Date,
                    feriado.Id
                },
                commandType: System.Data.CommandType.Text);

            if (resultado <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ExcluirFeriado(int id)
        {
            var sql = @"DELETE FROM [FeriadosDb].[dbo].[Feriados] WHERE Id = @Id";

            using var conexao = new SqlConnection(_connectionString);

            var resultado = await conexao.ExecuteAsync(sql,
                new
                {
                    id
                },
                commandType: System.Data.CommandType.Text);

            if (resultado <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<IEnumerable<Feriado>> ObtemFeriados()
        {
            string sql = @"SELECT [Date]
                            ,[Title]
                            ,[Description]
                            ,[Legislation]
                            ,[Type]
                            ,[StartTime]
                            ,[EndTime]
                            ,[Id]
                            ,[VariableId]
                        FROM [FeriadosDb].[dbo].[Feriados] ";

            using var conexao = new SqlConnection(_connectionString);

            var resultado = await conexao.QueryAsync<Feriado, VariableDates, Feriado>(
                sql,
                map: (feriado, datas) =>
                {
                    feriado.VariableDates = datas;
                    return feriado;
                }, splitOn: "VariableId");

            return resultado;
        }
    }
}
