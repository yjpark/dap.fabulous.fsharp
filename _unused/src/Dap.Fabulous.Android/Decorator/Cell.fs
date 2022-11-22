[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Decorator.Cell

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator

// Xamarin.Forms.Platform.Android/Cells/CellRenderer.cs

let getRenderer<'renderer when 'renderer : not struct and 'renderer : null and 'renderer :> CellRenderer> (logger : ILogger) (cell : Cell) : 'renderer option =
    Util.getBindableValue<CellRenderer, 'renderer> logger "RendererProperty" cell
    |> Option.bind (fun renderer ->
        if renderer =? null then
            logError logger "Cell.getRenderer" "Renderer_Is_Null" (cell)
            None
        else
            Some renderer
    )