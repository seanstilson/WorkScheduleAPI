using System;
using AutoMapper;
using Entities=WorkScheduleAPI.Entities;
using Models=WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Mappers
{
    public class WorkScheduleMapping : Profile
    {
        public WorkScheduleMapping()
        {
            CreateMap<Models.WorkScheduleItem, Entities.WorkScheduleItem>()
                .ForMember(dest => dest.WorkScheduleItemId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.DepartmentId, act => act.MapFrom(src => src.Department.Id))
                .ForMember(dest => dest.WorkSchduleItemFromTime, act => act.MapFrom(src => src.WorkSchduleItemFromTime))
                .ForMember(dest => dest.WorkScheduleItemToTime, act => act.MapFrom(src => src.WorkScheduleItemToTime))
                .ForMember(dest => dest.Color, act => act.MapFrom<CustomResolver, string>(src => src.Department.name));
        }

        public class CustomResolver : IMemberValueResolver<object, object, string, string>
        {
            public string Resolve(object source, object destination, string sourceMember, string destinationMember, ResolutionContext context)
            {
                var sched = source as Models.WorkScheduleItem;
                var dept = sched.Department.name;
                switch (dept)
                {
                    case "Design":
                        return "Green";
                    case "Production":
                        return "Blue";
                    case "Transportation":
                        return "Orange";
                    case "FinalReview":
                        return "Red";
                    default: return "Red";
                }
            }
        }
    }
}
