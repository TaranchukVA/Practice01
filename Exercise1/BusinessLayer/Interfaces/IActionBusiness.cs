using CustomMethodResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1
{
    public interface IActionBusiness<T>
    {
        public Task<IMethodResult<T>> PostAsync(List<Dictionary<string, string>> rawData);
        public IMethodResult<T> Get(string method, int count);
    }
}
