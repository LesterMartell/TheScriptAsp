using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheScript_.Models;

namespace TheScript_.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Logger> Log {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    #region Работа с областью
    
    // Создание ветви
    public void CreateBranch(string title)
    {
        Branches.Add(new Branch(title));

        SaveChanges();
    }

    // Удаление области
    public void RemoveBranch(int id)
    {
        Branches.Remove(Branches.Find(id));

        var sections_remove = Sections.Where(o => o.Id_branch == id).ToList();

        foreach (Section v in sections_remove)
        {
            RemoveSection(v.Id);
        }

        SaveChanges();
    }

    // Создание области
    public void EditBranch_Title(int id, string newTitle)
    {
        Branches.Find(id).Title = newTitle;

        SaveChanges();
    }

    #endregion

    #region Работа с разделом

    // Создание раздела
    public void CreateSection(int owner_branch, string title)
    {
        if (Branches.Find(owner_branch) != null)
        {
            Sections.Add(new Section(title, owner_branch));

            SaveChanges();
        }
        else
        {
            Console.WriteLine("Не удалось создать раздел!");
        }
    }
    
    public void RemoveSection(int id)
    {
        Sections.Remove(Sections.Find(id));
        
        var chapters_remove = Chapters.Where(o => o.Id_section == id).ToList();

        foreach (Chapter v in chapters_remove)
        {
            RemoveChapter(v.Id);
        }

        SaveChanges();
    }

    public void EditSection_Title(int id, string title)
    {
        Sections.Find(id).Title = title;

        SaveChanges();
    }


    #endregion

    #region Работа с главами

    // Создание главы
    public void CreateChapter(string title, int owner_section, int owner_branch, string htmlText)
    {

        if (Branches.Find(owner_branch) != null && Sections.Find(owner_section) != null)
        {
            Chapters.Add(new Chapter(title, owner_section, owner_branch, htmlText));
            SaveChanges();
        }
        else
        {
            Console.WriteLine("Не удалось создать главу!");
        }

    }

    public void CreateChapter_andID(string title, int owner_section, int owner_branch, int id)
    {

        if (Branches.Find(owner_branch) != null && Sections.Find(owner_section) != null)
        {
            Chapters.Add(new Chapter(title, owner_section, owner_branch)
            {
                Id = id
            });
            SaveChanges();
        }
        else
        {
            Console.WriteLine("Ошибка, не найдена секция или раздел!");
        }

    }

    public void RemoveChapter(int id)
    {
        Chapters.Remove(Chapters.Find(id));

        SaveChanges();
    }

    #endregion

    #region Logger

    public void CreateLog(string log)
    {
        Log.Add(new Logger(log));

        SaveChanges();
    }

    public void RemoveLog(int id)
    {
        Log.Remove(Log.Find(id));

        SaveChanges();
    }

    #endregion
}
