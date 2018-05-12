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
    public class Gamer : Player
    {
        //THIS CLASS REPRESENTS AN XBOX ONE, OR PLAYSTATION 4 PLAYER
        //Declare data members
        private string title;
        private string ctrl;

        //The Parameterized Constructor
        //Purpose: To initialize data members to given values
        //Parameters: Six strings represented as _station, _name, _title, _ctrl, _waiting, _time
        //Inherited Parameters: _name, _waiting, _time
        //Return: None
        public Gamer(string _game, string _station, string _name, string _id, string _title, string _ctrl, string _waiting, string _time)
            : base(_game, _name, _id, _waiting, _time, _station)
        {
            title = _title;
            ctrl = _ctrl;
        } // end parameterized constructor

        //The writeData method
        //Purpose: To write the classes data members to file
        //Parameters: A StreamWriter object represented as _outStream
        //Return: None
        //Keyword: Override needed for polymorphism
        public override void writeData(StreamWriter _outStream)
        {
            //Base keyword calls writeData method in base class
            base.writeData(_outStream);

            //Write individual data members to file
            if (title != "games..." && title != "" && title != " ")
                _outStream.WriteLine("Title: " + title);
            if (ctrl != "# of controllers..." && ctrl != "" && ctrl != " ")
                _outStream.WriteLine("Controllers: " + ctrl);
        } // end method writeData

        //The getTitle method
        //Purpose: To return the value of title
        //Parameters: None
        //Return: Title in the form of a string
        public string getTitle()
        {
            return title;
        } // end method getTitle

        //The getCtrl method
        //Purpose: To return the value of ctrl
        //Parameters: None
        //Return: Ctrl in the form of a string
        public string getCtrl()
        {
            return ctrl;
        } // end method getCtrl

    } // end Class Gamer
} // end namespace UVU_Gaming_Center_App
