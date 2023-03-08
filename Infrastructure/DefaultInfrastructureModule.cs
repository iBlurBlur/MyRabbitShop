using Application.Common.Interfaces;
using Application.Features.Products;
using Module = Autofac.Module;
using System.Reflection;
using Autofac;
using System.Security.Claims;
using Infrastructure.HttpClient;
using Application.Commom.Interfaces;
using Application.Features.ProductCategories;

namespace Infrastructure;

public class DefaultInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
             .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
             .Where(t => t.Name.EndsWith("API"))
             .AsImplementedInterfaces()
             .InstancePerLifetimeScope();

        builder
            .RegisterType<ProductService>()
            .As<IProductService>()
            .InstancePerLifetimeScope();

        builder
            .RegisterType<ProductCategoryService>()
            .As<IProductCategoryService>()
            .InstancePerLifetimeScope();
    }
}
