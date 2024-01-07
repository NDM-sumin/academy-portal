using entityframework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace entityframework.Extensions
{
    public static class IQueryableExtensions
    {
        public static void ApplyIncludeAll(this ModelBuilder modelBuilder)
        {
            var imodel = modelBuilder.Model;
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Select(e => e.ClrType);
            foreach (var entity in entities)
            {
                IEnumerable<string> navigationPropertyPaths = imodel.GetIncludePaths(entity);
                foreach (var navigation in navigationPropertyPaths)
                {
                    modelBuilder.Entity(entity).Navigation(navigation).AutoInclude();
                }
            }
        }
        public static IQueryable<T> Include<T>(this IQueryable<T> source, IEnumerable<string> navigationPropertyPaths)
            where T : class
        {
            return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
        }
        public static IQueryable<T> IncludeAll<T>(this DbSet<T> source)
            where T : class
        {
            var navigationPaths = source.EntityType.GetIncludePaths();
            return source.Include(navigationPaths);
        }
        public static IEnumerable<string> GetIncludePaths(this IEntityType entityType, int maxDepth = int.MaxValue)
        {
            if (maxDepth < 0) throw new ArgumentOutOfRangeException(nameof(maxDepth));
            var includedNavigations = new HashSet<INavigation>();
            var stack = new Stack<IEnumerator<INavigation>>();
            while (true)
            {
                var entityNavigations = new List<INavigation>();
                if (stack.Count <= maxDepth)
                {
                    foreach (var navigation in entityType.GetNavigations())
                    {
                        if (includedNavigations.Add(navigation))
                            entityNavigations.Add(navigation);
                    }
                }
                if (entityNavigations.Count == 0)
                {
                    if (stack.Count > 0)
                        yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
                }
                else
                {
                    foreach (var navigation in entityNavigations)
                    {
                        var inverseNavigation = navigation.FindInverse();
                        if (inverseNavigation != null)
                            includedNavigations.Add(inverseNavigation);
                    }
                    stack.Push(entityNavigations.GetEnumerator());
                }
                while (stack.Count > 0 && !stack.Peek().MoveNext())
                    stack.Pop();
                if (stack.Count == 0) break;
                entityType = stack.Peek().Current.GetTargetType();
            }

        }
        public static IEnumerable<string> GetIncludePaths(this IMutableModel model, Type clrEntityType, int maxDepth = int.MaxValue)
        {
            if (maxDepth < 0) throw new ArgumentOutOfRangeException(nameof(maxDepth));
            var entityType = model.FindEntityType(clrEntityType);
            return entityType.GetNavigations().Select(e => e.Name);
        }
    }
}
