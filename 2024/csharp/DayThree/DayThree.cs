using static DayOne.DayOne.DayOne;

namespace DayOne.DayThree;

public static class DayThree
{
    public static double Test()
    {
        var result = 0d;
        var a = GetContentFromFile("./DayThree/DayThree.txt");
        for (var i = 0; i < a.Length - 8; i++)
        {
            if (a[i] != 'm') continue;
            if (a[i + 1] == 'u' && a[i + 2] == 'l' && a[i + 3] == '(')
            {
                var subs = a.Substring(i + 4);
                for (int j = 0; j < subs.Length; j++)
                {
                    var containsComma = subs.Substring(0, j).Contains(',');
                    var hasOnlyNumbers = subs.Substring(0, j).Split(",").Select(s => int.TryParse(s, out _)).All(b => b);
                    if (subs[j] == ')' && j <= 7 && hasOnlyNumbers && containsComma)
                    {
                        var asd = subs.Substring(0, j).Split(',').Select(int.Parse).ToArray();
                        result += asd[0] * asd[1];
                        break;
                    }
                }
            }
        }

        return result;
    }
}