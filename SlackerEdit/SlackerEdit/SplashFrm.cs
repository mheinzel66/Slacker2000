using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace SlackerEdit
{
    public partial class SplashFrm : Form
    {
     
        /// <summary>
        /// 
        /// </summary>
        public SplashFrm()
        {       
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SplashFrm_Shown(object sender, EventArgs e)
        {        
            Thread.Sleep(2000);
            this.Close();

        }
    }
}
