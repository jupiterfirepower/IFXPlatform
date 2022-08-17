namespace IX.Platform.Core.Tenant.Contracts

open System.Threading.Tasks
open System
open Entities
open IX.Platform.Core.Tenant.Contracts.Models

module Interfaces =

 type ITenantRepository =
      interface
        abstract member GetAllAsync : unit -> seq<Tenant>

        abstract member GetByIdAsync: Guid -> Async<ValueTask<Tenant>>

        abstract member AddAsync: TenantEntity -> Task<TenantEntity>

        abstract member UpdateAsync: TenantEntity -> Task<TenantEntity>

        abstract member DeleteAsync: Guid -> Task<Guid>
      end