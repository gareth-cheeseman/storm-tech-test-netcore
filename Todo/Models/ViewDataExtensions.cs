using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Todo.Models
{
    public static class ViewDataExtensions
    {
        public static ViewDataDictionary IsJavascriptOn(this ViewDataDictionary collection, bool value)
        {
            collection["IsJavascriptOn"] = value;
            return collection;
        }

        public static bool IsJavascriptOn(this ViewDataDictionary collection)
        {
            return (bool) collection["IsJavascriptOn"];
        }
    }
}
