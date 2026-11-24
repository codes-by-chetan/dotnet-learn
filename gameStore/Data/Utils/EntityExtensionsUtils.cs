using Microsoft.EntityFrameworkCore;

namespace gameStore.Data.Utils;

public static class EntityExtentions
{
    public static void PatchFrom<TEntity, TDto>(this TEntity entity, TDto dto, DbContext db, params string[] excludedProperties)
    where TEntity : class
    {
        var entry = db.Entry(entity);
        var exclusions = new HashSet<string>(excludedProperties, StringComparer.OrdinalIgnoreCase);
        foreach (var prop in typeof(TDto).GetProperties())
        {
            if (exclusions.Contains(prop.Name))
                continue;

            if (entry.Metadata.FindProperty(prop.Name) is null)
                continue;
 
            var value = prop.GetValue(dto);
            if (value != null)
            {
                entry.Property(prop.Name).CurrentValue = value;
            }
        }

    }
}