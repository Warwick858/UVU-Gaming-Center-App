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
    public class GamingCenter : Player
    {
        //THIS CLASS REPRESENTS A PING-PONG, AIR HOCKEY, BILLIARD, OR FOOSBALL PLAYER
        //Declare data members
        private string cues;

        //The Parameterized Constructor
        //Purpose: To initialize data members to given values
        //Parameters: Four strings represented as _station, _cues, _waiting, _time
        //Inherited Parameters: _name, _waiting, _time
        //Return: None
        public GamingCenter(string _game, string _name, string _id, string _station, string _cues, string _waiting, string _time)
            : base(_game, _name, _id, _waiting, _time, _station)
        {
            cues = _cues;
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

            //Write class data member to file  
            if (cues != "cues..." && cues != "sets..." && cues != "balls..." && cues != "" && cues != " ")
                _outStream.WriteLine("Items: " + cues);
        } // end method writeData

        //The getCues method
        //Purpose: To return the value of cues
        //Parameters: None
        //Return: Cues in the form of a string
        public string getCues()
        {
            return cues;
        } // end method getCues

    } // end class GamingCenter
} // end namespace UVU_Gaming_Center_App
