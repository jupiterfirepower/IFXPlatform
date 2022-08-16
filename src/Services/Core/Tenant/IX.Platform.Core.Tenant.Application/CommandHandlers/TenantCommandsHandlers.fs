namespace IX.Platform.Core.Tenant.Application

open MediatR
open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Core.Tenant.Contracts.Queries
open IX.Platform.Core.Tenant.Contracts.Models
open System
open IX.Platform.Core.Tenant.Contracts.Commands

module CommandHandlers = 

       type CreateTenantCommandHandler(repository : ITenantRepository) =        
          interface IRequestHandler<CreateTenantCommand, TenantEntity> with

              member this.Handle(request, cancellationToken) =

                   let result = { Id = Guid.NewGuid(); CompanyName = request.CompanyName }

                   task { return result }

       type UpdateTenantCommandHandler(repository : ITenantRepository) =        
          interface IRequestHandler<UpdateTenantCommand, TenantEntity> with

              member this.Handle(request, cancellationToken) =

                   let data = repository.GetAllAsync()

                   let result = { Id = request.Id; CompanyName = request.CompanyName }

                   let listResult = seq { result }

                   task { return result }


       type DeleteTenantCommandHandler(repository : ITenantRepository) =        
          interface IRequestHandler<DeleteTenantCommand, Guid> with

              member this.Handle(request, cancellationToken) =

                    task { return request.Id }