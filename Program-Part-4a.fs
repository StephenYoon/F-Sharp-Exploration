open System
open System.Drawing

[<EntryPoint>]
let main argv = 

//    // basic pattern matching
//    let checktuple x =
//        match x with
//        | ("Hello", b, c)  when b > 10 -> c
//        | (a,b,c) -> a.Length + b + c
//
//    printfn "%A" (checktuple ("Greetings", 10, 1))
//
//    // active case
//    let (|Even|Odd|) input = if input % 2 = 0 then Even else Odd
//    let TestNumber input =
//        match input with
//        | Even -> printfn "%d is even" input  
//        | Odd -> printfn "%d is odd" input  
//        
//    printfn "%A" (TestNumber 1)

    // single case
    let (|RGB|) (col : System.Drawing.Color) =
        ( col.R, col.G, col.B )

    let (|HSB|) (col : System.Drawing.Color) =
        ( col.GetHue(), col.GetSaturation(), col.GetBrightness() )

    let printRGB (col: System.Drawing.Color) =
        match col with
        | RGB(r, g, b) -> printfn " Red: %d Green: %d Blue: %d" r g b  

    let printHSB (col: System.Drawing.Color) =
        match col with
        | HSB(h, s, b) -> printfn " Hue: %f Saturation: %f Brightness: %f" h s b  

    let printAll col colorString =
        printfn "%s" colorString
        printRGB col
        printHSB col

    printAll System.Drawing.Color.Green "Green"

    // multi case
    let (|Positive|Negative|) x = if x < 0 then Negative else Positive

    // option type
    let keepIfPositive (a : int) = if a > 0 then Some(a) else None
    let check a =
        match keepIfPositive a with
            | Some(a) -> true  
            | _ -> false  

    // sub-type matching
    let checksubtype x =
        match x with
        | :? System.Int32 -> printfn "It is an int 32"  
        | :? System.String ->  printfn "It is a string"  
        | _ -> printfn "This is another type"  

    //
    type MyRecord = { Name: string; ID: int }
    let IsMatchByName record1 (name: string) =
        match record1 with
        | { MyRecord.Name = nameFound; MyRecord.ID = _; } when nameFound = name -> true  
        | _ -> false  

    printfn "hello world"
    Console.ReadKey()
    0 // return an integer exit code
