using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
{
    ApiService apiService = new ApiService();

    Console.WriteLine("Fetching clients");
    List<Client> clients = await apiService.GetClientsAsync();

    if (clients.Count == 0)
    {
        Console.WriteLine("No clients found.");
    }
    else
    {
        foreach (var client in clients)
        {
            Console.WriteLine($"ID: {client.Id}, Name: {client.Name}, Last Name {client.LastName}");
        }
    }

    Console.WriteLine("Press any key");
    Console.ReadKey();
}

}
