# AdventOfCode2023

This is my take on AoC 2023.

## Focus this year:

* Leaner setup. So far I've used a self-written "framework" where I'd auto-download and add new days through a very exhaustive OOP setup in C#. Not that it was a very good framework to begin with. I'm attempting to utilize more efficient means of running things.
* F# as my focus language. I gave this a try for a few solutions last year and quite liked it. So, I wanna try a more functional approach.

As always, I'll be benchmarking my solution through BenchmarkDotNet and provide all necessary info for the benchmark.

## Results

### Remarks

I am fully aware that a benchmark like this is in itself useless in terms of information, as my code might perform differently on your machine, even my machine under a different OS or base load. This is just my personal "how much time would this realistically be wasting/how does it scale when run multiple times?" fun metric. I also have to cut some corners in implementations as e.g. BenchmarkDotNet seems to run through IEnumerable inputs starting with an empty input. Therefore, runs might be measured than they actually are faster as I'll essentially be skipping the entire algorithm if certain conditions aren't met.

### Relevant execution parameters

```
BenchmarkDotNet v0.13.10, NixOS 23.11 (Tapir)
AMD FX(tm)-8300, 1 CPU, 8 logical and 4 physical cores
.NET SDK 6.0.412
  [Host]     : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX DEBUG
  DefaultJob : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX
```

### Day 1

| Method  | Mean      | Error     | StdDev    |
|-------- |----------:|----------:|----------:|
| partOne |  1.772 ms | 0.0310 ms | 0.0275 ms |
| partTwo | 20.755 ms | 0.3067 ms | 0.2719 ms |