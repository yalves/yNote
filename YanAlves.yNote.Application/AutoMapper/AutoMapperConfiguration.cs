using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanAlves.yNote.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
