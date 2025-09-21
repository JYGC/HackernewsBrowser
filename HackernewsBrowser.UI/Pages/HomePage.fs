namespace HackernewsBrowser.UI.Pages

open Fun.Blazor

module HomePage =
    let routerView () = fragment {
        h3 { "Welcome to HackernewsBrowser!" }
        p { "This is the home page of the HackernewsBrowser application." }
    }
