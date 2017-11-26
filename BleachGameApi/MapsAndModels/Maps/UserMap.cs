using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CoreRepo.Database.Tables.Account;
using MapsAndModels.ViewModels;

namespace MapsAndModels.Maps
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<User, CharacterModel>();
        }
    }
}
