namespace IX.Platform.Microservice.Tenant

open Microsoft.EntityFrameworkCore.Design
open Microsoft.Extensions.DependencyInjection

module DesignTimeServices = 

  open EntityFrameworkCore.FSharp

  type DesignTimeServices() =
        interface IDesignTimeServices with 
            member __.ConfigureDesignTimeServices(serviceCollection: IServiceCollection) = 
                let fSharpServices= EFCoreFSharpServices() :> IDesignTimeServices
                fSharpServices.ConfigureDesignTimeServices serviceCollection
                ()