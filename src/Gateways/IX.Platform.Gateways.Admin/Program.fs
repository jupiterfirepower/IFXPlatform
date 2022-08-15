namespace IX.Platform.Gateways.Admin

open System.Text.Json.Serialization
open IX.Platform.Shared.Core.Converters

#nowarn "20"
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

open System.Text.Json

#nowarn "20"
open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

//open Newtonsoft.Json.FSharp

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
