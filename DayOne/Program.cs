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
