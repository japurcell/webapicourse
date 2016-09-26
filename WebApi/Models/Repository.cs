using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public struct RepositoryMethods<T>
    {
        public RepositoryMethods(Func<Task<IEnumerable<T>>> all, Func<int, Task<T>> find, Func<T, Task<T>> create)
        {
            All = all;
            Find = find;
            Create = create;
        }

        public readonly Func<Task<IEnumerable<T>>> All;
        public readonly Func<int, Task<T>> Find;
        public readonly Func<T, Task<T>> Create;
    }

    public static class Repository
    {
        public static async Task<IEnumerable<T>> AllAsync<T>() where T : class
        {
            using(var context = new SampleContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public static async Task<T> FindAsync<T>(int id) where T : class
        {
            using(var context = new SampleContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public static async Task<T> CreateAsync<T>(T item) where T : class
        {
            using(var context = new SampleContext())
            {
                var added = context.Set<T>().Add(item);
                await context.SaveChangesAsync();
                return added;
            }
        }
    }
}