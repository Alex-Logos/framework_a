using System;
using System.Windows.Forms;
using System.Reflection;

namespace Com.ZimVie.Wcs.Framework
{
    public partial class FactorySelectionForm
    {


        /// <summary>
        /// 
        /// </summary>
        private string applicationAssemblyName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string applicationTypeName = string.Empty;


        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(FactorySelectionForm));

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        public FactorySelectionForm(string assemblyname, string typename)
        {

            applicationAssemblyName = assemblyname;

            applicationTypeName = typename;

            InitializeComponent();
        }


        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (Factory_cmb.SelectedIndex < 0)
            {
                MessageData messageData = new MessageData("ffce00038", Properties.Resources.ffce00038.ToString());
                logger.Info(messageData);
                popUpMessage.ApplicationError(messageData, this.Text);

                Factory_cmb.Focus();
                return;
            }

            UserData userData = UserData.GetUserData();
            userData.FactoryCode = Factory_cmb.SelectedItem.ToString();

            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + applicationAssemblyName); // dll name
            Type type = assembly.GetType(applicationTypeName);  //form name with namespace

            FormCommon menuform = Activator.CreateInstance(type) as FormCommon;
            this.Hide();
            menuform.ShowDialog(menuform);
            this.Show();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FactorySelectionForm_Load(object sender, EventArgs e)
        {
            Factory_cmb.Items.Clear();
            foreach (string factory in UserData.GetUserData().FactoryCodeList)
            {
                Factory_cmb.Items.Add(factory);
            }
            Factory_cmb.SelectedIndex = 0;
            Factory_cmb.Select();
        }
    }
}
