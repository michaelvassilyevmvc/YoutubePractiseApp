using TestConsoleApp;

using (var dbContext = new AppDbContext())
{
    try
    {
        Console.WriteLine("Проверяем подключение к базе данных...");
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Успешное подключение к базе данных!");
        }
        else
        {
            Console.WriteLine("Не удалось подключиться к базе данных.");
            dbContext.Database.EnsureCreated();
            dbContext.Products.Add(new Product { Name = "Sample Product" });
            dbContext.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка подключения: {ex.Message}");
    }
}