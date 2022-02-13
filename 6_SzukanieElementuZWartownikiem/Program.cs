int[] tablicaLiczb = new[] { 3, 54, 56, 44, 12, 8, 87, 34, 56, 72, 36, 90, 19, 4 };
Console.Write("Wprowadz poszukiwaną liczbę: ");
string? input = Console.ReadLine();
bool check = int.TryParse(input, out int output);
if (!check)
{
    Console.WriteLine("Wprowadzono nieprawidłową wartość.");
    return;
}