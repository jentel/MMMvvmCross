using System;
using System.Collections.Generic;
using System.Linq;
using Collections.Core.Interfaces;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platform.IoC;

namespace Collections.Droid.Services
{
    public class FragmentTypeLookup : IFragmentTypeLookup
    {
		private readonly IDictionary<string, Type> _fragmentLookup = new Dictionary<string, Type>();
		
        public FragmentTypeLookup()
        {
			_fragmentLookup =
				(from type in GetType().Assembly.ExceptionSafeGetTypes()
				 where !type.IsAbstract
					&& !type.IsInterface
					&& typeof(MvxFragment).IsAssignableFrom(type)
					&& type.Name.EndsWith("View")
				 select type).ToDictionary(getStrippedName);
        }

        public bool TryGetFragmentType(Type viewModelType, out Type FragmentType)
        {
			var strippedName = getStrippedName(viewModelType);

			if (!_fragmentLookup.ContainsKey(strippedName))
			{
				FragmentType = null;

				return false;
			}

			FragmentType = _fragmentLookup[strippedName];

			return true;
        }

		private string getStrippedName(Type type)
		{
			return type.Name
					   .TrimEnd("View".ToCharArray())
					   .TrimEnd("ViewModel".ToCharArray());
		}
    }
}
