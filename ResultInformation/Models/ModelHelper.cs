using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace ResultInformation.Areas.Admin.Models
{
    public class ModelHelper<UiModel, DbModel>
    {

        static  ModelHelper()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<UiModel, DbModel>();
                cfg.CreateMap<DbModel,UiModel>();
                
            });
           
        }

        public DbModel ToDb(UiModel p)
        {
            return Mapper.Map<UiModel, DbModel>(p);
        }
        public UiModel ToUi(DbModel p)
        {
            return Mapper.Map<DbModel, UiModel>(p);
        }

        public DbModel Patch(UiModel t, DbModel p)// used for edit
        {
           return Mapper.Map< UiModel,DbModel>( t,p);
        }
    }
}