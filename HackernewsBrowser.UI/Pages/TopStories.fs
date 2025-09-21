namespace HackernewsBrowser.UI.Pages

open Fun.Blazor
open System.Net.Http
open System.Text.Json
open MudBlazor
open FSharp.Data.Adaptive
open HackernewsBrowser.UI.Components

module TopStories =
    let routerView () = html.inject(fun (httpClient: HttpClient) ->
        let isLoadingCval = cval false

        let storyIdsStore: IStore<int list> = new Store<int list> ([])
        let storyIdsAval = AVal.ofObservable [] ignore storyIdsStore.Observable

        let getListAsync () =
            let _, setIsLoading = isLoadingCval.WithSetter().Value
            setIsLoading true
            async {
                let! json = httpClient.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty") |> Async.AwaitTask
                let list = JsonSerializer.Deserialize<int list>(json)
                storyIdsStore.Publish(list)
                transact(fun _ ->
                    setIsLoading false
                )
            } |> Async.Start

        getListAsync()

        HackernewsStories.storyBrowser
            storyIdsAval
            isLoadingCval
            (fragment {
                MudText''{
                    Typo Typo.h3
                    "Top Stories"
                }
                MudSpacer''{}
                MudText''{
                    Typo Typo.subtitle2
                    $"Total: {List.length storyIdsAval.Value}"
                }
            })
    )
