namespace HackernewsBrowser.UI.Layout

open Fun.Blazor
open MudBlazor

module MainLayout =
    let view (body: NodeRenderFragment) =
        fragment {
            MudAppBar''{
                Color Color.Primary
                Fixed false
                MudMenu''{
                    Dense true
                    Variant Variant.Text
                    Size Size.Medium
                    Color Color.Inherit
                    Icon Icons.Material.TwoTone.MoreVert

                    MudMenuItem''{
                        Href "/topstories"
                        Icon Icons.Material.TwoTone.Newspaper
                        Label "Top stories"
                    }

                    MudMenuItem''{
                        Href "/home"
                        Icon Icons.Material.TwoTone.Abc
                        Label "Hacker News"
                    }
                }
            }
            MudMainContent''{
                class' "pt-2 pr-2 pb-2 pl-2"
                body
            }
        }