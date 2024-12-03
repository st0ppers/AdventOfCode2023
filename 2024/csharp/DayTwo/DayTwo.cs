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
        var a = arr.CheckIfAscending();
        var b = arr.CheckIfDescending();
        if (!(a || b))
        {
            return false;
        }

        var c = arr.CheckForDifference();
        return (a || b) && c;
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

    private static bool CheckIfAscending(this List<int> arr)
    {
        var isAscending = false;
        for (var i = 0; i < arr.Count - 1; i++)
        {
            isAscending = arr[i] > arr[i + 1];
            if (!isAscending)
            {
                return isAscending;
            }
        }

        return isAscending;
    }

    private static bool CheckIfDescending(this List<int> arr)
    {
        var isDescending = true;
        for (var i = 0; i < arr.Count - 1; i++)
        {
            isDescending = arr[i] < arr[i + 1];
            if (!isDescending)
            {
                return isDescending;
            }
        }

        return isDescending;
    }

    private static bool CheckForDifference(this List<int> arr)
    {
        var moreThanTwoDifference = false;
        for (var i = 0; i < arr.Count - 1; i++)
        {
            var d = Math.Abs(arr[i] - arr[i + 1]);
            moreThanTwoDifference = !(Math.Abs(arr[i] - arr[i + 1]) is >= 1 and < 4);

            if (moreThanTwoDifference)
            {
                return !moreThanTwoDifference;
            }
        }

        return !moreThanTwoDifference;
    }

    private static List<int> RemoveItemAtIndex(this List<int> arr, int index)
    {
        var copy = new List<int>(arr);
        copy.RemoveAt(index);
        return copy;
    }
}