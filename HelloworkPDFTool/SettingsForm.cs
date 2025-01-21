using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloworkPDFTool
{
    public partial class SettingsForm : Form
    {
        private List<HWField> tempFields;

        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When load the form
        /// </summary>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //Initialize temporary list
            tempFields = new List<HWField>();
            tempFields.Clear();

            foreach (HWField hwf in Program.settings.hwFields)
            {
                HWField temp = new HWField();

                temp.name = hwf.name;
                temp.pageNumber = hwf.pageNumber;
                temp.rect = hwf.rect;

                tempFields.Add(temp);
            }

            //Register the settings to the listBox
            UpdateListBoxSettings();

        }
        private void UpdateListBoxSettings()
        {
            listBoxSettings.Items.Clear();

            foreach (HWField hwf in tempFields)
            {
                listBoxSettings.Items.Add(hwf.name);
            }
        }

        /// <summary>
        /// Change values of numeric buttons
        /// </summary>
        private void listBoxSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                //Fetch values from temp
                textBox1.Text = tempFields[listBoxSettings.SelectedIndex].name;
                numericUpDown1.Value = tempFields[listBoxSettings.SelectedIndex].pageNumber + 1;
                numericUpDownX.Value = tempFields[listBoxSettings.SelectedIndex].rect.X;
                numericUpDownY.Value = tempFields[listBoxSettings.SelectedIndex].rect.Y;
                numericUpDownW.Value = tempFields[listBoxSettings.SelectedIndex].rect.Width;
                numericUpDownH.Value = tempFields[listBoxSettings.SelectedIndex].rect.Height;
            }
        }

        /// <summary>
        /// Apply modificated settings to the Setting class
        /// </summary>
        private void buttonModify_Click(object sender, EventArgs e)
        {
            if(tempFields.Count == 0 || tempFields == null)
            {
                //show error message
                MessageBox.Show("少なくとも１つ以上のプロパティを追加してください。");

                return;
            }
            else
            {
                Program.settings.ApplySettings(tempFields);
            }
            this.Close();
        }

        /// <summary>
        /// Close the window itself
        /// </summary>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Add an item
        /// </summary>
        private void buttonAddField_Click(object sender, EventArgs e)
        {
            if(tempFields.Count < Program.maxFieldCont)
            {
                //Add new item to the last of lists
                HWField temp = new HWField();
                temp.name = "名称未設定";
                tempFields.Add(temp);
                listBoxSettings.Items.Add(temp.name);
            }
            else
            {
                MessageBox.Show("登録可能フィールド数は最大" + Program.maxFieldCont + "箇所までです。");
            }
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        private void buttonRemoveField_Click(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                //Delete selected index of the listbox
                tempFields.RemoveAt(listBoxSettings.SelectedIndex);
                listBoxSettings.Items.RemoveAt(listBoxSettings.SelectedIndex);
            }
        }

        /// <summary>
        /// Revert to the factory setting
        /// </summary>
        private void buttonFieldFactorySettings_Click(object sender, EventArgs e)
        {
            //Reset Selected Index
            listBoxSettings.SelectedIndex = -1;

            //Reset both listBoxSettings.Items and tempFields
            tempFields.Clear();
            listBoxSettings.Items.Clear();

            //Add factory setting items
            tempFields.Add(new HWField("職種", new Rectangle(30, 250, 260, 30), 0));
            tempFields.Add(new HWField("仕事内容", new Rectangle(30, 270, 260, 120), 0));
            tempFields.Add(new HWField("求人番号", new Rectangle(0, 50, 200, 10), 0));
            tempFields.Add(new HWField("受付年月日", new Rectangle(300, 0, 100, 40), 0));
            tempFields.Add(new HWField("紹介期限日", new Rectangle(450, 0, 100, 40), 0));

            UpdateListBoxSettings();
        }

        /// <summary>
        /// Update of the Numeric
        /// </summary>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            //Update the value
            //*** Warning ***
            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                tempFields[listBoxSettings.SelectedIndex].pageNumber = (int)numericUpDown1.Value - 1;
            }
        }
        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            //Update the value
            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                tempFields[listBoxSettings.SelectedIndex].rect.X = (int)numericUpDownX.Value;
            }
        }
        private void numericUpDownW_ValueChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            //Update the value
            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                tempFields[listBoxSettings.SelectedIndex].rect.Width = (int)numericUpDownW.Value;
            }
        }
        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            //Update the value
            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                tempFields[listBoxSettings.SelectedIndex].rect.Y = (int)numericUpDownY.Value;
            }
        }
        private void numericUpDownH_ValueChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            //Update the value
            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                tempFields[listBoxSettings.SelectedIndex].rect.Height = (int)numericUpDownH.Value;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //If no item is selected, return immediately
            if (listBoxSettings.SelectedIndex == -1)
                return;

            //Update the value
            if (listBoxSettings.SelectedIndex < tempFields.Count)
            {
                tempFields[listBoxSettings.SelectedIndex].name = textBox1.Text;
                listBoxSettings.Items[listBoxSettings.SelectedIndex] = textBox1.Text;
            }
        }
    }
}
