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
    public partial class MessageForm : Form
    {
        //The Default Contructor
        //Purpose: To initialize components
        //Parameters: None
        //Return: None
        public MessageForm()
        {
            InitializeComponent();
        } // end default constructor

        //The Paramterized Constructor
        //Purpose: To set message label, button, and title to given values
        //Parameters: Three strings represented as _label, _btn, _title
        //Return None
        public MessageForm(string _label, string _btn, string _title)
        {
            InitializeComponent();

            this.msgLbl.Text = _label;
            this.msgBtn.Text = _btn;
            this.Text = _title;
        } // end parameterized constructor

        //The Show method
        //Purpose: To show a new MessageForm form and initialize components using given values
        //Parameters: 3 strings representing MessageForm values
        //Return: None
        public static void Show(string _label, string _btn, string _title)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new MessageForm(_label, _btn, _title))
            {
                form.ShowDialog();
            }
        }


        //public void setMsgFormHelper(string _label, string _btn, string _title)
        //{
        //    Form1 parent = new Form1();

        //    MessageForm msgForm = new MessageForm();
        //    msgForm.MdiParent = parent;
        //    this.Show();
        //    msgForm.msgLbl.Text = _label;
        //    msgForm.msgBtn.Text = _btn;
        //    msgForm.Text = _title;
        //}

        //The msgBtn_Click method
        //Purpose: To acknowledge the message and close this messageBox
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void msgBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end method msgBtn_Click

    } // end class MessageForm
} // end namespace UVU_Gaming_Center_App
