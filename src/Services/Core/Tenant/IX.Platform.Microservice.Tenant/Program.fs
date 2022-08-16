namespace IX.Platform.Microservice.Tenant

open System.Text.Json
open IX.Platform.Core.Tenant.Infrastucture.AppContext
open Microsoft.EntityFrameworkCore
open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Core.Tenant.Infrastucture.Repositories
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts.Models
open IX.Platform.Core.Tenant.Application.Queries
open System.Text.Json.Serialization
open IX.Platform.Core.Tenant.Contracts.Commands
open IX.Platform.Core.Tenant.Application.CommandHandlers
open IX.Platform.Core.Tenant.Contracts

#nowarn "20"
open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open MediatR

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        let jsonOpt = new JsonSerializerOptions()

        jsonOpt.PropertyNamingPolicy <- JsonNamingPolicy.CamelCase
        jsonOpt.PropertyNameCaseInsensitive <- true
        jsonOpt.WriteIndented <- true
        jsonOpt.NumberHandling <- JsonNumberHandling.AllowReadingFromString

        builder.Services
               .AddControllers()
               .AddDapr(fun opt -> opt.UseJsonSerializationOptions(jsonOpt) |> ignore)

        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        let assemblies = AppDomain.CurrentDomain.GetAssemblies()

        builder.Services.AddAutoMapper(assemblies)
        builder.Services.AddMediatR(assemblies)

        let defaultMsSqlConnection = "Data Source=localhost,1439;Initial Catalog=ixp-dev-db;User Id=sa;Password=mssql-password123;"

        builder.Services.AddDbContext<TenantDbContext>
                 (fun (options : DbContextOptionsBuilder) -> 
                   options.UseSqlServer
                   //(defaultMsSqlConnection, ServiceLifetime.Scoped) 
                   (defaultMsSqlConnection) 
                   |> ignore) |> ignore


        builder.Services.AddTransient<ITenantRepository, TenantRepository>()

        builder.Services.AddScoped<IRequestHandler<GetTenantQuery, TenantEntity>, GetTenantQueryHandler>()
        builder.Services.AddScoped<IRequestHandler<GetTenantsQuery, seq<TenantEntity>>, GetTenantsQueryHandler>()

        builder.Services.AddScoped<IRequestHandler<CreateTenantCommand, TenantEntity>, CreateTenantCommandHandler>()
        builder.Services.AddScoped<IRequestHandler<UpdateTenantCommand, TenantEntity>, UpdateTenantCommandHandler>()
        builder.Services.AddScoped<IRequestHandler<DeleteTenantCommand, Guid>, DeleteTenantCommandHandler>()

        let app = builder.Build()

        //app.UseHttpsRedirection()

        // Configure the HTTP request pipeline.
        if app.Environment.IsDevelopment() then
           app.UseSwagger()
           app.UseSwaggerUI() |> ignore


        app.UseCloudEvents()
        app.UseAuthorization()
        app.MapControllers()
        app.MapSubscribeHandler()

        app.Run()

        exitCode
