namespace IX.Platform.Core.Tenant.Contracts

open System.Threading.Tasks
open System
open Entities

module Interfaces =

 type ITenantRepository =
      interface
        abstract member GetAllAsync : unit -> seq<Tenant>

        abstract member GetByIdAsync: Guid -> Async<ValueTask<Tenant>>
      end