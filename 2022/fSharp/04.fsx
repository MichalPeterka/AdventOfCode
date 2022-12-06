open System.IO
open System.Linq

let path filename = $"{__SOURCE_DIRECTORY__}/../inputs/{__SOURCE_FILE__ |> Path.GetFileNameWithoutExtension}-{filename}.txt"

let examples = 
    File.ReadAllLines (path "examples")

let input = 
    File.ReadAllLines (path "input")

let parse (row: string) = row.Split([|',';'-'|]) |> Array.map int

let subsumes [|minA; maxA; minB; maxB|] =
    minB >= minA && minB <= maxA && maxB >= minA && maxB <= maxA
    || minA >= minB && minA <= maxB && maxA >= minB && maxA <= maxB

let part1 = 
    input
    |> Array.map parse
    |> Array.filter subsumes
    |> Array.length

let intersects [|minA; maxA; minB; maxB|] =
    minA <= minB && minB <= maxA
    || minA <= maxB && maxB <= maxA
    || minB <= minA && minA <= maxB
    || minB <= maxA && maxA <= maxB

let part2 =
    input
    |> Array.map parse
    |> Array.filter intersects
    |> Array.length
