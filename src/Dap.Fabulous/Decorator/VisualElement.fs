[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.VisualElement

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Controls

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> VisualElement>
        (?update : 'widget -> unit, ?backgroundColor : Color) =
    inherit Element.Decorator<'widget> (?update = update)
    override __.Decorate (widget : 'widget) =
        base.Decorate widget
        backgroundColor
        |> Option.iter (fun x -> widget.BackgroundColor <- x)

type Decorator
        (?update : VisualElement -> unit, ?backgroundColor : Color) =
    inherit Decorator<VisualElement>
        (?update = update, ?backgroundColor = backgroundColor)
