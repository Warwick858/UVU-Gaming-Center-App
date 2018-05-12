// "UVU Gaming Center Application"
// Copyright 2015, James LoForti
//
//									     ____.           .____             _____  _______   
//									    |    |           |    |    ____   /  |  | \   _  \  
//									    |    |   ______  |    |   /  _ \ /   |  |_/  /_\  \ 
//									/\__|    |  /_____/  |    |__(  <_> )    ^   /\  \_/   \
//									\________|           |_______ \____/\____   |  \_____  /
//									                             \/          |__|        \/ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UVU_Gaming_Center_App
{
    public partial class MessageDialog : Form
    {
        //Create flags
        public bool yesFlag = false;
        public bool noFlag = false;

        public MessageDialog()
        {
            InitializeComponent();
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            yesFlag = true;
            this.Close();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            noFlag = true;
            this.Close();
        }
    }
} // end namespace UVU_Gaming_Center_App
