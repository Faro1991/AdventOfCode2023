namespace AoC
open AoC.Day1
open BenchmarkDotNet.Running

module Main =
    [<EntryPoint>]
    let main argv =

        let day1 = new Day1()

        let day1part1 = day1.partOne

        let day1part2 = day1.partTwo

        BenchmarkRunner.Run<Day1.Day1>() |> ignore

        0