namespace IX.Platform.Core.Tenant.Contracts.Models

open System
open System.Text.Json.Serialization

[<CLIMutable>]
type TenantEntity = 
    { 
       [<JsonPropertyName("Id")>]
       Id: Guid
       [<JsonPropertyName("CompanyName")>]
       CompanyName: string
    }