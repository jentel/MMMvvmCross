using System;
namespace Collections.Core.Interfaces
{
    public interface IFragmentTypeLookup
    {
        bool TryGetFragmentType(Type viewModelType, out Type FragmentType);
    }
}
