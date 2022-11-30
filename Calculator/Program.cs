// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
while (true)
{
    Console.WriteLine();
    Console.Write("Enter first number:");
    var n1Text = Console.ReadLine();

    if (!decimal.TryParse(n1Text, out var n1))
    {
        Console.WriteLine($"{n1Text} is not a number");
        continue;
    }

    Console.Write("Enter second number:");
    var n2Text = Console.ReadLine();

    if (!decimal.TryParse(n2Text, out var n2))
    {
        Console.WriteLine($"{n2Text} is not a number");
        continue;
    }

    Console.Write("Enter Math operation (+ - * /:");
    var mathOperation = Console.ReadLine();

    if (mathOperation == "+")
    {
        Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
        continue;
    }

    if (mathOperation == "-")
    {
        Console.WriteLine($"{n1} - {n2} = {n1 - n2}");
        continue;
    }

    if (mathOperation == "*")
    {
        Console.WriteLine($"{n1} * {n2} = {n1 * n2}");
        continue;
    }

    if (mathOperation == "/")
    {
        if (n2 == 0)
        {
            Console.WriteLine("Cannot divide by zero");
            continue;
        }

        Console.WriteLine($"{n1} / {n2} = {n1 / n2}");
    }
}
