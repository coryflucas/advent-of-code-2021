var numberOfBits = File.ReadLines("input.txt")
    .First()
    .Count();

var inputs = File.ReadLines("input.txt")
    .Select(line => Convert.ToInt32(line, 2))
    .ToList();

var oxygenRatingPosibilities = inputs;
for (int i = numberOfBits - 1; i >= 0; i--)
{
    var numberOfOnes = oxygenRatingPosibilities.Select(input => (input >> i) & 1)
        .Sum();
    var mostCommonBit = numberOfOnes >= (oxygenRatingPosibilities.Count / 2.0) ? 1 : 0;
    oxygenRatingPosibilities = oxygenRatingPosibilities.Where(input => ((input >> i) & 1) == mostCommonBit)
        .ToList();
    if (oxygenRatingPosibilities.Count == 1)
    {
        break;
    }
}

var co2RatingPosibilities = inputs;
for (int i = numberOfBits - 1; i >= 0; i--)
{
    var numberOfOnes = co2RatingPosibilities.Select(input => (input >> i) & 1)
        .Sum();
    var mostCommonBit = numberOfOnes >= (co2RatingPosibilities.Count / 2.0) ? 0 : 1;

    co2RatingPosibilities = co2RatingPosibilities.Where(input => ((input >> i) & 1) == mostCommonBit)
        .ToList();
    if (co2RatingPosibilities.Count == 1)
    {
        break;
    }
}

Console.WriteLine(oxygenRatingPosibilities.Single() * co2RatingPosibilities.Single());