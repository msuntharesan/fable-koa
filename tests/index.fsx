#r "../node_modules/fable-core/Fable.Core.dll"
#r "../node_modules/fable-powerpack/Fable.PowerPack.dll"
#r "../Fable.Import.Koa.dll"

open System
open Fable.PowerPack
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let request = importDefault<obj -> obj>("supertest")
let test = importDefault<Func<string, obj -> JS.Promise<obj>,unit>>("ava")

test.Invoke("is listening", fun t ->
  let app = new Koa()
  app.``use``(fun ctx next -> 
    promise {
      ctx.body <- "hello"
    }
  ) |> ignore
  promise {
    return !!request(app.listen())
      ?get('/')
      ?set("Accept", "text/plain")
      ?expect(200)
  }
  |> Promise.map(fun resp -> !!resp?text :string)
  |> Promise.map(fun text -> t?``is``("hello", text))
)
