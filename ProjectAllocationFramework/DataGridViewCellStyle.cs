using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectAllocationFramework
{
    public class DataGridViewCellStyle
    {
        private static System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4String = new System.Windows.Forms.DataGridViewCellStyle();
        private static System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4Double = new System.Windows.Forms.DataGridViewCellStyle();
        private static System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4Int = new System.Windows.Forms.DataGridViewCellStyle();
        private static System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4IntWithoutComma = new System.Windows.Forms.DataGridViewCellStyle();

        public static System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4String
        {
            get { return dataGridViewCellStyle4String; }
        }

        public static System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4Double
        {
            get { return dataGridViewCellStyle4Double; }
        }

        public static System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4Int
        {
            get { return dataGridViewCellStyle4Int; }
        }

        public static System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4IntWithoutComma
        {
            get { return dataGridViewCellStyle4IntWithoutComma; }
        }

        static DataGridViewCellStyle()
        {
            dataGridViewCellStyle4String.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            
            dataGridViewCellStyle4Double.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4Double.Format = "N2";
            dataGridViewCellStyle4Double.NullValue = null;

            dataGridViewCellStyle4Int.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4Int.Format = "N0";
            dataGridViewCellStyle4Int.NullValue = null;

            dataGridViewCellStyle4IntWithoutComma.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4IntWithoutComma.Format = "##########";
            dataGridViewCellStyle4IntWithoutComma.NullValue = null;
        }
    }
}
