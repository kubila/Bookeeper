using AutoMapper;
using Booky.Models;
using Booky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Mappings
{
    public class MapsThings : Profile
    {
        public MapsThings()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
