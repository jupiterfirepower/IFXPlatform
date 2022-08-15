namespace IX.Platform.Gateways.Admin.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Dapr.Client
open IX.Platform.Core.Tenant.Contracts.Models
open IX.Platform.Core.Tenant.Contracts.Queries
open System.Threading.Tasks
open System.Text.Json
open System.Net.Http
open System.Net.Http.Json
open IX.Platform.Core.Tenant.Contracts

[<CLIMutable>]
type RootResponse = 
    { 
       result : TenantEntity
    }

[<CLIMutable>]
type RootResponseGetTenants = 
    { 
       result : seq<TenantEntity>
    }

[<ApiController>]
[<Route("[controller]")>]
type TenantController (logger : ILogger<TenantController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get([<FromServices>] daprClient : DaprClient) =
        let data = daprClient.InvokeMethodAsync<GetTenantsQuery, RootResponseGetTenants>(Net.Http.HttpMethod.Get, "tenant-microservice", "/api/Tenant/GetAll", new GetTenantsQuery())
        data.Result.result

    [<HttpGet("GetById")>]
    member _.GetById([<FromQuery>] Id: Guid, [<FromServices>] daprClient : DaprClient) =
        //let query = new GetTenantQuery()
        //query.Gid <- Id
        let data = daprClient.InvokeMethodAsync<GetTenantQuery, RootResponse>(Net.Http.HttpMethod.Get, "tenant-microservice", "/api/Tenant/GetById", { Gid = Id })
        data.Result.result
