﻿using AutoMapper;
using SoftFX_Task.Chart_Files;
using SoftFX_Task.EntityFramework.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFX_Task.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ICollection<Quote>, Bars>()
                .ForMember(x => x.DateTime, c => c.MapFrom(v => v.Select(b => b.DateTime).ToList()))
                .ForMember(x => x.Close, c => c.MapFrom(v => v.Select(b => b.Close).ToList()))
                .ForMember(x => x.Open, c => c.MapFrom(v => v.Select(b => b.Open).ToList()))
                .ForMember(x => x.High, c => c.MapFrom(v => v.Select(b => b.High).ToList()))
                .ForMember(x => x.Low, c => c.MapFrom(v => v.Select(b => b.Low).ToList()))
                .ForMember(x => x.Volume, c => c.MapFrom(v => v.Select(b => b.Volume).ToList()));
            CreateMap<Symbol, SymbolSearchResponse>()
                .ForMember(x => x.Symbol, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.SymbolFullName, c => c.MapFrom(v => v.Name + ":" + v.Name))
                .ForMember(x => x.Ticker, c => c.MapFrom(v => v.Name))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<Symbol, SymbolInfo>()
                .ForMember(x => x.Name, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.Ticker, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.Exchange, c => c.MapFrom(v => v.Name))
                .ForMember(x => x.ListedExchange, c => c.MapFrom(v => v.Name));
        }
    }
}