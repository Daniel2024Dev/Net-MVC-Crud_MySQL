using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Loja.Models;

namespace Loja.Controllers;

public class ViewsProjetoController : Controller
{
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Property a)
    {
        Repository ar = new Repository();

        ar.Inserir(a);
        return RedirectToAction("Read");
    }

    public IActionResult Read()
    {
        Repository ar = new Repository();
        return View(ar.Listar());
    }

    public IActionResult Update(int Id)
    {
        Repository ar = new Repository();
        return View(ar.BuscaPorId(Id));
    }
    [HttpPost]
    public IActionResult Update(Property a)
    {
        Repository ar = new Repository();
        ar.Editar(a);
        return RedirectToAction("Read");
    }

    public IActionResult Delete(int Id)//Usando O "/Alunos/Excluir?Id=@a.IdAlunos" DE Listar EM Views
    {
        Repository ar = new Repository();
        ar.Deletar(Id);
        return RedirectToAction("Read");//APÓS A FUNÇÃO SER EXECUTADA SERA REDIRECIONADA PARA Listar EM Views
    }
}