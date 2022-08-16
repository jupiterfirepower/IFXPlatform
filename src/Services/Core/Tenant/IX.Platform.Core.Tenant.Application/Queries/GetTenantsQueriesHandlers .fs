namespace IX.Platform.Core.Tenant.Application

open MediatR
open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts.Models
open System
open IX.Platform.Core.Tenant.Contracts
open AutoMapper
open Microsoft.Extensions.Logging

module Queries = 

    type GetTenantQueryHandler(repository : ITenantRepository, logger : ILogger<GetTenantQueryHandler>, mapper : IMapper) =        
         interface IRequestHandler<GetTenantQuery, TenantEntity> with

            member _.Handle(request, cancellationToken) =

                   logger.LogInformation($"GetTenantQueryHandler request.Gid - {request.Gid}")

                   let data = repository.GetByIdAsync(request.Gid) |> Async.RunSynchronously

                   let resultData = mapper.Map<TenantEntity>(data.Result)

                   task { return resultData }

    type GetTenantsQueryHandler(repository : ITenantRepository, logger : ILogger<GetTenantsQueryHandler>, mapper : IMapper) =        
         interface IRequestHandler<GetTenantsQuery, seq<TenantEntity>> with

            member _.Handle(request, cancellationToken) =

                   logger.LogInformation("GetTenantsQueryHandler called.")

                   let data = repository.GetAllAsync()
                   let resultData = mapper.Map<seq<TenantEntity>>(data)

                   task { return resultData }
                   
                   
