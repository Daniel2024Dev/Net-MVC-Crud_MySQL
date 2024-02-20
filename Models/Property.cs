using System;

namespace Loja.Models;

public class Property
{
    public int IdProperty {get;set;}
    public string? Nome {get;set;}
    public string? Email {get;set;}
    public string? Rua {get;set;}
    public int Numero {get;set;}
    public string? Bairro {get;set;}
    public string? Cidade {get;set;}
    public int Cep {get;set;}
    public string? Estado {get;set;}
    public string? Pais {get;set;}
    public string? Pedido {get;set;}
    public double Entrada {get;set;}
    public double Total {get;set;}
    public double Restante {get;set;}
    public DateTime Data  {get;set;}
    public string? Registros {get;set;}
}