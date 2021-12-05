var input = File.ReadLines("input.txt")
    .Select(x => int.Parse(x))
    .ToArray();

var windows = input
    .Skip(2)
    .Select((x, i) => x + input[i] + input[i + 1])
    .ToArray();

var increaseingCount = 0;
for (var i = 1; i < windows.Count(); i++)
{
    if (windows[i] > windows[i - 1])
    {
        increaseingCount++;
    }
}

Console.WriteLine(increaseingCount);