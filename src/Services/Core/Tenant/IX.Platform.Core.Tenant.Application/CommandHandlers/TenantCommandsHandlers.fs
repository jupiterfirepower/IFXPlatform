namespace IX.Platform.Core.Tenant.Application

open MediatR
open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Core.Tenant.Contracts.Models
open System
open IX.Platform.Core.Tenant.Contracts.Commands

module CommandHandlers = 

       type CreateTenantCommandHandler(repository : ITenantRepository) =        
          interface IRequestHandler<CreateTenantCommand, TenantEntity> with

              member this.Handle(request, cancellationToken) = repository.AddAsync({ Id = Guid.NewGuid(); CompanyName = request.CompanyName })

       type UpdateTenantCommandHandler(repository : ITenantRepository) =       
          interface IRequestHandler<UpdateTenantCommand, TenantEntity> with

              member this.Handle(request, cancellationToken) = repository.UpdateAsync({ Id = request.Id; CompanyName = request.CompanyName })

       type DeleteTenantCommandHandler(repository : ITenantRepository) =        
          interface IRequestHandler<DeleteTenantCommand, Guid> with

              member this.Handle(request, cancellationToken) = repository.DeleteAsync(request.Id)