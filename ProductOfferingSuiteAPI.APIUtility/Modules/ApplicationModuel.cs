using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
//using DesignComplexityAPI.Domain.Global;
//using DesignComplexityAPI.Persistence.Configuration;
//using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.Extensions.Configuration;
using DesignComplexityAPI.Services.OfferSheet;
using ProductOfferingSuiteAPI.Persistence.OfferSheet;
using ProductOfferingSuiteAPI.Services.Login;
//using ProductOfferingSuiteAPI.Services.ItemDetails;
using ProductOfferingSuiteAPI.Persistence.Configuration;
//using ProductOfferingSuiteAPI.Persistence.ItemDetails;
using ProductOfferingSuiteAPI.Persistence.LoginDetails;



namespace ProductOfferingSuiteAPI.APIUtility.Modules
{
    public class ApplicationModuel : Module
    {
        public static IConfiguration _configuration;
        public ApplicationModuel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new SqlConnectionProvider(_configuration.GetConnectionString("SqlConnection"))).As<ISqlConnectionProvider>().SingleInstance();

            //builder.RegisterType<ShapeRepository>().As<IShapeRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<ShapeService>().As<IShapeService>().InstancePerLifetimeScope();
            builder.RegisterType<LoginRepository>().As<ILoginRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerLifetimeScope();
            //builder.RegisterType<ArticleTypeRepository>().As<IArticleTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<ArticleTypeService>().As<IArticleTypeService>().InstancePerLifetimeScope();
            //builder.RegisterType<MetalTypeRepository>().As<IMetalTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<MetalTypeService>().As<IMetalTypeService>().InstancePerLifetimeScope();
            //builder.RegisterType<SettingTypeRepository>().As<ISettingTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<SettingTypeService>().As<ISettingTypeService>().InstancePerLifetimeScope();
            //builder.RegisterType<DesignRepository>().As<IDesignRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<DesignService>().As<IDesignService>().InstancePerLifetimeScope();
            //builder.RegisterType<JewelryItemRepository>().As<IJewelryItemRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<JewelryItemService>().As<IJewelryItemService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}
