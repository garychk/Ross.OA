using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ross.OA.Web.AutoMapper
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.CategoryProfile>();
                cfg.AddProfile<Profiles.ShipProfile>();
                cfg.AddProfile<Profiles.EntityProfile>();
            });
        }
    }
}