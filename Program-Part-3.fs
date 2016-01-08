open System

//let testArray() =
//    let array = [| 0; 1; 1; 2; 3; 5 |]
//    let sumarray =
//        let mutable c = 0
//        for i in 0..(array.Length - 1) do
//            c <- c + array.[i]
//        c
//    sumarray

type person =
    { name : string
      age : int
      id : int }

let GetUser username userage =
    { name = username
      age = userage
      id = userage * username.Length }

let mutable run = true

[<EntryPoint>]    
let main argv =
    Console.WriteLine("Enter the main users name: ")
    let name = Console.ReadLine()
    Console.WriteLine("Enter the main users age: ")
    let age = Console.ReadLine()
    let mainuser = GetUser name (int age)
    
    let people = 
        [ while run do
              Console.WriteLine("Do you want to add more people (y/n)? ")
              if Console.ReadLine().ToLower() = "y" then
                  Console.WriteLine("Enter the users name: ")
                  let name = Console.ReadLine()
                  Console.WriteLine("Enter the users age: ")
                  let age = Console.ReadLine()
                  yield GetUser name (int age)
              else 
                  run <- false ]

    let sameid =
        seq {
            for x in people do
                if x.id = mainuser.id then yield x
        }

    for x in sameid do
        Console.WriteLine(x.name)

    // Assignment
    let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9 |] // use ; instead of ,
    let l = arr.Length
    let isEven x = x % 2 = 0

    let out =
        [ for i = 0 to l - 1 do // l - 1
              if isEven arr.[i] then yield arr.[i] ]

    let newout = 0 :: out // replace @ with ::

    // The End
    Console.ReadKey()
    0 // return an integer exit code
