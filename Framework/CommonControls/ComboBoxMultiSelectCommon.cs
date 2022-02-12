
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{

    /// <summary>
    /// delegate for the itemcheckchange
    /// </summary>
    public delegate void ItemCheckedChange();

    public class ComboBoxMultiSelectCommon : ComboBoxCommon
    {

        /// <summary>
        /// get current checked item
        /// </summary>
        private int? currentCheckItem;

        /// <summary>
        /// get current checked value
        /// </summary>
        private string currentCheckValue;

        /// <summary>
        /// get the currentcheckstatus
        /// </summary>
        private CheckState currentCheckStatus;

        /// <summary>
        /// event for itemcheck
        /// </summary>
        public ItemCheckedChange ItemCheckedChange;

        /// <summary>
        /// get current checked item
        /// </summary>
        public int? CurrentCheckItem
        {
            get { return currentCheckItem; }
        }

        /// <summary>
        /// get current checked value
        /// </summary>
        public string CurrentCheckValue
        {
            get { return currentCheckValue; }
        }

        /// <summary>
        /// get current checked status
        /// </summary>
        public CheckState CurrentCheckStatus
        {
            get { return currentCheckStatus; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public ComboBoxMultiSelectCommon()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode
                    != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.MouseClick += new MouseEventHandler(ComboBoxMultiSelectOrder_MouseClick);
            }

        }

        /// <summary>
        /// initialize the control
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ComboBoxMultiSelectCommon
            // 
            this.DropDownHeight = 1;
            this.IntegralHeight = false;
            this.ResumeLayout(false);

        }

        /// <summary>
        /// initialize checkedListBoxCommon
        /// </summary>
        private CheckedListBoxCommon checkedListBox;

        /// <summary>
        /// New datasource object which should not affect the combo box property
        /// </summary>
        public new object DataSource { get; set; }

        /// <summary>
        /// get and set the valuess of items checked displaymember in the checkedListBox
        /// </summary>
        public List<object> CheckedItemValues { get; set; }

        /// <summary>
        /// get and set the valuess of items checked valuemember in the checkedListBox
        /// </summary>
        public List<object> CheckedItemKeys { get; set; }

        /// <summary>
        /// add checkedlistboxcommon on mouseclick on combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxMultiSelectOrder_MouseClick(object sender, EventArgs e)
        {
            if (checkedListBox != null)
            {
                this.FindForm().Controls.Remove(checkedListBox);
                checkedListBox = null;
                return;
            }
            checkedListBox = new CheckedListBoxCommon();

            if (DataSource == null) return;

            this.checkedListBox.DataSource = this.DataSource;
            this.checkedListBox.DisplayMember = this.DisplayMember;
            this.checkedListBox.ValueMember = this.ValueMember;

            checkedListBox.Height = 100;
            checkedListBox.Width = this.Width;
            if (this.Parent is FormCommonBase)
            {
                checkedListBox.Location = new System.Drawing.Point(this.Left, (this.Location.Y + this.Height));
            }
            else
            {
                checkedListBox.Location = new System.Drawing.Point(this.Parent.Location.X + this.Location.X, (this.Parent.Location.Y + this.Location.Y + this.Height));
            }

            this.FindForm().Controls.Add(checkedListBox);
            checkedListBox.BringToFront();
            checkedListBox.Focus();
            SetCheckedList();

            this.checkedListBox.Leave += new EventHandler(CheckedListBoxCommon_Leave);
            this.checkedListBox.ItemCheck += new ItemCheckEventHandler(CheckedListBoxCommon_ItemCheck);
        }

 
        /// <summary>
        /// item check handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBoxCommon_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            checkedListBox.SuspendLayout();
            currentCheckItem = e.Index;
            currentCheckStatus = e.NewValue;
            currentCheckValue = Convert.ToString(checkedListBox.SelectedValue);
            if (CheckedItemKeys != null && CheckedItemKeys.Count != 0 && e.NewValue == CheckState.Unchecked)
            {
                CheckedItemKeys.Remove(currentCheckValue);
            }
            else if (e.NewValue == CheckState.Checked)
            {
                if (CheckedItemKeys == null)
                {
                    CheckedItemKeys = new List<object>();
                }

                CheckedItemKeys.Add(currentCheckValue);
            }
            if (ItemCheckedChange != null)
            {
                ItemCheckedChange.Invoke();
            }

            this.checkedListBox.ItemCheck -= new ItemCheckEventHandler(CheckedListBoxCommon_ItemCheck);
            SetCheckedList();
            this.checkedListBox.ItemCheck += new ItemCheckEventHandler(CheckedListBoxCommon_ItemCheck);
            checkedListBox.ResumeLayout();
        }

        /// <summary>
        /// make the items checked by using CheckedItemKeys is already checked previously
        /// </summary>
        private void SetCheckedList()
        {
            this.Text = string.Empty;
            for (int items = 0; items <= checkedListBox.Items.Count - 1; items++)
            {
                checkedListBox.SetItemChecked(items, false);
            }

            if (CheckedItemKeys == null || CheckedItemKeys.Count == 0) return;

            for (int chkdItems = 0; chkdItems <= CheckedItemKeys.Count - 1; chkdItems++)
            {
                for (int i = 0; i <= checkedListBox.Items.Count - 1; i++)
                {
                    int itemIndex = checkedListBox.Items.IndexOf(checkedListBox.Items[i]);

                    checkedListBox.SelectedIndex = itemIndex;
                   
                    var value = checkedListBox.SelectedValue;

                    if (value == CheckedItemKeys[chkdItems])
                    {
                        checkedListBox.SetItemChecked(itemIndex, true);
                    }
                }
            }
            if (checkedListBox.Items.Count > 0 && this.CurrentCheckItem.HasValue)
            {
                checkedListBox.SetSelected(this.CurrentCheckItem.Value, true);
            }
        }


        /// <summary>
        /// List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBoxCommon_Leave(object sender, EventArgs e)
        {
            if (checkedListBox.Items.Count > 0)
            {
                this.Text = string.Empty;
                CheckedItemKeys = new List<object>();
                CheckedItemValues = new List<object>();

                for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
                {
                    string name = checkedListBox.GetItemText(checkedListBox.CheckedItems[i]).ToString();

                    int itemIndex = checkedListBox.Items.IndexOf(checkedListBox.CheckedItems[i]);

                    checkedListBox.SetSelected(itemIndex, true);

                    var value = checkedListBox.SelectedValue;

                    CheckedItemKeys.Add(value);

                    CheckedItemValues.Add(name);
                }
                if (this.CheckedItemValues.Count > 0)
                {
                    this.Text = string.Join(",", this.CheckedItemValues);
                }
            }

            this.FindForm().Controls.Remove(checkedListBox);

            checkedListBox = null;
        }

        /// <summary>
        /// clear the combo and checked items in the listbox
        /// </summary>
        public void Clear()
        {
            this.Text = string.Empty;
            this.CheckedItemKeys = null;
            this.CheckedItemValues = null;
        }
    }
}
