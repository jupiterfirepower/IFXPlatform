namespace IX.Platform.Core.Tenant.Contracts

open System
open MediatR
open System.ComponentModel.DataAnnotations
open IX.Platform.Core.Tenant.Contracts.Models

module Commands =

      type CreateTenantCommand() = 
           interface IRequest<TenantEntity>

           [<Required>]
           [<MaxLength(250)>]
           member val CompanyName = String.Empty with get, set

      type UpdateTenantCommand() = 
           interface IRequest<TenantEntity>

           [<Required>]
           member val Id = Guid.Empty with get, set

           [<Required>]
           [<MaxLength(250)>]
           member val CompanyName = String.Empty with get, set

      type DeleteTenantCommand() = 
           interface IRequest<Guid>

           [<Required>]
           member val Id = Guid.Empty with get, set