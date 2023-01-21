using System;
using System.Collections.Generic;
using TheScript_.Models;

namespace TheScript_.Data
{
    public static class InitLayout
    {
        public static List<Branch> Branches {get; set;}
        public static List<Section> Sections {get; set;}
        public static List<Chapter> Chapters {get; set;}
        public static List<Logger> Log {get; set;}

        public static void InitializeLayout(ApplicationDbContext dbContext)
        {
            Branches = dbContext.Branches.ToList();
            Sections = dbContext.Sections.ToList();
            Chapters = dbContext.Chapters.ToList();
            Log = dbContext.Log.ToList();
        }

        public static List<Section> specificSection(int id_branch)
        {
            var spS = Sections.Where(o => o.Id_branch == id_branch).ToList();
            return null;
        }
    }
}