namespace AoC
open AoC.Day1

module main =

    let day1Input = System.IO.File.ReadAllText("Day1/Day1Input.txt")

    let day1Result = day1Input |> Day1.partOne
    printfn "%d" day1Result