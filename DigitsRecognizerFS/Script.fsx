
open System.IO

type Observation = { Label:string; Pixels: int[] }

type Distance = int[] * int[] -> int

let toObservation (csvData:string) =
    let columns = csvData.Split(',')
    let label = columns.[0]
    let pixels = columns.[1..] |> Array.map int
    { Label = label; Pixels = pixels}

let reader path =
    let data = File.ReadAllLines path
    data.[1..]
    |> Array.map toObservation

let manhattanDistance ( pixels1, pixels2 ) =
    Array.zip pixels1 pixels2
    |> Array.map ( fun (x,y) -> abs (x-y) )
    |> Array.sum

let euclidianDistance ( pixels1, pixels2 ) =
    Array.zip pixels1 pixels2
    |> Array.map ( fun (x,y) -> pown (x-y) 2 )
    |> Array.sum

let train (trainingset:Observation[]) (dist:Distance) =
    let classify (pixels:int[]) =
        trainingset
        |> Array.minBy (fun x -> dist ( x.Pixels, pixels))
        |> fun x -> x.Label
    classify

let dataPath =  @"D:\repos\MLProjects\data\"
let trainingPath = dataPath + "trainingsample.csv"
let trainingData = reader trainingPath

let manhattanClassifier = train trainingData manhattanDistance
let euclidianClassifier = train trainingData euclidianDistance

let validationPath = dataPath + "validationsample.csv"
let validationData = reader validationPath

validationData
|> Array.averageBy (fun x -> if manhattanClassifier x.Pixels = x.Label then 1. else 0.) 
|> printfn "Correct %.3f"





