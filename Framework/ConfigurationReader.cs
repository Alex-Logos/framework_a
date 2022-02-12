using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ZimVie.Wcs.Framework
{
   public interface ConfigurationReader
    {
        string GetValue(string keyName);

        IList<string> GetValueList(string keyName);
    }
}
