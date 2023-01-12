using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheScript_.Models;
using Microsoft.EntityFrameworkCore;
using TheScript_.Data;
using Microsoft.AspNetCore.Authorization;

namespace TheScript_.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static ApplicationDbContext dbContext { get; set; }

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext DbContext)
    {
        _logger = logger;
        dbContext = DbContext;
        InitLayout.InitializeLayout(DbContext);
    }

    // Начальная страница
    public IActionResult Index()
    {
        return View();
    }

    // Политика конфиденциальности
    public IActionResult Privacy()
    {
        return View();
    }

    // Страница - Конкретная область
    public IActionResult Branch(int id_branch)
    {
        var result = dbContext.Branches.Find(id_branch);

        return View(result);
    }

    // Страница - Конкретный раздел
    public IActionResult Section(int id_branch, int id_section)
    {
        var section = dbContext.Sections.Find(id_section);

        return View(section);
    }

    // Страница - Поиск
    public IActionResult Search(string search_string)
    {
        var searchChapters = InitLayout.Chapters.Where(o => o.HtmlText.ToLower().Contains(search_string.ToLower()) || o.Title.ToLower().Contains(search_string.ToLower())).ToList();

        return View(searchChapters);
    }

    // Страница - Ошибка
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

