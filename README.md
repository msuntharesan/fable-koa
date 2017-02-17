# fable-koa

Fable bindings for Koa

## Installation

```sh
$ yarn install koa@next fable-core
$ yarn install fable-koa --dev
```

## Usage

### In a F# project (.fsproj)

```xml
  <ItemGroup>
    <Reference Include="node_modules/fable-core/Fable.Core.dll" />
    <Reference Include="node_modules/fable-koa/Fable.Import.Koa.dll" />
  </ItemGroup>
```

### In a F# script (.fsx)

```fsharp
#r "node_modules/fable-core/Fable.Core.dll"
#r "node_modules/fable-koa/Fable.Import.Koa.dll"

open Fable.Core
open Fable.Import
```

## License

MIT
