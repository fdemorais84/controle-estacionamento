using AutoMapper;
using ControleEstacionamento.Application.ViewModels;
using ControleEstacionamento.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstacionamento.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ParametroViewModel, Parametro>()
                .ForMember(x => x.ValorPrimeiraHora, opt => opt.MapFrom(x => x.ValorPrimeiraHora))
                .ForMember(x => x.ValorHoraAdicional, opt => opt.MapFrom(x => x.ValorHoraAdicional))
                .ForMember(x => x.DataInicio, opt => opt.MapFrom(x => Convert.ToDateTime(x.DataInicio)))
                .ForMember(x => x.DataFim, opt => opt.MapFrom(x => Convert.ToDateTime(x.DataFim)))
                .ForMember(x => x.Ativo, opt => opt.MapFrom(x => true));

            CreateMap<TicketEntradaViewModel, Ticket>()
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.Placa))                
                .ForMember(x => x.Entrada, opt => opt.MapFrom(x => DateTime.Now))                
                .ForMember(x => x.Ativo, opt => opt.MapFrom(x => true));

            CreateMap<ParametroGratuidadeViewModel, ParametroGratuidade>()
                .ForMember(x => x.DiaSemana, opt => opt.MapFrom(x => x.DiaSemana))
                .ForMember(x => x.Inicio, opt => opt.MapFrom(x => Convert.ToDateTime(x.Inicio)))
                .ForMember(x => x.Encerramento, opt => opt.MapFrom(x => Convert.ToDateTime(x.Encerramento)));             
        }
    }
}
