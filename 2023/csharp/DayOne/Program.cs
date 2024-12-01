using AdventOfCode;

var a = new Point() { x = 13,y = 15};
var b = new Point() { x = 13, y = 15 };
decimal asd = 0.1m;
decimal sdf = 0.2m;
Console.WriteLine(a == b);
Console.WriteLine(asd + sdf);
Console.WriteLine("\b");
Console.WriteLine(String.Format("{0:0.0000000000000000000}", asd + sdf));
var asaa = new Random();

      // "123.46"

Console.WriteLine(0.1 + 0.2);


var sum = 0;
var current = new List<int>();

while (true)
{
  var input = Console.ReadLine();

  foreach (char c in input)
  {
    if (char.IsDigit(c))
    {
      current.Add(int.Parse(c.ToString()));
    }
  }

  sum = (current.First() * 10) + current.Last() + sum;
  current.Clear();

  Console.WriteLine(sum);
}
