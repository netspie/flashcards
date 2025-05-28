
Console.WriteLine("Podaj rozmiar tablicy pomiędzy 10 a 20:");
var sizeStr = Console.ReadLine()?.Trim();

if (!int.TryParse(sizeStr, out var size) || size < 10 || size > 20)
{
    Console.WriteLine("Podano nieprawidłowy rozmiar tablicy.");
    return;
}

var random = new Random();

var arr = new int[size];
for (int i = 0; i < arr.Length; i++)
    arr[i] = random.Next(1, 21);

Array.Sort(arr);
Array.ForEach(arr, Console.WriteLine);
