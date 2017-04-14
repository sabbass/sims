using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace ResultInformation.Models
{
    public class ModelHelper<T, P>
    {

          static  ModelHelper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<T, P>();
                cfg.CreateMap< P,T>();
                //cfg.CreateMap<Bar, BarDto>();
            });
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, P>());
        }

        public P Map(T p)
        {
            return Mapper.Map<T, P>(p);
        }
        public T Reverse(P p)
        {
            return Mapper.Map<P, T>(p);
        }

        public void Copy(DAL.Person p, PersonModel patch)
        {
            Mapper.Map(p, patch);
        }
    }
}