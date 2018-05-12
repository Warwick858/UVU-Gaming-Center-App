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
    public partial class Guest : Form
    {
        //THIS CLASS REPRESENTS THE GUEST OF A STATION

        //Declare data members
        private string name = "";
        private string ctrl = "";

        //The Default Constructor
        //Purpose: To initialize components
        //Parameters: None
        //Return: None
        public Guest()
        {
            InitializeComponent();
        } // end constructor

        //
        public Guest(string _name, string _ctrl)
        {
            name = _name;
            ctrl = _ctrl;
        }

    } // end class Guest
} // end namespace UVU_Gaming_Center_App