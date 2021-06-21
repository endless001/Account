using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.Grpc;
using Account.API.Models;
using AutoMapper;

namespace Account.API.Infrastructure.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountEntity, AccountRequest>();
        }
    }
}
