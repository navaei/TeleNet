using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;
namespace TeleNet.Models
{
    public static class TLContext
    {
        private static Dictionary<int, Type> Types;

        static TLContext()
        {
            Types = (from t in Assembly.GetExecutingAssembly().GetTypes()
                     where t.FullName.StartsWith("TeleNet.Models.TL") && !t.FullName.StartsWith("TeleNet.Models.TL85")
                     where t.IsSubclassOf(typeof(TLObject))
                     where t.GetCustomAttribute(typeof(TLObjectAttribute)) != null
                     select t).ToDictionary(x => ((TLObjectAttribute)x.GetCustomAttribute(typeof(TLObjectAttribute))).Constructor, x => x);

            var Types85 = (from t in Assembly.GetExecutingAssembly().GetTypes()
                           where t.FullName.StartsWith("TeleNet.Models.TL85")
                           where t.IsSubclassOf(typeof(TLObject))
                           where t.GetCustomAttribute(typeof(TLObjectAttribute)) != null
                           select t).Select(x => new { Key = ((TLObjectAttribute)x.GetCustomAttribute(typeof(TLObjectAttribute))).Constructor, Value = x }).ToList();
            foreach (var typeee in Types85)
            {
                if (!Types.ContainsKey(typeee.Key))
                    Types.Add(typeee.Key, typeee.Value);
            }

        }

        public static Type getType(int Constructor)
        {
            return Types[Constructor];
        }
    }
}
