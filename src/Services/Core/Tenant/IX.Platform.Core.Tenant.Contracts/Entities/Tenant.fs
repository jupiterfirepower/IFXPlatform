namespace IX.Platform.Core.Tenant.Contracts

open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema
open System

module Entities =
    
    [<Table("Tenants", Schema = "IXPPlatform")>] 
    type Tenant() =
       [<Required>]
       member val Id = Guid.Empty with get, set
       [<Required>]
       [<MaxLength(250)>]
       member val CompanyName = "" with get, set

              










