open System.IO
open System.Linq

let path filename = $"{__SOURCE_DIRECTORY__}/../inputs/{__SOURCE_FILE__ |> Path.GetFileNameWithoutExtension}-{filename}.txt"

let examples = 
    File.ReadAllLines (path "examples")
    |> List.ofArray

let input = 
    File.ReadAllLines (path "full")
    |> List.ofArray

let values = [' '] @ ['a'..'z'] @ ['A' .. 'Z']
let evaluate (ch: char) = values |> Seq.findIndex (fun x -> x = ch)
let intersect (seq: char[] seq) = (seq |> Seq.head).Intersect (seq |> Seq.item 1)
let splitInHalf seq = seq |> Seq.splitInto 2

let part1 = 
    input
    |> Seq.sumBy (splitInHalf >> intersect >> Seq.head >> evaluate)

let part2 =
    [for i in 0 .. 3 .. (input.Length - 1) ->
        (input.[i].Intersect input.[i+1]).Intersect input.[i+2]]
    |> Seq.sumBy (Seq.head >> evaluate)
