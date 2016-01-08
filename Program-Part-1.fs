open System

// Our cylinder volume function: (2 * pi * r^2) * h
let cylindervolume r h : float = (2.0 * 3.14 * Math.Pow(r, 2.0)) * h

let checknum v =
    if v = 5 then "I am 5"
    elif v < 5 then "Less than 5"
    else "Some other number"

let loopfunc max =
    for index = 0 to max do
        printf "%A" index

let whileloop max =
    let mutable continueLooping = true
    let mutable counter = 0
    while continueLooping do
        printfn "%A" counter
        counter <- counter + 1
        if counter = max then continueLooping <- false

let rec fib x =
    if x <= 2 then 1
    else fib (x - 1) + fib (x - 2)

let checkvalue (argv : string []) : int =
    if argv.Length > 0 then      
        let couldparse, consolein = Int32.TryParse(argv.[0])
        if couldparse then consolein
        else
            let canparse, keyin = Int32.TryParse(Console.ReadLine())
            if canparse then keyin
            else 0
    else
        let canparse, keyin = Int32.TryParse(Console.ReadLine())
        if canparse then keyin
        else 0
        
let fibonacci n =
    let mutable first = 0
    let mutable second = 1
    let mutable temp = 0
    for index = 1 to n do
        temp <- first + second
        first <- second
        second <- temp
    first

let rec fibonaccirecursive n =
    if n = 0 then 0
    elif n <= 2 then 1
    else
        fibonaccirecursive (n - 1) + fibonaccirecursive (n - 2)

//let rec dosomethingrandom x =
//    if x <= 0 then Console.WriteLine(1)
//    else dosomethingrandom ((x - 1) * x)

let rec dosomethingrandom x : int =
    if x = 0 then 1
    else 
        let answer = dosomethingrandom (x - 1)
        let newAnswer = answer * x
        newAnswer

[<EntryPoint>]
let main argv =

    let input = Console.ReadLine();
    let value = int input

    let answer = dosomethingrandom value
    printfn "%A" answer

    // return an integer exit code
    let anyValue = Console.ReadKey()
    0 
    
//    // Get cylinder radius
//    Console.Write("Enter cylinder radius: ")
//    let radius = Console.ReadLine()
//    let r = float radius
//
//    // Get cylinder height
//    Console.Write("Enter cylinder height: ")
//    let height = Console.ReadLine()
//    let h = float height
//
//    // Calculate and display cylinder volume
//    let calc  = cylindervolume r h
//    printf "Cylinder volume: %f" calc
//
//    // Pause to view answer
//    let anyValue = Console.ReadKey();
//    0 // return an integer exit code

