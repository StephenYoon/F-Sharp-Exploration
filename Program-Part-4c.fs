open System
open System.IO

type MyRecord = 
    { IP : string;
        MAC : string;
        FriendlyName : string;
        ID : int }

let IsMatchByName record1 name =
    match record1 with
    | { MyRecord.FriendlyName = nameFound; MyRecord.ID = id; IP = ip } when nameFound = name -> Some((id, ip))
    | _ -> None  

let checkmatch input =
    match input with
    | Some(x, y) -> printfn "%A" x
    | _ -> printfn "%A" "Sorry no match"  

[<EntryPoint>]
let main argv = 

    let data =  { IP = "10.1.1.1"; MAC = "FF:FF:FF:FF:FF:FF"; FriendlyName = "ServerFailure"; ID = 0 }
    let results = IsMatchByName data "ServerFailure"
    checkmatch results

    Console.ReadKey()
    0 // return an integer exit code
