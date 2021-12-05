var position = File.ReadLines("input.txt")
    .Select(line => line.Split(' '))
    .Select(lineParts => new
    {
        Direction = lineParts[0],
        Amount = int.Parse(lineParts[1])
    })
    .Aggregate(
        new Position(0, 0, 0),
        (position, instruction) => instruction.Direction switch
        {
            "forward" => Forward(position, instruction.Amount),
            "down" => Down(position, instruction.Amount),
            "up" => Up(position, instruction.Amount),
            _ => throw new Exception($"Unexpected direction {instruction.Direction}")
        }
    );

Console.WriteLine(position.Horizontal * position.Depth);

Position Forward(Position current, int amount) => new Position(current.Horizontal + amount, current.Depth + (current.Aim * amount), current.Aim);
Position Up(Position current, int amount) => new Position(current.Horizontal, current.Depth, current.Aim - amount);
Position Down(Position current, int amount) => new Position(current.Horizontal, current.Depth, current.Aim + amount);
record Position(int Horizontal, int Depth, int Aim);
