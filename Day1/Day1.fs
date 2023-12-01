namespace AoC

open System

module Day1 =

    let extractNumbers (input : string) = 
        let ret = input |> Seq.filter (fun c -> c |> Char.IsDigit) |> Array.ofSeq |> String
        ret

    let takeFirstNumber (input : string) = (input |> extractNumbers) |> Seq.head

    let takeLastNumber (input : string) = (input |> extractNumbers) |> Seq.last

    let buildNumbers (input : string) =
        let firstNumber = input |> takeFirstNumber
        let lastNumber = input |> takeLastNumber
        let calibVal = seq {firstNumber; lastNumber} |> Array.ofSeq |> String
        int calibVal

    let partOne (input : string) = 
        let lines = input.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)
        let ret = seq {
            for line in lines do
                (line |> buildNumbers)
        }
        let sum = ret |> Seq.sum
        sum