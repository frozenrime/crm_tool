using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_Tool.Helpers
{

    public abstract class ExportBase
    {
        public void Export(DataGridView dgv, string fileName)
        {
            try
            {
                PrepareData(dgv);
                SaveFile(dgv, fileName);
                MessageBox.Show(GetSuccessMessage(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        protected abstract void PrepareData(DataGridView dgv);
        protected abstract void SaveFile(DataGridView dgv, string fileName);
        protected abstract string GetSuccessMessage();
    }
}
