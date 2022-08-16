namespace IX.Platform.Gateways.Admin.Models

open IX.Platform.Core.Tenant.Contracts.Models

[<CLIMutable>]
type RootResponse = 
    { 
       result : TenantEntity
    }

[<CLIMutable>]
type RootResponseGetTenants = 
    { 
       result : seq<TenantEntity>
    }


