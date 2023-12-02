namespace AoC

open System
open System.Text.RegularExpressions
open BenchmarkDotNet.Attributes

module Day1 =

    type Day1() =
        let input = System.IO.File.ReadAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Documents/Code/AoC/AdventOfCode2023/Day1/Day1Input.txt")

        let extractNumbers (input : string) = 
            let ret = input |> Seq.filter (fun c -> c |> Char.IsDigit) |> Array.ofSeq |> String
            ret

        let extractNumbersAndWords (input : string) =
                let wordNumbers = [|"zero"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"|]
                let reg = "one|two|three|four|five|six|seven|eight|nine|0|1|2|3|4|5|6|7|8|9"
                let rxMatches = Regex.Matches(input, reg)
                let rxMatchesReverse = Regex.Matches(input, reg, RegexOptions.RightToLeft)
                let res = seq {
                    for m in rxMatches do
                        if (m.Value |> Seq.head) |> Char.IsDigit then
                            m.Value
                        else
                            let number = wordNumbers |> Seq.findIndex (fun x -> x = m.Value)
                            string number
                }
                let resReverse = seq {
                    for m in rxMatchesReverse do
                        if (m.Value |> Seq.head) |> Char.IsDigit then
                            m.Value
                        else
                            let number = wordNumbers |> Seq.findIndex (fun x -> x = m.Value)
                            string number
                }
                let out = Seq.append res (resReverse |> Seq.rev)
                out

        let takeFirstNumber (input : string) = (input |> extractNumbers) |> Seq.head

        let takeLastNumber (input : string) = (input |> extractNumbers) |> Seq.last

        let buildNumbers (input : string) =
            let firstNumber = input |> takeFirstNumber
            let lastNumber = input |> takeLastNumber
            let calibVal = seq {firstNumber; lastNumber} |> Array.ofSeq |> String
            int calibVal

        let takeFirstNumberAndWord (input : string) = (input |> extractNumbersAndWords) |> Seq.head

        let takeLastNumberAndWord (input : string) = (input |> extractNumbersAndWords) |> Seq.last
        
        let buildNumbersAndWords (input : string) =
            let firstNumber = input |> takeFirstNumberAndWord
            let lastNumber = input |> takeLastNumberAndWord
            let calibVal = [| firstNumber; lastNumber |] |> List.ofSeq |> string
            let out = calibVal.Replace(";", "").Replace("[", "").Replace("]", "").Replace(" ", "") |> string
            int out

        [<Benchmark>]
        member this.partOne() = 
            let lines = input.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)
            let ret = seq {
                for line in lines do
                    (line |> buildNumbers)
            }
            let sum = ret |> Seq.sum
            int sum

        [<Benchmark>]
        member this.partTwo() =
            let lines = input.Split([|'\n'|], StringSplitOptions.RemoveEmptyEntries)
            let ret = seq {
                for line in lines do
                    (line |> buildNumbersAndWords)
            }
            let sum = ret |> Seq.sum
            int sum