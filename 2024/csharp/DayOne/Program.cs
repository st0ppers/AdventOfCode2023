using System.Collections;


Console.WriteLine(GetAnswer());
Console.WriteLine(GetAnswerPart2());
return;

string GetContentFromFile(string filename)
{
    var input = "";
    using var stream = File.OpenRead(filename);
    using var reader = new StreamReader(stream);
    do
    {
        input += "\n\r" + reader.ReadLine();
    } while (!reader.EndOfStream);

    return input;
}

int[] GetNumbers(string i) => i.Split(' ').SelectMany(s => s.Split("\n\r")).Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();

(List<int>, List<int>) GetBothColumns(int[] numbers)
{
    List<int> firstColumn = [];
    List<int> secondColumn = [];

    for (var i = 0; i < numbers.Length; i++)
    {
        if (i % 2 == 0)
        {
            secondColumn.Add(numbers[i]);
        }
        else
        {
            firstColumn.Add(numbers[i]);
        }
    }

    return (firstColumn, secondColumn);
}

double GetAnswer()
{
    var input = GetContentFromFile("./Input.txt");
    var allNumbers = GetNumbers(input);

    var (firstColumn, secondColumn) = GetBothColumns(allNumbers);

    firstColumn.Sort();
    secondColumn.Sort();

    return firstColumn.Select((f, i) => Math.Abs(f - secondColumn[i])).Sum();
}

double GetAnswerPart2()
{
    var input = GetContentFromFile("./Input2.txt");
    var allNumbers = GetNumbers(input);

    var (firstColumn, secondColumn) = GetBothColumns(allNumbers);
    var dictionary = new Dictionary<int, int>();
    foreach (var t in secondColumn)
    {
        foreach (var k in firstColumn)
        {
            if (k == t)
            {
                if (!dictionary.TryAdd(t, 1))
                {
                    dictionary[t] += 1;
                }
            }
        }
    }

    return dictionary.Sum(kvp => kvp.Key * kvp.Value);
}