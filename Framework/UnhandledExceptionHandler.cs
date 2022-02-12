using System;

namespace Com.ZimVie.Wcs.Framework
{
    public interface UnhandledExceptionHandler
    {

        void HandleException(object sender, UnhandledExceptionEventArgs e);
    }
}
