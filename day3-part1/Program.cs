var numberOfBits = File.ReadLines("input.txt")
    .First()
    .Count();

var inputs = File.ReadLines("input.txt")
    .Select(line => Convert.ToInt32(line, 2))
    .ToList();

var gamma = 0;
var epsilon = 0;
for (int i = 0; i < numberOfBits; i++)
{
    var numberOfOnes = inputs.Select(input => (input >> i) & 1)
        .Sum();
    var mostCommonBit = numberOfOnes > (inputs.Count / 2) ? 1 : 0;
    gamma += mostCommonBit << i;
    epsilon += (mostCommonBit ^ 1) << i;
}

Console.WriteLine(gamma * epsilon);