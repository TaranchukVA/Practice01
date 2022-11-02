using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1
{
    public interface IActionBusiness
    {
        public Task<IMethodResult> PostAsync(List<Dictionary<string, string>> rawData);
        public IMethodResult Get(string method, int count);
    }
}
