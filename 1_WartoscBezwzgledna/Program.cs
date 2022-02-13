Console.WriteLine("==================================");
Console.WriteLine("========WartoscBezwzgledna========");
Console.WriteLine("==================================");
Console.Write("Podaj liczbę: ");
string? input = Console.ReadLine();
bool check = int.TryParse(input, out int output);
if (!check)
{
    Console.WriteLine("Wprowadzona wartość nie jest liczbą");
    return;
}

int outputDef = output;
if (output < 0)
    outputDef = -output;

Console.WriteLine($"| {output} | = {outputDef}");

// http://www.algorytm.org/dla-poczatkujacych/wartosc-bezwzgledna.html