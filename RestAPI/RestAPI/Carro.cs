using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers;

namespace RestAPI;

public class Carro
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public double Preco { get; set; }
}