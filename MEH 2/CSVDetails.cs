using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEHv2
{
    public partial class CSVDetailsForm : Form 
    {


        private Dictionary<string, int[]> Results = new Dictionary<string, int[]>();



        //https://stackoverflow.com/a/4701755
        public CSVDetailsForm(string[] Headers)
        {
            InitializeComponent();

            ID_CheckedListBox.Items.AddRange(Headers);
            Text_CheckedListBox.Items.AddRange(Headers);

            OKButton.DialogResult = DialogResult.OK;
            CancelButton.DialogResult = DialogResult.Cancel;


        }


        public Dictionary<string, int[]> CSVDetailsDialogResult
        {

            get { return this.Results; }

        }


        public bool ColumnsAsSeparateTexts
        {
            get { return ColumnsAsSeparateTextsCheckbox.Checked; }
        }



        private void OKButton_Click(object sender, EventArgs e)
        {


            List<int> CheckedListboxResults = new List<int>();

            foreach (object CheckedItem in ID_CheckedListBox.CheckedItems) CheckedListboxResults.Add(ID_CheckedListBox.Items.IndexOf(CheckedItem));
            Results.Add("ID", CheckedListboxResults.ToArray());
            CheckedListboxResults.Clear();

            foreach (object CheckedItem in Text_CheckedListBox.CheckedItems) CheckedListboxResults.Add(Text_CheckedListBox.Items.IndexOf(CheckedItem));
            Results.Add("Text", CheckedListboxResults.ToArray());
            CheckedListboxResults.Clear();

            this.Close();


        }



    }
}
