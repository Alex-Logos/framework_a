using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
namespace Com.ZimVie.Wcs.Framework
{
    public partial class FormCommonBase : Form
    {

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(FormCommon));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize progress form
        /// </summary>
        private WaitProgressForm progressForm;

        /// <summary>
        /// constructor
        /// </summary>
        public FormCommonBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="displaystatus"></param>
        public void StartProgress(string displaystatus)
        {
            //this.Enabled = false;
            progressForm = new WaitProgressForm(displaystatus);
            Point p = new Point(this.Location.X + this.Width / 2 - progressForm.Width / 2,
                                this.Location.Y + this.Height / 2 - progressForm.Height / 2);
            progressForm.Location = p;
            ShowProgress();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CompleteProgress()
        {
            Thread.Sleep(100);
            if (progressForm.IsHandleCreated)
            {
                progressForm.Invoke(new Action(progressForm.Close));
            }
            this.Activate();// = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowProgress()
        {
            if (this.InvokeRequired)
            {
                try
                {
                    progressForm.ShowDialog();
                }
                catch (InvalidOperationException ex)
                {
                    messageData = new MessageData("ffce00021", Properties.Resources.ffce00021);
                    logger.Info(messageData, ex);
                }
            }
            else
            {
                try
                {
                    Thread th = new Thread(ShowProgress);
                    th.IsBackground = false;
                    th.Start();
                }
                catch (ArgumentNullException ex)
                {
                    messageData = new MessageData("ffce00021", Properties.Resources.ffce00021);
                    logger.Info(messageData, ex);
                }
                catch (ThreadStateException ex)
                {
                    messageData = new MessageData("ffce00021", Properties.Resources.ffce00021);
                    logger.Info(messageData, ex);
                }
                catch (OutOfMemoryException ex)
                {
                    messageData = new MessageData("ffce00021", Properties.Resources.ffce00021);
                    logger.Info(messageData, ex);
                }
            }
        }
    }
}
