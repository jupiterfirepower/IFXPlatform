namespace IX.Platform.Microservice.Tenant.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open IX.Platform.Shared.Core.Controllers
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts.Commands
open Dapr.Client
open IX.Platform.Core.Tenant.Contracts

type TenantController (logger : ILogger<TenantController>, provider : IServiceProvider) =
    inherit ApiController(provider)

    [<HttpGet("GetById")>]
    member _.GetByIdAsync([<FromQuery>] query: GetTenantQuery, [<FromServices>] daprClient : DaprClient) = base.HandleAsync(query)

    [<HttpGet("GetAll")>]
    member _.GetAllAsync([<FromQuery>] query: GetTenantsQuery, [<FromServices>] daprClient : DaprClient) = base.HandleAsync(query)

    [<HttpPost>]
    member _.CreateAsync([<FromQuery>] command: CreateTenantCommand, [<FromServices>] daprClient : DaprClient) = base.HandleAsync(command)

    [<HttpPut>]
    member _.UpdateAsync([<FromQuery>] command: UpdateTenantCommand, [<FromServices>] daprClient : DaprClient) = base.HandleAsync(command)

    [<HttpDelete>]
    member _.DeleteAsync([<FromQuery>] command: DeleteTenantCommand, [<FromServices>] daprClient : DaprClient) = base.HandleAsync(command)
        
