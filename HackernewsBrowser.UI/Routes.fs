namespace HackernewsBrowser.UI

open Fun.Blazor
open Fun.Blazor.Router
open HackernewsBrowser.UI.Pages
open HackernewsBrowser.UI.Layout
open Microsoft.AspNetCore.Components.Web
open MudBlazor

type Routes() =
    inherit FunComponent()

    override _.Render () = html.inject (fun (hook: IComponentHook) -> ErrorBoundary'() {
        ErrorContent(fun ex -> MudPaper'' {
            style {
                padding 10
                margin 20
            }
            Elevation 10
            MudText'' {
                Color Color.Error
                Typo Typo.subtitle1
                "Some error hanppened, you can try to refresh."
            }
            MudAlert'' {
                Severity Severity.Error
                ex.Message
            }
        })
        html.route [
            TopStories.routerView() |> routeCi "/"
            TopStories.routerView() |> routeCi "/topstories"
            HomePage.routerView() |> routeCi "/home"
        ]
        |> MainLayout.view
    })