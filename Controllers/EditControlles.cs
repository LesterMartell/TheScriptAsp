using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheScript_.Models;
using TheScript_.Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace TheScript_.Controllers;

[Authorize]
public class EditController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static ApplicationDbContext dbContext { get; set; }

    // Конструктор
    #region [ Конструктор ]
    public EditController(ILogger<HomeController> logger, ApplicationDbContext DbContext)
    {
        _logger = logger;
        dbContext = DbContext;

        InitLayout.InitializeLayout(DbContext);
    }
    #endregion

    // Начальная страница редактирования (Области)
    #region [ Branches ]
    
    // Начальная страница
    public IActionResult Index()
    {
        return View(InitLayout.Branches);
    }

    // Создание новой области
    public RedirectResult CreateBranch()
    {
        dbContext.CreateBranch("Новая область");
        
        return Redirect("~/Edit/Index");
    }

    // Удаление существующей области
    public RedirectResult RemoveBranch(int id)
    {
        dbContext.RemoveBranch(id);
        
        return Redirect("~/Edit/Index");
    }
    #endregion
    
    // Редактирование конкретной области
    # region [ BranchEdit ]

    
    public IActionResult BranchEdit(int id_branch)
    {
        return View(dbContext.Branches.Find(id_branch));
    }

    public RedirectResult Save_BranchEdit(int id, string title)
    {
        dbContext.EditBranch_Title(id, title);

        return Redirect("~/Edit/BranchEdit?id_branch=" + id);
    }

    public RedirectResult CreateSection(int id)
    {
        dbContext.CreateSection(id, "Новый раздел");

        return Redirect("~/Edit/BranchEdit?id_branch=" + id);
    }

    #endregion

    // Редактирование Раздела
    # region [ SectionEdit ]

    public IActionResult SectionEdit(int id_section)
    {
        return View(dbContext.Sections.Find(id_section));
    }

    public RedirectResult RemoveSection(int id_section, int id_branch)
    {
        dbContext.RemoveSection(id_section);
        
        // return Redirect("~/Edit/Index");
        return Redirect("~/Edit/BranchEdit?id_branch=" + id_branch);
    }
    
    [HttpPost]
    public RedirectResult Save_SectionEdit_All(int id_section, string newTitle, List<Chapter> chapters, string newChapter = "false", int removeChapter = -1)
    {
        if (newChapter == "false") // Просто сохранить
        {
            List<Chapter> removeChapters = dbContext.Chapters.Where(o => o.Id_section == id_section).ToList();
            dbContext.Chapters.RemoveRange(removeChapters);

            int idbranch = dbContext.Sections.Find(id_section).Id_branch;
            foreach (Chapter chapter_item in chapters)
            {
                dbContext.CreateChapter(chapter_item.Title, chapter_item.Id_section, chapter_item.Id_branch, chapter_item.HtmlText);           
            }
            
            dbContext.EditSection_Title(id_section, newTitle);

            return Redirect("~/Edit/BranchEdit?id_branch=" + idbranch);
        }
        else if (newChapter == "remove") // Удаление одной из глав
        {
            chapters.Remove(chapters[removeChapter]);

            List<Chapter> removeChapters = dbContext.Chapters.Where(o => o.Id_section == id_section).ToList();
            dbContext.Chapters.RemoveRange(removeChapters);

            int idbranch = dbContext.Sections.Find(id_section).Id_branch;
            foreach (Chapter chapter_item in chapters)
            {
                dbContext.CreateChapter(chapter_item.Title, chapter_item.Id_section, chapter_item.Id_branch, chapter_item.HtmlText);           
            }
            
            dbContext.EditSection_Title(id_section, newTitle);

            return Redirect("~/Edit/SectionEdit?id_section=" + id_section);
        }
        else // Создание новой главы
        {
            List<Chapter> removeChapters = dbContext.Chapters.Where(o => o.Id_section == id_section).ToList();
            dbContext.Chapters.RemoveRange(removeChapters);

            int idbranch = dbContext.Sections.Find(id_section).Id_branch;
            foreach (Chapter chapter_item in chapters)
            {
                dbContext.CreateChapter(chapter_item.Title, chapter_item.Id_section, chapter_item.Id_branch, chapter_item.HtmlText);           
            }
            
            dbContext.EditSection_Title(id_section, newTitle);

            return Redirect("~/Edit/SectionEdit?id_section=" + id_section);
        }
    }
    #endregion

    // Ошибка
    # region [ Обработка Error ]

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    #endregion
}
