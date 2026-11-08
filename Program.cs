Console.OutputEncoding = System.Text.Encoding.UTF8;

int[] array = new int[10];
Random rand = new Random();

for (int i = 0; i < array.Length; i++)
{
    array[i] = rand.Next(1, 25);
}

Console.WriteLine($"Згенерований масив: [ {string.Join(", ", array)} ]");
Console.WriteLine(new string('-', 50));

int sum = 0;
long product = 1;

Thread t0 = new Thread(() =>
{
    int localSum = 0;
    foreach (int num in array)
    {
        localSum += num;
    }
    sum = localSum;
    Console.WriteLine($"[Потік T0] Сума всіх елементів: {sum}");
});

Thread t1 = new Thread(() =>
{
    long localProduct = 1;
    foreach (int num in array)
    {
        localProduct *= num;
    }
    product = localProduct;
    Console.WriteLine($"[Потік T1] Добуток всіх елементів: {product}");
});

t0.Start();
t1.Start();

t0.Join();
t1.Join();

Console.WriteLine(new string('-', 50));
Console.WriteLine("Роботу потоків завершено успішно.");