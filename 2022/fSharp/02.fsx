open System.IO

let path filename = $"{__SOURCE_DIRECTORY__}/../inputs/{__SOURCE_FILE__ |> Path.GetFileNameWithoutExtension}-{filename}.txt"

let examples = 
    File.ReadAllLines (path "examples")

let input = 
    File.ReadAllLines (path "full")

type Shapes = | Paper | Scrissors | Rock

type Shape = { Type: Shapes; WinsTo: Shapes; LosesTo: Shapes}

let evaluateShape shape =
        match shape with
        | Rock -> 1
        | Paper -> 2
        | Scrissors -> 3

let translateToShape char =
    match char with
    | 'B' | 'Y' -> { Type = Paper; WinsTo = Rock; LosesTo = Scrissors }
    | 'A' | 'X' -> { Type = Rock; WinsTo = Scrissors; LosesTo = Paper }
    | _         -> { Type = Scrissors; WinsTo = Paper; LosesTo = Rock }

let evaluate shapes =
    match shapes with
    | (a, b) when a = b -> 3 + evaluateShape b.Type
    | (a, b) when a.WinsTo = b.Type -> evaluateShape b.Type
    | (a, b) -> 6 + evaluateShape b.Type

let part1 = 
    input
    |> Array.sumBy (fun x -> 
                        (translateToShape x.[0], translateToShape x.[2])
                        |> evaluate )

type Results = | Win | Lose | Draw

let translateToResult char =
    match char with
    | 'Y' -> Draw
    | 'X' -> Lose
    | _ -> Win

let evaluate2 input  =
    match input with
    | (a, Lose) -> a.WinsTo |> evaluateShape
    | (a, Draw) -> 3 + (a.Type |> evaluateShape)
    | (a, Win) -> 6 + (a.LosesTo |> evaluateShape)

let part2 =
    input
    |> Array.sumBy (fun x -> 
        (translateToShape x.[0], translateToResult x.[2])
        |> evaluate2)