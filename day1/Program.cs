using System.IO;


var input = @"
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
";


// check to see if this is a blank line or not
bool IsBlankLine(string line) => string.IsNullOrWhiteSpace(line);

//var lines = input.Split(new[] { '\r'}, StringSplitOptions.RemoveEmptyEntries);

var lines = File.ReadAllLines("input.txt");

var largestLine = 0;
var largestTemp = 0;
var topthree = new int[3];

foreach (var line in lines)
{
    if (IsBlankLine(line))
    {
        if (largestTemp > topthree[0])
        {
            topthree[2] = topthree[1];
            topthree[1] = topthree[0];
            topthree[0] = largestTemp;
        }
        else if (largestTemp > topthree[1])
        {
            topthree[2] = topthree[1];
            topthree[1] = largestTemp;
        }
        else if (largestTemp > topthree[2])
        {
            topthree[2] = largestTemp;
        }

        largestTemp = 0;
        continue;
    }

    largestTemp += int.Parse(line);
}

foreach (var line in topthree)
{
    largestLine += line;
    Console.WriteLine(line);
}

Console.WriteLine(largestLine);