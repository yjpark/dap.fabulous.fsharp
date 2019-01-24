# COMMON_OPENS #
```F#
open System
open Terminal.Gui
open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab
open Dap.Gui.Internal
open Dap.Console
```

# PREFAB_HEADER(prefab) #
```F#
type ${prefab} (logging : ILogging) =
    inherit BasePrefab<${prefab}, ${prefab}Props, ${prefab}Widget>
        (${prefab}Kind, ${prefab}Props.Create, logging, ${prefab}Widget.Create ())
```

# PREFAB_MIDDLE(prefab) #
```F#
do (
    let kind = ${prefab}Kind
    let owner = base.AsOwner
    let model = base.Model
    let widget = base.Widget
```

# PREFAB_HEADER_MIDDLE(prefab) #
```F#
//SILP: PREFAB_HEADER(${prefab})
    do (
        let kind = ${prefab}Kind
        let owner = base.AsOwner
        let model = base.Model
        let widget = base.Widget
```

# PREFAB_FOOTER(prefab) #
```F#
    static member Create l = new ${prefab} (l)
    static member Create () = new ${prefab} (getLogging ())
    override this.Self = this
    override __.Spawn l = ${prefab}.Create l
    interface IFallback

type I${prefab} with
    member this.As${prefab} = this :?> ${prefab}
```

# GROUP_HEADER(type, prefab) #
```F#
type ${prefab} (logging : ILogging) =
    inherit Base${type}<${prefab}, ${prefab}Props, ${prefab}Widget, View>
        (${prefab}Kind, ${prefab}Props.Create, logging, ${prefab}Widget.Create ())
```

# GROUP_HEADER_MIDDLE(type, prefab) #
```F#
//SILP: GROUP_HEADER(${type}, ${prefab})
    do (
        let kind = ${prefab}Kind
        let owner = base.AsOwner
        let model = base.Model
        let widget = base.Widget
```