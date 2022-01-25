using System;
using Microsoft.Extensions.Options;

namespace Core.Utilities.Helpers.Abstract.WritableOptionsHelper
{
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        void Update(Action<T> applyChanges);
    }
}
