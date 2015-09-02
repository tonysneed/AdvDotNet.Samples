using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiQuickstart.Models
{
    public class ValuesRepository
    {
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(4);

        private static readonly List<string> Values = new List<string>
            {
                "value1", "value2", "value3", "value4", "value5"
            };

        public async Task<IEnumerable<string>> GetValuesAsync()
        {
            await Task.Delay(_delay);
            return Values.ToArray();
        }

        public async Task<string> GetValueAsync(int id)
        {
            await Task.Delay(_delay);
            if (id < 1 || id > Values.Count) return null;
            return Values[id - 1];
        }

        public async Task<string> GetValueAsync(string name)
        {
            await Task.Delay(_delay);
            var value = Values.SingleOrDefault(e => e == name);
            return value;
        }

        public async Task<string> AddValueAsync(string value)
        {
            await Task.Delay(_delay);
            Values.Add(value);
            return value;
        }

        public async Task UpdateAsync(int id, string value)
        {
            await Task.Delay(_delay);
            if (id < 1 || id > Values.Count)
                throw new InvalidOperationException();
            Values[id - 1] = value;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(_delay);
            if (id < 1 || id > Values.Count)
                throw new InvalidOperationException();
            Values.RemoveAt(id - 1);
        }
    }
}