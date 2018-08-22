using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectAllocationUtil
{
    public class MessageUtil
    {
        public static void ErrorMessage(string error,string msgTitle= ""){
            MessageBox.Show(error, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult QuestionMessage(string question,string msgTitle= ""){
            return MessageBox.Show(question, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static void InformationMessage(string info,string msgTitle= ""){
            MessageBox.Show(info, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
