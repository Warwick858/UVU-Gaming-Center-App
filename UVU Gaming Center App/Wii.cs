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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVU_Gaming_Center_App
{
    public class Wii : Player
    {
        //THIS CLASS REPRESENTS A WII U PLAYER
        //Declare data members
        private string title;
        private string pctrl;
        private string rctrl;
        private string nctrl;
        private string gctrl;

        //The Parameterized Constructor
        //Purpose: To initialize data members to given values
        //Parameters: Nine strings represented as _station, _name, _title, _pctrl, _rctrl, _nctrl, _gctrl, _waiting, _time
        //Inherited Parameters: _name, _waiting, _time
        //Return: None
        public Wii(string _game, string _station, string _name, string _id, string _title, string _pctrl, string _rctrl, string _nctrl, string _gctrl, string _waiting, string _time)
            : base(_game, _name, _id, _waiting, _time, _station)
        {
            title = _title;
            pctrl = _pctrl;
            rctrl = _rctrl;
            nctrl = _nctrl;
            gctrl = _gctrl;
        } // end parameterized constructor

        //The writeData method
        //Purpose: To write the classes data members to file
        //Parameters: A StreamWriter object represented as _outStream
        //Return: None
        //Keyword: Override is needed for polymorphism
        public override void writeData(StreamWriter _outStream)
        {
            //Base keyword calls writeData method in base class
            base.writeData(_outStream);

            //Write individual data members to file
            if (title != "games..." && title != "" && title != " ")
                _outStream.WriteLine("Title: " + title);
            if (pctrl != "# of controllers..." && pctrl != "" && pctrl != " ")   
                _outStream.WriteLine("ProCtlrs: " + pctrl);
            if (rctrl != "# of remotes..." && rctrl != "" && rctrl != " ") 
                _outStream.WriteLine("WiiRemotes: " + rctrl);
            if (nctrl != "# of nunchuks..." && nctrl != "" && nctrl != " ") 
                _outStream.WriteLine("Nunchuks: " + nctrl);
            if (gctrl != "# of gamepads..." && gctrl != "" && gctrl != " ") 
                _outStream.WriteLine("Gamepads: " + gctrl);
        } // end method writeData

        //The getTitle method
        //Purpose: To return the value of title
        //Parameters: None
        //Return: Title in the form of a string
        public string getTitle()
        {
            return title;
        } // end method getTitle

        //The getPCtrl method
        //Purpose: To return the value of pctrl
        //Parameters: None
        //Return: PCtrl in the form of a string
        public string getPCtrl()
        {
            return pctrl;
        } // end method getPCtrl

        //The getRCtrl method
        //Purpose: To return the value of rctrl
        //Parameters: None
        //Return: RCtrl in the form of a string
        public string getRCtrl()
        {
            return rctrl;
        } // end method getRCtrl

        //The getNCtrl method
        //Purpose: To return the value of nctrl
        //Parameters: None
        //Return: NCtrl in the form of a string
        public string getNCtrl()
        {
            return nctrl;
        } // end method getNCtrl

        //The getGCtrl method
        //Purpose: To return the value of gctrl
        //Parameters: None
        //Return: GCtrl in the form of a string
        public string getGCtrl()
        {
            return gctrl;
        } // end method getGCtrl

    } // end class Wii
} // end namespace UVU_Gaming_Center_App
