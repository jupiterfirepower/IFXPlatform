namespace IX.Platform.Gateways.Admin.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Dapr.Client
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts
open IX.Platform.Gateways.Admin.Models
open System.Net.Http.Json
open IX.Platform.Core.Tenant.Contracts.Commands

[<ApiController>]
[<Route("[controller]")>]
type TenantController (logger : ILogger<TenantController>) =
    inherit ControllerBase()

    [<Literal>]
    let tenantMicroserviceName = "tenant-microservice"

    [<Literal>]
    let tenantBaseApiUri = "/api/Tenant/"

    [<HttpGet>]
    member _.Get([<FromServices>] daprClient : DaprClient) =
        let data = daprClient.InvokeMethodAsync<GetTenantsQuery, RootResponseGetTenants>(Net.Http.HttpMethod.Get, tenantMicroserviceName, tenantBaseApiUri + "GetAll", new GetTenantsQuery())
        data.Result.result

    [<HttpGet("GetById")>]
    member _.GetById([<FromQuery>] Id: Guid, [<FromServices>] daprClient : DaprClient) =
        let client = DaprClient.CreateInvokeHttpClient(tenantMicroserviceName)
        let response =  client.GetFromJsonAsync<RootResponse>(tenantBaseApiUri + "GetById?Gid=" + Id.ToString("D"))

        let data = daprClient.InvokeMethodAsync<GetTenantQuery, RootResponse>(Net.Http.HttpMethod.Get, tenantMicroserviceName, tenantBaseApiUri + "GetById?Gid=" + Id.ToString("N"), { Gid = Id })
        data.Result.result

    [<HttpPost>]
    member _.CreateAsync([<FromQuery>] command: CreateTenantCommand, [<FromServices>] daprClient : DaprClient) =
           let data = daprClient.InvokeMethodAsync<CreateTenantCommand, RootResponse>(Net.Http.HttpMethod.Post, tenantMicroserviceName, tenantBaseApiUri + "Create", command)
           data.Result.result

    [<HttpPut>]
    member _.UpdateAsync([<FromQuery>] command: UpdateTenantCommand, [<FromServices>] daprClient : DaprClient) =
           let data = daprClient.InvokeMethodAsync<UpdateTenantCommand, RootResponse>(Net.Http.HttpMethod.Post, tenantMicroserviceName, tenantBaseApiUri + "Update", command)
           data.Result.result

    [<HttpDelete>]
    member _.DeleteAsync([<FromQuery>] command: DeleteTenantCommand, [<FromServices>] daprClient : DaprClient) =
           let data = daprClient.InvokeMethodAsync<DeleteTenantCommand, RootResponse>(Net.Http.HttpMethod.Post, tenantMicroserviceName, tenantBaseApiUri + "Update", command)
           data.Result.result