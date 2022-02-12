
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Com.ZimVie.Wcs.Framework
{
    public class DataGridViewCommon: System.Windows.Forms.DataGridView
    {
        /// <summary>
        /// constructor
        /// </summary>
        public DataGridViewCommon()
        {
            InitializeComponent();
            this.Controls.Add(dateTimePicker);
            this.CellBeginEdit += (sender, e) => {
                if (this.CurrentCell is DataGridViewDateCell)
                {
                    DataGridViewDateCell cell = ((DataGridViewDateCell)CurrentCell);
                    _Rectangle = GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dateTimePicker.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dateTimePicker.Location = new Point(_Rectangle.X, _Rectangle.Y);

                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = cell.OwningColumn.DefaultCellStyle.Format;

                    dateTimePicker.Visible = true;

                    DateTime d = DateTime.Now;
                    if (cell.Value != null && cell.Value != DBNull.Value && !String.IsNullOrEmpty(cell.Value.ToString()) && DateTime.TryParse(cell.Value.ToString(), out d))
                    {
                        dateTimePicker.Value = d;
                    }

                    dateTimePicker.Value = d <= DateTime.MinValue ? DateTime.Now : d;
                }
            };
            this.CellEndEdit += (sender, e) => {
                if (this.CurrentCell is DataGridViewDateCell)
                {
                    if (dateTimePicker.Checked)
                        CurrentCell.Value = dateTimePicker.Value.ToString(dateTimePicker.CustomFormat);
                    else
                        CurrentCell.Value = DBNull.Value;
                    dateTimePicker.Visible = false;
                }
            };
        }

        /// <summary>
        /// initialize the control
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewCommon
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

            //Prevent undefined columns generated automatically
            this.AutoGenerateColumns = false;
        }


        /// <summary>
        /// get and set the controlid
        /// </summary>
        public string ControlId { get; set; }
        Rectangle _Rectangle;
        DateTimePicker dateTimePicker = new DateTimePicker { Visible = false, Checked = true, ShowCheckBox = true };
    }

    public class DataGridViewDateCell : DataGridViewTextBoxCell
    {

        public DataGridViewDateCell()
            : base()
        {
        }
    }
    public class DataGridViewDateTimeColumn : DataGridViewColumn
    {
        public DataGridViewDateTimeColumn()
                : base(new DataGridViewDateCell())
        {
        }
    }
}
