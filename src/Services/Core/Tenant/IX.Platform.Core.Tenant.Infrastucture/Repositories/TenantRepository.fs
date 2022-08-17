namespace IX.Platform.Core.Tenant.Infrastucture

open IX.Platform.Core.Tenant.Contracts.Interfaces
open IX.Platform.Shared.Data.Repositories
open IX.Platform.Core.Tenant.Contracts.Entities
open System
open AppContext
open IX.Platform.Core.Tenant.Contracts.Models
open Microsoft.Extensions.Logging
open AutoMapper

module Repositories = 

    type TenantRepository(dbContext : TenantDbContext, logger : ILogger<TenantRepository>, mapper : IMapper) =
       inherit Repository<Tenant>(dbContext)

       interface ITenantRepository with

           // connect and return all
           member x.GetAllAsync() =  base.IRep.GetAll()

           member x.GetByIdAsync(Id:Guid) = base.IRep.GetByIdAsync(Id)

           member x.AddAsync(item : TenantEntity) = let data = mapper.Map<Tenant>(item)
                                                    base.IRep.AddAsync(data) |> ignore
                                                    task { return item }

           member x.UpdateAsync(item : TenantEntity) = let data = mapper.Map<Tenant>(item)
                                                       base.IRep.UpdateAsync(data) |> ignore
                                                       task { return item }

           member x.DeleteAsync(Id : Guid) = let data = base.IRep.GetByIdAsync(Id) |> Async.RunSynchronously
                                             base.IRep.DeleteAsync(data.Result) |> ignore
                                             task { return data.Result.Id }
                                             
       


                  
