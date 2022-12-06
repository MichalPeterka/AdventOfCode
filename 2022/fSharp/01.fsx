open System.IO

let path filename = $"{__SOURCE_DIRECTORY__}/../inputs/{__SOURCE_FILE__ |> Path.GetFileNameWithoutExtension}-{filename}.txt"

let examples = 
    File.ReadAllLines (path "examples")
    |> Seq.toList

let input = 
    File.ReadAllLines (path "full")
    |> Seq.toList

let rec splitElfs (ls: string list) (elfs: int list) (state: int) =
    match ls with
    | [] -> elfs @ [state]
    | h::t when h = "" -> splitElfs t (elfs @ [state]) 0
    | h::t -> splitElfs t elfs (state + (int h))

let part1 = 
    splitElfs input [] 0
    |> Seq.max
    
let part2 =
    splitElfs input [] 0
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum