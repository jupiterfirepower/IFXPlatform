namespace IX.Platform.Core.Tenant.Contracts

open MediatR
open System
open IX.Platform.Core.Tenant.Contracts.Models

[<CLIMutable>]
type GetTenantQuery = 
   {
       Gid : Guid
   }
   interface IRequest<TenantEntity>


module Queries = 

      (*type GetTenantQuery() = 
           interface IRequest<TenantEntity>

           member val Gid = Guid.Empty with get, set*)

      type GetTenantsQuery() = 
           interface IRequest<seq<TenantEntity>>
