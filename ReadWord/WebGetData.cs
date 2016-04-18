using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadWord
{
    public partial class WebGetData : Form
    {
        public WebGetData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.icris.cr.gov.hk/csci/CBDS_Search.do?nextAction=CBDS_Search&CRNo=0000001&showMedium=true&showBack=true&searchPage=True");

        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {

            e.Cancel = true;//取消在默认浏览器中打开 
        }
    }
}
