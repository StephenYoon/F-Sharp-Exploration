(*This is my code for easy viewing: http://pastebin.com/i6DJDEbQ *)

open System
open System.IO

// calculations
let gravity = 9.81
let distanceTravelled speed = (Math.Pow(speed, 2.) * Math.Sin(2.)) * gravity
let calculateAngle x y = Math.Atan(y/x)
let angleOfReach distance speed = 0.5 * Math.Asin((gravity * distance) / Math.Pow(speed, 2.))

// trajectory object
type Entity =
    { X : float
      Y : float
      Speed : float
      ExpectedDistance : float
      Name : string }
      
// read trajectory data from file
let GetFile =
    Console.Write("Enter the full path to the name of the input file: ")
    Console.ReadLine()
    
// multi case to classify trajectory entity
let (|TargetHit|RequiresAngleAdjustment|) (input:Entity) = 
    match input with
    | { Entity.X = x; Entity.Y = y; Entity.Speed = speed; Entity.ExpectedDistance = expectedDistance; Entity.Name = name } when expectedDistance = distanceTravelled speed -> TargetHit
    | _ -> RequiresAngleAdjustment

[<EntryPoint>]    
let main argv =
    try
        use input =
            new StreamReader(match argv.Length with
                             | 0 -> GetFile    
                             | _ -> argv.[0])    

        let entities =
            [ while not input.EndOfStream do
                  let raw = input.ReadLine()
                  let values = raw.Split(',')
                  yield { X = float values.[0]
                          Y = float values.[1]
                          Speed = float values.[2]
                          ExpectedDistance = float values.[3]
                          Name = values.[4] } ]
                        
        for p in entities do
            match p with
            | TargetHit -> printfn "%A hit their target." p.Name
            | RequiresAngleAdjustment -> printfn "%A requires an angle adjustment of: %F" p.Name (calculateAngle p.X p.Y)

        Console.ReadKey()
        0
    with
    | :? System.IO.FileNotFoundException ->
        Console.Write("File Not Found. Press a key to exit")
        Console.ReadKey()
        -1
    | _ ->
        Console.Write("Something else happened")
        Console.ReadKey()
        -1
