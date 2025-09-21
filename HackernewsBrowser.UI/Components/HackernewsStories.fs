namespace HackernewsBrowser.UI.Components

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor

module HackernewsStories =
    let storyBrowser (storyIdsAval: aval<int list>) (isLoadingCval: cval<bool>) (toolbarContent: NodeRenderFragment) =
        fragment {
            adapt {
                let! storyIds = storyIdsAval
                let! isLoading = isLoadingCval
                MudTable''{
                    Items storyIds
                    Breakpoint Breakpoint.Sm
                    Loading isLoading
                    FixedHeader true
                    LoadingProgressColor Color.Info
                    Striped true
                    Height "80vh"
                    ToolBarContent toolbarContent
                    HeaderContent (
                        fragment {
                            MudTh''{ "ID" }
                        }
                    )
                    RowTemplate (fun (storyId: int) ->
                        fragment {
                            MudTd''{ $"{storyId}" }
                        }
                    )
                }
            }
        }