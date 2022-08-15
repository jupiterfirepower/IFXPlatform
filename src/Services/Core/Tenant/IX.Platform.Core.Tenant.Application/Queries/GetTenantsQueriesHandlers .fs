namespace IX.Platform.Core.Tenant.Application

open MediatR
open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts.Models
open System
open IX.Platform.Core.Tenant.Contracts

//open IX.Platform.Core.Tenant.Contracts

module Queries = 

    type GetTenantQueryHandler(repository : ITenantRepository) =        
         interface IRequestHandler<GetTenantQuery, TenantEntity> with

            member this.Handle(request, cancellationToken) =

                   Console.WriteLine($"GetTenantQueryHandler request.Id - {request.Gid}")
                   let data = repository.GetByIdAsync(request.Gid) |> Async.RunSynchronously
                   

                   let result = { Gid = data.Result.Id; CompanyName = data.Result.CompanyName }

                   //let result = { Gid = Guid.NewGuid(); CompanyName = "test data 1" }

                   task { return result }

    type GetTenantsQueryHandler(repository : ITenantRepository) =        
         interface IRequestHandler<GetTenantsQuery, seq<TenantEntity>> with

            member this.Handle(request, cancellationToken) =

                   let data = repository.GetAllAsync()

                   let result = { Gid = Guid.NewGuid(); CompanyName = "test data 2" }

                   let listResult = seq { result }

                   task { return listResult }
                   
                   
