namespace IX.Platform.Shared.Data

open Microsoft.EntityFrameworkCore
open System.Linq
open System.Threading.Tasks
open System.Collections.Generic

module Repositories =
    type IRepository<'a> =
        abstract member All : unit -> seq<'a>

        abstract member GetAll : unit -> IQueryable<'a>

        abstract member GetAllAsync : unit -> Task<List<'a>>

        abstract member AddAsync : 'a -> Async<unit>

        abstract member UpdateAsync : 'a -> Async<unit>

        abstract member DeleteAsync : 'a -> Async<unit>

        abstract member GetByIdAsync: obj -> Async<ValueTask<'a>>

    type Repository<'b when 'b : not struct>(dbContext : DbContext) =
      do
        if dbContext = null then nullArg "dbContext"

      let mutable dbSet = dbContext.Set<'b>()

      member x.IRep = x :>  IRepository<'b>

      interface IRepository<'b> with

          // connect and return all
          member x.All() = dbSet

          // connect and return all  
          member x.GetAll() = dbSet
            
          // connect and return all
          member x.GetAllAsync() = dbSet.ToListAsync()

          // add and return unit
          member x.AddAsync(entity : 'b) =
            async {
                dbContext.AddAsync(entity) |> ignore
                let! _ = dbContext.SaveChangesAsync true |> Async.AwaitTask
                return ()
            }
          
          member x.UpdateAsync(entity : 'b) =
            async {
                let trackingEntity = dbContext.Update(entity)
                let! _ = dbContext.SaveChangesAsync true |> Async.AwaitTask
                return ()
            }

          member x.DeleteAsync(entity : 'b) =
            async {
                let trackingEntity = dbContext.Remove(entity)
                let! _ = dbContext.SaveChangesAsync true |> Async.AwaitTask
                return ()
            }

          member x.GetByIdAsync(id : obj) =
            async {
                let result = dbSet.FindAsync(id);
                return result
            }