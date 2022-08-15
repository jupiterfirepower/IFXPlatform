namespace IX.Platform.Gateways.Admin.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Dapr.Client
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts
open IX.Platform.Gateways.Admin.Models
open System.Net.Http.Json

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

        let client = DaprClient.CreateInvokeHttpClient("tenant-microservice")
        let response =  client.GetFromJsonAsync<RootResponse>("/api/Tenant/GetById?Gid=" + Id.ToString("D"))

        let data = daprClient.InvokeMethodAsync<GetTenantQuery, RootResponse>(Net.Http.HttpMethod.Get, "tenant-microservice", "/api/Tenant/GetById?Gid=" + Id.ToString("N"), { Gid = Id })
        data.Result.result
