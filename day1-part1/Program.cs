﻿var input = File.ReadLines("input.txt")
    .Select(line => int.Parse(line))
    .ToArray();

var increaseingCount = 0;
for (var i = 1; i < input.Count(); i++)
{
    if (input[i] > input[i - 1])
    {
        increaseingCount++;
    }
}

Console.WriteLine(increaseingCount);