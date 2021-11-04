open FSharp.Data

[<Literal>]
let url = "https://jsonplaceholder.typicode.com/users"
type Users = JsonProvider<url>

[<EntryPoint>]
let main args =
    Users.Load(url)
    |> Seq.take 1
    |> Seq.iter (fun user -> printfn $"User: {user}")
    0