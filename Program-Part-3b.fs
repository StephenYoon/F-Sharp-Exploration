open System
(*This is my code*)
(*Link to Solution can be found here - http://pastebin.com/BMNM249B*)

// function to get an integer value from the console
let getFloatValueFromConsole() =
    let canparse, keyin = System.Double.TryParse(Console.ReadLine())
    if canparse && keyin > 0.0 then 
        float keyin
    else 0.

// function to get the golden value
let getGoldenValue inputNumber = 
    let returnValue = inputNumber * ((1. + Math.Sqrt(5.)) / 2.)
    returnValue

// variable to indicate loop termination
let mutable run = true

[<EntryPoint>]
let main argv = 
    
    // ask for input values to compute the golden values, save in a list
    let goldenValues = 
      [ while run do
              Console.WriteLine("Do you want to enter a number to compute the Golden Value (y/n)? ")
              if Console.ReadLine().ToLower() = "y" then
                  Console.WriteLine("Enter number: ")
                  let inputValue = getFloatValueFromConsole()
                  yield (inputValue, getGoldenValue(inputValue))
              else 
                  run <- false ]


    // Output list
    for (inputValue, goldenValue) in goldenValues do
        printfn "InputValue: %f, Golden Value: %f" inputValue goldenValue
            
    // The End
    Console.ReadKey()
    0 // return an integer exit code
