using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Exercise1
{ 
    public class MyLogger : IMyLogger
    {
        private readonly DbContextOptions<SortDb> options;

        public MyLogger(DbContextOptions<SortDb> options)
        {
            this.options = options;
        }

        public async void Error(string text) => await SaveAsync(text, LogLevel.Error);

        public async void Info(string text) => await SaveAsync(text, LogLevel.Info);

        private async Task SaveAsync(string text, LogLevel level)
        {
            using SortDb context = new(options);
            Log newLine = new Log()
            {
                Time = DateTime.Now,
                Level = (int)level,
                Text = text
            };
            context.Log.Add(newLine);
            await context.SaveChangesAsync();
        }
    }
}
