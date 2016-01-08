(*This is my code*)
(*Link to Solution can be found here - http://pastebin.com/FVYBmqWf*)
open System

// function to return the name and age classification
let classifyAge name age : string = 
    if age >= 20 then name + " is no longer a teenager."
    elif age < 20 && age >= 13 then name + " is a teenager."
    else name + " is a kid or child."
        
// function to get an integer value from the console
let getIntValueFromConsole() : int =
    let canparse, keyin = Int32.TryParse(Console.ReadLine())
    if canparse && keyin > 0 then keyin
    else 0
    
// function to loop & classify names up to "max" number of times
let loopForNames max = 
    for index = 1 to max do
        Console.Write("Enter name: ")
        let name = Console.ReadLine()

        Console.Write("Enter age: ")
        let age = getIntValueFromConsole()
        
        printfn "%A" (classifyAge name age)

[<EntryPoint>]
let main argv = 

    // ask for number of name/age to be entered
    Console.Write("Enter number of names: ")
    let numberOfNames = getIntValueFromConsole()

    // loop for each name and display age group text
    loopForNames numberOfNames
    
    // pause to view answer and return an integer exit code
    let anyValue = Console.ReadKey()
    0 
