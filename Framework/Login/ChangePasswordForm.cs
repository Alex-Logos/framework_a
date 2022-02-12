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
    public partial class ChangePasswordForm
    {

        #region Variables

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(ChangePasswordForm));

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize  MessageData
        /// </summary>
        private MessageData messageData;
        
        /// <summary>
        /// intialize EncryptDecrypt
        /// </summary>
        private EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (Password_txt.Text == string.Empty)
            {
                messageData = new MessageData("llce00010", Properties.Resources.llce00010.ToString());
                Logger.Info(messageData);
                popUpMessage.Warning(messageData, this.Text);

                Password_txt.Focus();

                return false;
            }
            if (NewPwd_txt.Text == string.Empty)
            {
                messageData = new MessageData("llce00010", Properties.Resources.llce00010.ToString());
                Logger.Info(messageData);
                popUpMessage.Warning(messageData, this.Text);

                NewPwd_txt.Focus();

                return false;
            }
            if (ConfPwd_txt.Text == string.Empty)
            {
                messageData = new MessageData("llce00011", Properties.Resources.llce00011.ToString());
                Logger.Info(messageData);
                popUpMessage.Warning(messageData, this.Text);

                ConfPwd_txt.Focus();

                return false;
            }

            if (NewPwd_txt.Text.Trim() != ConfPwd_txt.Text.Trim())
            {
                messageData = new MessageData("llce00009", Properties.Resources.llce00009.ToString());
                Logger.Info(messageData);
                popUpMessage.Warning(messageData, this.Text);

                ConfPwd_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// ok button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (CheckMandatory())
            {
                try
                {
                    //ChangePasswordVo inVo = new ChangePasswordVo
                    //{
                    //    UserCode = UserData.GetUserData().UserCode,
                    //    Password = encryptDecrypt.Encrypt(Password_txt.Text)
                    //};

                    //ChangePasswordVo outcheckVo = (ChangePasswordVo)DefaultCbmInvoker.Invoke(new CheckPasswordCbm(), inVo);

                    //if (outcheckVo.AffectedCount == 0)
                    //{
                    //    messageData = new MessageData("llce00013", Properties.Resources.llce00013, null);
                    //    Logger.Info(messageData);
                    //    popUpMessage.Warning(messageData, Text);
                    //    return;
                    //}

                    //if (Password_txt.Text == NewPwd_txt.Text)
                    //{
                    //    messageData = new MessageData("llce00012", Properties.Resources.llce00012, null);
                    //    Logger.Info(messageData);
                    //    popUpMessage.Warning(messageData, Text);
                    //    return;
                    //}

                    //inVo.Password = encryptDecrypt.Encrypt(NewPwd_txt.Text);
                    //ChangePasswordVo outVo = (ChangePasswordVo) DefaultCbmInvoker.Invoke(new ChangePasswordCbm(), inVo);

                    //if (outVo.AffectedCount > 0)
                    //{
                    //    messageData = new MessageData("llci00001", Properties.Resources.llci00001, null);
                    //    Logger.Info(messageData);
                    //    popUpMessage.Information(messageData, Text);
                    //    this.Close();

                    //    FormCollection forms = Application.OpenForms;

                    //    for (int formCount = forms.Count - 1; formCount >= 0; formCount--)
                    //    {
                    //        if (forms[formCount].GetType().BaseType != typeof(FormCommonBase))
                    //            forms[formCount].Close();
                    //    }
                    //}

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    Logger.Error(exception.GetMessageData());
                    return;
                }
            }
        }

        /// <summary>
        /// login form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            Password_txt.Select();
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

        private void Password_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            NewPwd_txt.Select();
        }

        private void ConfPwd_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Ok_btn.Select();
        }

        private void NewPwd_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            ConfPwd_txt.Select();
        }
    }
}
