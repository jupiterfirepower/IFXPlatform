namespace IX.Platform.Core.Tenant.Infrastucture

open Microsoft.EntityFrameworkCore
open IX.Platform.Shared.Data.Contexts
open IX.Platform.Core.Tenant.Contracts.Entities
open System

module AppContext =

       type ModelBuilder with
            /// Repeat each element of the sequence n times
            member x.Seed() =
                   let data = new Tenant()

                   data.Id <- Guid.NewGuid()
                   data.CompanyName <- "test company name"

                   x.Entity<Tenant>().HasData(data)
      
       type TenantDbContext(options : DbContextOptions) =
            inherit BaseDbContext(options)

            override x.OnConfiguring(options : DbContextOptionsBuilder) = options.UseSqlServer("Data Source=localhost,1439;Initial Catalog=ixp-dev-db;User Id=sa;Password=mssql-password123;") |> ignore

            override x.OnModelCreating(modelBuilder : ModelBuilder) = 
                     base.OnModelCreating(modelBuilder)

                     modelBuilder.HasDefaultSchema("IXPPlatform") |> ignore

                     modelBuilder.Seed() |> ignore