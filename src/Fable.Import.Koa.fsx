#r "../node_modules/fable-core/Fable.Core.dll"

namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Node
open Fable.Import.Node.http_types
open Fable.Import.Node.events

type [<AllowNullLiteral>] ListenOptions =
    abstract port: float option with get, set
    abstract host: string option with get, set
    abstract backlog: float option with get, set
    abstract path: string option with get, set
    abstract exclusive: bool option with get, set

[<AutoOpen>]
module koa =
  type [<AllowNullLiteral>] Context =
      inherit Request
      inherit Response
      abstract app: Koa with get, set
      abstract req: IncomingMessage with get, set
      abstract res: ServerResponse with get, set
      abstract request: Request with get, set
      abstract response: Response with get, set
      abstract cookies: obj with get, set
      abstract originalUrl: string with get, set
      abstract state: obj with get, set
      abstract name: string option with get, set
      abstract respond: bool option with get, set
      [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set
      abstract ``assert``: test: obj * [<ParamArray>] args: obj[] -> unit
      abstract onerror: ?err: obj -> unit
      abstract throw: [<ParamArray>] args: obj[] -> unit
      abstract toJSON: unit -> obj
      abstract inspect: unit -> obj

  and [<AllowNullLiteral>] Request =
      abstract app: Koa with get, set
      abstract req: IncomingMessage with get, set
      abstract res: ServerResponse with get, set
      abstract ctx: Context with get, set
      abstract response: Response with get, set
      abstract fresh: bool with get, set
      abstract header: obj with get, set
      abstract headers: obj with get, set
      abstract host: string with get, set
      abstract hostname: string with get, set
      abstract href: string with get, set
      abstract idempotent: bool with get, set
      abstract ip: string with get, set
      abstract ips: ResizeArray<string> with get, set
      abstract ``method``: string with get, set
      abstract origin: string with get, set
      abstract originalUrl: string with get, set
      abstract path: string with get, set
      abstract protocol: string with get, set
      abstract query: obj with get, set
      abstract querystring: string with get, set
      abstract search: string with get, set
      abstract secure: bool with get, set
      abstract socket: net_types.Socket with get, set
      abstract stale: bool with get, set
      abstract subdomains: ResizeArray<string> with get, set
      abstract ``type``: string with get, set
      abstract url: string with get, set
      abstract charset: string option with get, set
      abstract length: float option with get, set
      abstract accepts: unit -> ResizeArray<string>
      abstract accepts: arg: string -> U2<unit, string>
      abstract accepts: arg: ResizeArray<string> -> U2<unit, string>
      abstract acceptsCharsets: unit -> ResizeArray<string>
      abstract acceptsCharsets: arg: string -> U2<unit, string>
      abstract acceptsCharsets: arg: ResizeArray<string> -> U2<unit, string>
      abstract acceptsEncodings: unit -> ResizeArray<string>
      abstract acceptsEncodings: arg: string -> U2<unit, string>
      abstract acceptsEncodings: arg: ResizeArray<string> -> U2<unit, string>
      abstract acceptsLanguages: unit -> ResizeArray<string>
      abstract acceptsLanguages: arg: string -> U2<unit, string>
      abstract acceptsLanguages: arg: ResizeArray<string> -> U2<unit, string>
      abstract get: field: string -> string
      abstract is: unit -> ResizeArray<string>
      abstract is: arg: string -> U2<unit, string>
      abstract is: arg: ResizeArray<string> -> U2<unit, string>
      abstract toJSON: unit -> obj
      abstract inspect: unit -> obj

  and [<AllowNullLiteral>] Response =
      abstract app: Koa with get, set
      abstract req: IncomingMessage with get, set
      abstract res: ServerResponse with get, set
      abstract ctx: Context with get, set
      abstract request: Request with get, set
      abstract body: obj with get, set
      abstract etag: string with get, set
      abstract header: obj with get, set
      abstract headers: obj with get, set
      abstract headerSent: bool with get, set
      abstract lastModified: DateTime with get, set
      abstract message: string with get, set
      abstract socket: net_types.Socket with get, set
      abstract status: float with get, set
      abstract ``type``: string with get, set
      abstract writable: bool with get, set
      abstract charset: string option with get, set
      abstract length: float option with get, set
      abstract append: field: string * ``val``: U2<string, ResizeArray<string>> -> unit
      abstract attachment: ?filename: string -> unit
      abstract get: field: string -> string
      abstract is: unit -> ResizeArray<string>
      abstract is: arg: string -> U2<unit, string>
      abstract is: arg: ResizeArray<string> -> U2<unit, string>
      abstract redirect: url: string * ?alt: string -> unit
      abstract remove: field: string -> unit
      abstract set: field: string * ``val``: U2<string, ResizeArray<string>> -> unit
      abstract set: field: obj -> unit
      abstract vary: field: string -> unit
      abstract toJSON: unit -> obj
      abstract inspect: unit -> obj

  and Middleware = Func<Context, unit -> Promise<unit>, Promise<unit>>
  
  and [<AllowNullLiteral>] [<Import("default","koa")>] Koa() =
    inherit EventEmitter()
    member __.subdomainOffset with get(): float = jsNative and set(v: float): unit = jsNative
    member __.server with get(): Server = jsNative and set(v: Server): unit = jsNative
    member __.env with get(): string = jsNative and set(v: string): unit = jsNative
    member __.context with get(): Context = jsNative and set(v: Context): unit = jsNative
    member __.keys with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
    member __.proxy with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.request with get(): Request = jsNative and set(v: Request): unit = jsNative
    member __.response with get(): Response = jsNative and set(v: Response): unit = jsNative
    member __.silent with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.listen(): Server = jsNative
    member __.listen(port: float, ?hostname: string, ?backlog: float, ?listeningListener: Function): Server = jsNative
    member __.listen(port: float, ?hostname: string, ?listeningListener: Function): Server = jsNative
    member __.listen(port: float, ?backlog: float, ?listeningListener: Function): Server = jsNative
    member __.listen(port: float, ?listeningListener: Function): Server = jsNative
    member __.listen(path: string, ?backlog: float, ?listeningListener: Function): Server = jsNative
    member __.listen(path: string, ?listeningListener: Function): Server = jsNative
    member __.listen(handle: obj, ?backlog: float, ?listeningListener: Function): Server = jsNative
    member __.listen(handle: obj, ?listeningListener: Function): Server = jsNative
    member __.listen(options: ListenOptions, ?listeningListener: Function): Server = jsNative
    member __.callback(): Func<IncomingMessage, ServerResponse, unit> = jsNative
    member __.onerror(err: obj): unit = jsNative
    member __.``use``(middleware: Middleware): Koa = jsNative
    member __.toJSON(): obj = jsNative
    member __.inspect(): obj = jsNative

