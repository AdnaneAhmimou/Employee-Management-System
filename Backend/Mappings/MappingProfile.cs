using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}