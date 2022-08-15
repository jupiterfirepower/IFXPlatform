namespace IX.Platform.Shared.Data

open Microsoft.EntityFrameworkCore

module Contexts = 

       type BaseDbContext(options : DbContextOptions) =
            inherit DbContext(options)

            do
               base.Database.EnsureCreated() |> ignore
