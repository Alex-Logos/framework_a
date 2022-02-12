using System;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public class DefaultApplicationContext : ApplicationContext
    {

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="assemblyname"></param>
        /// <param name="typename"></param>
        /// <param name="appricationname"></param>
        /// <param name="passwordCheckNeeded"></param>
        public DefaultApplicationContext(string assemblyname, string typename, 
                                            string appricationname, bool passwordCheckNeeded = true)
        {

            //initialize the DefaultApplicationInitializer
            DefaultApplicationInitializer.GetInstance().Init();

            //login form show
            Login.LoginForm login = new Login.LoginForm(assemblyname, typename, appricationname, passwordCheckNeeded);
            login.Closed += new EventHandler(OnFormClosed);
            login.Show();

        }

        /// <summary>
        /// exit application on form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClosed(object sender, EventArgs e)
        {
            ExitThread();
        }
    }
}
