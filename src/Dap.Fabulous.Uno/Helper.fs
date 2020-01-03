[<AutoOpen>]
module Dap.Fabulous.Uno.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App

let getFabulousUnoParam () =
    getGuiParam ()

let setFabulousUnoParam (param : UnoParam) =
    setGuiParam param
