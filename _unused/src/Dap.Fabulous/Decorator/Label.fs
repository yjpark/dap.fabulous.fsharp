[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Label

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator
        (?backgroundColor : Color, ?update : Label -> unit,
            ?horizontalOptions : LayoutOptions, ?verticalOptions : LayoutOptions, ?margin : Thickness,
            ?textColor : Color, ?fontSize : float) =
    inherit View.Decorator<Label>
        (?backgroundColor = backgroundColor, ?update = update,
            ?horizontalOptions = horizontalOptions, ?verticalOptions = verticalOptions, ?margin = margin)
    override __.Decorate (widget : Label) =
        base.Decorate widget
        textColor
        |> Option.iter (fun x -> widget.TextColor <- x)
        fontSize
        |> Option.iter (fun x -> widget.FontSize <- x)