// using static DayOne.DayOne.DayOne;


namespace DayOne.DayTwo;

public static class DayTwo
{
    public static int PartOne()
    {
        return GetContentFromFile("./DayTwo/DayTwo.txt")
            .Split("\n\r")
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Split(' ').Select(int.Parse))
            .Select(num => num.ToList())
            .Count(Check);
    }

    public static int PartTwo()
    {
        return GetContentFromFile("./DayTwo/DayTwo2.txt")
            .Split("\n\r")
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Split(' ').Select(int.Parse))
            .Select(num => num.ToList())
            .Count(arr =>
            {
                var result = Check(arr);
                if (result)
                {
                    return true;
                }

                for (int i = 0; i < arr.Count; i++)
                {
                    var something = arr.RemoveItemAtIndex(i);
                    var dampener = Check(something);
                    if (dampener)
                    {
                        return true;
                    }
                }

                return false;
            });
    }

    private static bool Check(List<int> arr)
    {
        var isAscending = true;
        var isDescending = true;
        var isDiffInRange = true;
        for (var i = 0; i < arr.Count - 1; i++)
        {
            var diff = arr[i] - arr[i + 1];
            if (diff > 0)
            {
                isDescending = false;
            }

            if (diff < 0)
            {
                isAscending = false;
            }

            if (!(Math.Abs(arr[i] - arr[i + 1]) is >= 1 and < 4))
            {
                isDiffInRange = false;
                break;
            }
        }

        return isDiffInRange && (isAscending || isDescending);
    }

    private static string GetContentFromFile(string filename)
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

    private static List<int> RemoveItemAtIndex(this List<int> arr, int index)
    {
        var copy = new List<int>(arr);
        copy.RemoveAt(index);
        return copy;
    }
}