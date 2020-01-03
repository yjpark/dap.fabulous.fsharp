[<AutoOpen>]
module Dap.Fabulous.Uno.Types

open System

open Dap.Prelude
open Dap.Gui
open Dap.Gui.App

type IUnoPlatform =
    inherit IGuiPlatform
    abstract Param : UnoParam with get

and UnoParam = {
    Name : string
    Title : string
    Port : int
    Actions : (IUnoPlatform -> unit) list
} with
    static member Create (name : string, ?title : string, ?port : int) : UnoParam =
        {
            Name = name
            Title = defaultArg title name
            Port = defaultArg port 8080
            Actions = []
        }
