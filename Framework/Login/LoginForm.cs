/*
 * Copyright 2020 by Nidec Corporation, All rights reserved.
 *
 *  Change Tracking
 *  2020/6/2 <Change NO.0001> LoginForm updated: IsAuthentificated method added with password encryption by Takusuke Fujii (Nidec)
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework.Login
{
    public partial class LoginForm
    {

        #region Variables

        /// <summary>
        /// initialize LoginCbm
        /// </summary>
        private readonly LoginCbm loginCbm = new LoginCbm();


        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(LoginForm));

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// application name that is given from caller application for displaying itself with version on login screen
        /// </summary>
        private string applicationName;

        /// <summary>
        /// get applicationAssemblyName from constructor
        /// </summary>
        private string applicationAssemblyName;

        /// <summary>
        /// get applicationTypeName from constructor
        /// </summary>
        private string applicationTypeName;

        /// <summary>
        /// get isPwdCheckNeeded from constructor
        /// </summary>
        private readonly bool isPwdCheckNeeded;

        #endregion


        /// <summary>
        /// constructor
        /// </summary>
        public LoginForm(string assemblyname, string typename, string appricationname, bool passwordCheckNeeded = true)
        {

            applicationName = appricationname;

            applicationAssemblyName = assemblyname;

            applicationTypeName = typename;

            isPwdCheckNeeded = passwordCheckNeeded;

            InitializeComponent();

        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (LoginName_txt.Text == string.Empty)
            {
                MessageData messageData = new MessageData("llce00002", Properties.Resources.llce00002.ToString());
                Logger.Info(messageData);
                popUpMessage.ApplicationError(messageData, this.Text);

                LoginName_txt.Focus();

                return false;
            }
            if (Password_txt.Text == string.Empty)
            {
                MessageData messageData = new MessageData("llce00003", Properties.Resources.llce00003.ToString());
                Logger.Info(messageData);
                popUpMessage.ApplicationError(messageData, this.Text);

                Password_txt.Focus();

                return false;
            }
            return true;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                if (this.ActiveControl == LoginName_txt)
                {
                    Password_txt.Focus();
                    return true;
                }
                else if (this.ActiveControl == Password_txt)
                {
                    Login_btn.PerformClick();
                    return true;
                }

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// login button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_btn_Click(object sender, EventArgs e)
        {
            MessageData messageData = new MessageData("llce00001", Properties.Resources.llce00001.ToString(), new string[] { "Login Click. Start : " + DateTime.Now.ToString() });
            Logger.Info(messageData);

            if (!CheckMandatory())
            {
                return;
            }

            try
            {
                //if (!IsAuthentificated()) { return; }

                //get the instance of form to be open after logged in
                FormCommon frmMenu = GetMenuInstance();
                if (frmMenu == null) return;

                this.Hide();
                frmMenu.ShowDialog(frmMenu);
                this.Show();
                Password_txt.Text = string.Empty;
            }
            catch (ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                return;
            }
            catch (SystemException exception)
            {
                popUpMessage.SystemError(exception.GetMessageData(), Text);
                this.Close();
            }
            finally
            {
                MessageData messageDataEnd = new MessageData("llce00001", Properties.Resources.llce00001.ToString(), new string[] { "Login Click. End : " + DateTime.Now.ToString() });
                Logger.Info(messageDataEnd);
            }

        }

        /// <summary>
        /// check for the user authentificate
        /// </summary>
        /// <returns></returns>
        private bool IsAuthentificated()
        {
            if (!isPwdCheckNeeded)
            {
                return true;
            }

            //
            string loginUserName = LoginName_txt?.Text;
            if (string.IsNullOrWhiteSpace(loginUserName?.Trim()))
            {
                MessageData messageData = new MessageData("llci00009", Properties.Resources.llci00009);
                Logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return false;
            }

            string inputPassword = Password_txt?.Text;

            if (string.IsNullOrWhiteSpace(inputPassword?.Trim()))
            {
                MessageData messageData = new MessageData("llci00010", Properties.Resources.llci00010);
                Logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return false;
            }

            string authentificateFlag = ConfigurationDataTypeEnum.AUTHENTIFICATE_FLAG.GetValue();

            AuthentificateStrategyDataTypeEnum authentificateTypeEnum =
                          AuthentificateStrategyDataTypeEnum.GetAuthentificateStrategyDataTypeEnum(authentificateFlag);

            if (authentificateTypeEnum == null)
            {
                MessageData messageData = new MessageData("llce00008", Properties.Resources.llce00008, authentificateFlag);
                Logger.Error(messageData);
                popUpMessage.ApplicationError(messageData, Text);
                return false;
            }

            UserAuthentificateStrategy userAuthentificateStrategy = authentificateTypeEnum.CreateAuthentificateStrategy();

            EncryptDecrypt encryptDecrypt = new EncryptDecrypt(); // PC longin form side encryption added to match with PDA login form by Fujii on 2020/6/2
            string encryptedPassword = encryptDecrypt.Encrypt(inputPassword);

            if (!userAuthentificateStrategy.Authentificate(loginUserName, encryptedPassword))
            {
                MessageData messageData = new MessageData("llci00011", Properties.Resources.llci00011);
                Logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                LoginName_txt.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Bind UserData by loggedin user
        /// </summary>
        /// <returns></returns>
        private UserData BindLoggedInUserData()
        {
            LoginInVo inVo = new LoginInVo
            {
                //InputUserId = LoginName_txt.Text,
                //InputPassword = Password_txt.Text
            };

            //LoginOutVo outVo = null;
            try
            {
                //outVo = (LoginOutVo)DefaultCbmInvoker.Invoke(loginCbm, inVo);
            }
            catch (ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                return null;
            }

            //if (outVo == null)
            //{
            //    //MessageData messageData = new MessageData("llce00005", Properties.Resources.llce00005, inVo.InputUserId);
            //    //Logger.Info(messageData);
            //    //popUpMessage.Information(messageData, this.Text);
            //    return null;
            //}

            //Get empty userdata
            UserData userData = UserData.GetUserData();

            //userData.UserCode = outVo.UserId;
            //userData.UserName = outVo.UserName;
            //userData.LocaleId = outVo.LocaleId;
            //userData.LanguageCode = outVo.LanguageCode;
            //userData.Country = outVo.CountryCode;
            //userData.FactoryCodeList = outVo.FactoryCodeList;
            //userData.ControlList = outVo.ControlList;
            //userData.IpAddress = LocalIpAddress();

            userData.UserCode = "fuji";
            userData.UserName = "Takusuke Fujii";
            userData.LocaleId = 0;
            userData.LanguageCode = "ja";
            userData.Country = "JP";
            userData.FactoryCodeList = new System.Collections.Generic.List<string> { "TOKYO" };
            userData.ControlList = null; // outVo.ControlList;
            userData.IpAddress = LocalIpAddress();

            string currentCulture = userData.LanguageCode + "-" + userData.Country; //outVo.LanguageCode + "-" + outVo.CountryCode;

            CultureInfo newCulture = CultureInfo.CreateSpecificCulture(currentCulture);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            userData.DateTimeFormat = newCulture.DateTimeFormat;
            userData.NumberFormat = newCulture.NumberFormat;

            //sessionid for each loggedin user
            userData.SessionId = userData.UserCode + System.Guid.NewGuid().ToString();

            return userData;
        }

        /// <summary>
        /// instance of the form to be load after login
        /// </summary>
        /// <returns></returns>
        private FormCommon GetMenuInstance()
        {
            //Get empty userdatas
            UserData userData = BindLoggedInUserData();
            if (userData == null) return null;

            FormCommon menuform = null;
            if (UserData.GetUserData().FactoryCodeList.Count == 1)
            {
                userData.FactoryCode = UserData.GetUserData().FactoryCodeList[0].ToString();

                Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + applicationAssemblyName); // dll name
                Type type = assembly.GetType(applicationTypeName);  //form name

                if (type != null)
                {
                    menuform = Activator.CreateInstance(type) as FormCommon;

                    return menuform;
                }
                else
                {
                    MessageData messageData = new MessageData("llce00006", Properties.Resources.llce00006.ToString());
                    popUpMessage.ApplicationError(messageData, Text);
                    Logger.Info(messageData);

                    return null;
                }
            }
            else
            {
                menuform = new FactorySelectionForm(applicationAssemblyName, applicationTypeName);

                return menuform;
            }
        }
        /// <summary>
        /// Finds IP address of local machine
        /// </summary>
        /// <returns>local machine IP address</returns>
        private string LocalIpAddress()
        {
            string localIp = "";

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                localIp = ip.ToString();

                string[] temp = localIp.Split('.');

                if (ip.AddressFamily == AddressFamily.InterNetwork && temp[0] == "192")
                {
                    break;
                }
                localIp = null;
            }

            return localIp;
        }

        /// <summary>
        /// login form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {

                Version deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;

                StringBuilder version = new StringBuilder();
                version.Append("VERSION : ");
                version.Append(applicationName + "_");
                version.Append(deploy.Major);
                version.Append("_");
                version.Append(deploy.Minor);
                version.Append("_");
                version.Append(deploy.Build);
                version.Append("_");
                version.Append(deploy.Revision);

                Version_lbl.Text = version.ToString();
            }


            LoginName_txt.Select();
        }

        /// <summary>
        /// cancel button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginName_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Password_txt.Select();
        }
    }
}
