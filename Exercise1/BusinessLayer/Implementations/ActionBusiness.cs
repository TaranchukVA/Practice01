using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomMethodResult;

namespace Exercise1
{
    public class ActionBusiness : IActionBusiness<List<Storage>>
    {
        private readonly DbContextOptions<SortDb> options;
        private readonly IMyLogger myLogger;

        public ActionBusiness(DbContextOptions<SortDb> options)
        {
            this.options = options;
            myLogger = new MyLogger(options);
        }
        public async Task<IMethodResult<List<Storage>>> PostAsync(List<Dictionary<string, string>> rawData)
        {
            try
            {
                var data = Read(rawData);

                List<Storage> result = Operation(data);

                await SaveAsync(result, options);

                string text = JsonConvert.SerializeObject(result);
                myLogger.Info($"Inserted: \t{text}");
                return new MethodResult<List<Storage>>(true);
            }
            catch (Exception exception)
            {
                myLogger.Error(exception.Message);
                return new MethodResult<List<Storage>>(exception.Message);
            }

        }

        public IMethodResult<List<Storage>> Get(string method, int count)
        {
            try
            {
                List<Storage> data = new();
                using SortDb context = new(options);
                {
                    data = method switch
                    {
                        "take" => context.Storage.Take(count).ToList(),
                        "skip" => context.Storage.Skip(count).ToList(),
                        _ => context.Storage.ToList()
                    };
                }


                string text = JsonConvert.SerializeObject(data);
                myLogger.Info($"Selected:\t{text}");
                return new MethodResult<List<Storage>>(data, success: true);
            }
            catch (Exception exception)
            {
                myLogger.Error(exception.Message);
                return new MethodResult<List<Storage>>(exception.Message);
            }
        }

        private static List<IElement> Read(List<Dictionary<string, string>> data)
        {
            List<IElement> elements = new();

            foreach (var dict in data)
                foreach (var elem in dict)
                    elements.Add(new Element()
                    {
                        code = Convert.ToInt32(elem.Key),
                        value = elem.Value
                    });

            return elements;
        }

        private static List<Storage> Operation(List<IElement> data)
        {
            int order = 0;
            return data.OrderBy(item => item.code)
                .Select((item) => new Storage() { Order = ++order, Code = item.code, Value = item.value })
                .ToList();
        }

        private static async Task SaveAsync(List<Storage> data, DbContextOptions<SortDb> options)
        {
            using SortDb context = new(options);
            context.Storage.RemoveRange(context.Storage.ToList());
            await context.Storage.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }
    }
}
