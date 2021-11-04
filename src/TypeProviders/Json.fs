    open FSharp.Data
    open Microsoft.FSharp.Core

    module Todos =
        [<Literal>]
        let private todoUrl = "https://jsonplaceholder.typicode.com/todos"
        type private Todos = JsonProvider<todoUrl>
        let Run() =
           Todos.Load(todoUrl)
           |> Seq.toList
           |> List.sortBy (fun todo -> todo.UserId)
           |> List.groupBy (fun todo -> todo.Completed)
           |> List.iter (fun (key,value) -> printfn $"Completed: {key}; Todo Number: {value.Length}") 
    

    module Photos =
        [<Literal>]
        let private photosUrl = "https://jsonplaceholder.typicode.com/photos"
        type private Photos = JsonProvider<photosUrl>
        let Run() =
            Photos.Load(photosUrl)
            |> Seq.toList
            |> List.groupBy (fun photo -> photo.AlbumId)
            |> List.iter (fun (key,value) -> printfn  $"AlbumId: {key}; Photos Number: {List.length value}")


    module Users =
        [<Literal>]
        let private UserUrl = "https://jsonplaceholder.typicode.com/users"
        type private Users = JsonProvider<UserUrl>
        
        let Run() =
            Users.Load(UserUrl)
            |> Seq.take 1
            |> Seq.iter (fun user -> printfn  $"{user}")
    
    [<EntryPoint>]
    let main args =
        if (Array.length args) < 2 then
            printfn "There is no action associated with this argument"
            0
        else
            let first = Seq.item 1 args
            match first with
            | "users" -> Users.Run()
            | "todos" -> Todos.Run()
            | "photos" -> Photos.Run()
            | _ -> printfn "There is no action associated with this argument"
            0