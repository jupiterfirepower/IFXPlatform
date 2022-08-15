namespace IX.Platform.Core.Tenant.Infrastucture

open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Shared.Data.Repositories
open IX.Platform.Core.Tenant.Contracts.Entities
open Microsoft.EntityFrameworkCore
open System
open AppContext

module Repositories = 

    type TenantRepository(dbContext : TenantDbContext) =
       inherit Repository<Tenant>(dbContext)

       interface ITenantRepository with

           // connect and return all
           member x.GetAllAsync() =  base.IRep.GetAll()

           member x.GetByIdAsync(Id:Guid) = base.IRep.GetByIdAsync(Id)
       


                  
