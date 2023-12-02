namespace AoC
open AoC.Day1
open System.Text.RegularExpressions

[<EntryPoint>]
let main argv =

    let day1Input = System.IO.File.ReadAllText("Day1/Day1Input.txt")

    let day1part1 = day1Input |> Day1.partOne
    printfn "%d" day1part1

    let day1part2 = day1Input |> Day1.partTwo
    printfn "%d" day1part2