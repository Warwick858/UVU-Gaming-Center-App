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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UVU_Gaming_Center_App
{
    public partial class Player : Form
    {
        //Declare data members
        protected string game;
        protected string name;
        protected string id;
        protected string waiting;
        protected string time;
        private string station;
        private const int SEVEN = 7;
        private int guestCount = 0;
        public bool parentFormClosingFlag = false;

        //Declare DateTime objects, and send to string
        private static string today = DateTime.Now.ToString("MM/dd/yyyy");
        private static string currTime = DateTime.Now.ToShortTimeString();
        //Replace all '/' with '.'  ---- Note: File naming conventions in NotePad restrict '/'
        private static string todayFormatted = today.Replace('/', '.');
        //Create file path
        string filePath = @"C:\Bowling Alley\UVU Gaming Center App\Data\" + todayFormatted + ".txt";
        //string filePath = @"C:\Bowling Alley\UVU Gaming Center App\Data\test.txt";
        //Create List to hold Guests
        List<Guest> myGuests = new List<Guest>();

        //The Default Constructor
        //Purpose: To initialize components
        //Parameters: None
        //Return: None
        public Player()
        {
            InitializeComponent();
        } // end constructor

        //The Parameterized Constructor
        //Purpose: To initialized date members to the given values
        //Parameters: Three strings represented as _name, _waiting, _time
        //Return: None
        public Player(string _game, string _name, string _id, string _waiting, string _time, string _station)
        {
            game = _game;
            name = _name;
            id = _id;
            waiting = _waiting;
            time = _time;
            station = _station;
        } // end parameterized constructor

        //The Player_FormClosing method
        //Purpose: To call formClosingHelper method
        //Parameters: The object sending the event, and the event arguments
        //Return: None
        public void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Create helper instance
            MessageDialog msgD = new MessageDialog();

            //Skip player form checking if parent form is closing as well
            if (parentFormClosingFlag == false)
            {
                //Ask user if they really want to close player form
                msgD.ShowDialog(); // show MessageDialog

            } // end if

            if (msgD.noFlag == true) // confirm user selected yes
            {
                e.Cancel = true; // if yes, cancel FormClosing
            } // end if
            else                // if no, save data and close form
            {
                //Save player data
                savePlayer(filePath, true);
            } // end else

            //Decrement current player count
            //Form1 parent = new Form1();
            //parent.decrementCurrentCount();
        } // end method Player_FormClosing

        //The saveAll method
        //Purpose: To save all data (in all tab pages) on this player form
        //Parameters: A string represented as _filePath
        //Return: None
        public void saveAll(string _filePath, Form[] _myChildren)
        {
            //Declare helpers
            List<Form> myPlayers = new List<Form>();
            List<Guest> myGuests = new List<Guest>();

            //Seperate Player and Guest forms
            for (int i = 0; i < _myChildren.Count(); i++)
            {
                if (_myChildren[i].Text == "Player")
                    myPlayers.Add(_myChildren[i]);
                if (_myChildren[i].Text == "Guest")
                    myGuests.Add((Guest)_myChildren[i]);
            } // end for

            //Save Players
            foreach (Player player in myPlayers)
            {
                player.savePlayer(_filePath, true);
            } // end foreach

            //Save Guests
            for (int i = 0; i < myGuests.Count(); i++)
            {
                saveGuest(myGuests[i], _filePath);
            } // end for

            //Decrement current player count
            //Form1 parent = new Form1();
            //parent.decrementCurrentCount();
        } // end method saveAll

        //The savePlayer method
        //Purpose: To save the data in all txtBoxes & cmboBoxes throughout player form
        //Parameters: None
        //Return: None
        private void savePlayer(string _filePath, bool _flagState)
        {
            //Create an array of Player objects
            Player[] playArray = new Player[SEVEN];

            //XBOX ONE OBJECT
            Player player12 = new Gamer("XBOX One", stationCmboBox.Text, nameTxtBox.Text, idTxtBox.Text, titleCmboBox.Text, ctrlCmboBox.Text, waitingTxtBox.Text,
                stopWatch_Custom1._currentElapsedTime.ToString());
            //WII U OBJECT
            Player player13 = new Wii("Wii U", stationCmboBox2.Text, nameTxtBox2.Text, idTxtBox2.Text, titleCmboBox2.Text, pctrlCmboBox.Text, rctrlCmboBox.Text,
                nctrlCmboBox.Text, gctrlCmboBox.Text, waitingTxtBox2.Text, stopWatch_Custom2._currentElapsedTime.ToString());
            //PS4 OBJECT
            Player player14 = new Gamer("PlayStation 4", stationCmboBox3.Text, nameTxtBox3.Text, idTxtBox3.Text, titleCmboBox3.Text, ctrlCmboBox3.Text, waitingTxtBox3.Text,
                stopWatch_Custom3._currentElapsedTime.ToString());
            //BILLIARDS OBJECT
            Player player15 = new GamingCenter("Billiards", nameTxtBox4.Text, idTxtBox4.Text, stationCmboBox4.Text, cuesCmboBox4.Text, waitingTxtBox4.Text, stopWatch_Custom7._currentElapsedTime.ToString());
            //PING-PONG OBJECT
            Player player16 = new GamingCenter("Ping-Pong", nameTxtBox5.Text, idTxtBox5.Text, stationCmboBox5.Text, setsCmboBox5.Text, waitingTxtBox5.Text, stopWatch_Custom4._currentElapsedTime.ToString());
            //AIR HOCKEY OBJECT
            Player player17 = new GamingCenter("Air Hockey", nameTxtBox6.Text, idTxtBox6.Text, stationCmboBox6.Text, setsCmboBox6.Text, waitingTxtBox6.Text, stopWatch_Custom5._currentElapsedTime.ToString());
            //FOOSBALL OBJECT
            Player player18 = new GamingCenter("Foosball", nameTxtBox7.Text, idTxtBox7.Text, stationCmboBox7.Text, ballsCmboBox7.Text, waitingTxtBox7.Text, stopWatch_Custom6._currentElapsedTime.ToString());

            //Fill array with Player objects
            playArray[0] = player12;
            playArray[1] = player13;
            playArray[2] = player14;
            playArray[3] = player15;
            playArray[4] = player16;
            playArray[5] = player17;
            playArray[6] = player18;

            //Create new StreamWriter object
            StreamWriter outStream = new StreamWriter(_filePath, _flagState);

            //For-loop through playArray to write all object data to file
            for (int i = 0; i < SEVEN; i++)
            {
                if (playArray[i] != null)
                    playArray[i].writeData(outStream);
            } // end for

            //Close the StreamWriter object
            outStream.Close();
        } // end method savePlayer

        //The saveGuest method
        //Purpose: To save a guests location, name, and ctrl
        //Parameters: A Guest object represented as _guest, and a string represented as _filePath
        //Return: None
        private void saveGuest(Guest _guest, string _filePath)
        {
            //Create StreamWriter
            StreamWriter outStream = new StreamWriter(_filePath, true);

            outStream.WriteLine("guestLocation: " + _guest.Location);
            outStream.WriteLine("guestName: " + _guest.guestNameTxtBox.Text);
            outStream.WriteLine("guestCtrl: " + _guest.guestCtrlCmboBox.Text);
            outStream.Close();
        } // end method saveGuest

        //The writeData method --- INHERITANCE --- VIRTUAL
        //Purpose: To write base class data members to outStream
        //Parameters: A StreamWriter object represented as _outStream
        //Return: None
        public virtual void writeData(StreamWriter _outStream)
        {
            //Create instance
            Form1 parent = new Form1();

            //Write base data members to outStream
            if (name != "" && name != " ")
            {
                _outStream.WriteLine("Game: " + game);
                _outStream.WriteLine(parent.getCurrTime());
                _outStream.WriteLine("Name: " + name);
                if (station != "station..." && station != "" && station != " ")
                    _outStream.WriteLine("Station: " + station);
            }
            if (id != "" && id != " ")
                _outStream.WriteLine("ID: " + id);
            if (waiting != "" && waiting != " ")
                _outStream.WriteLine("Waiting: " + waiting);
            if (time != "00:00:00")
                _outStream.WriteLine("Time: " + time);
        } // end method writeData

        //The getGame method
        //Purpose: To return the value of game
        //Parameters: None
        //Return: Game in the form of a string
        public string getGame()
        {
            return game;
        } // end method getGame

        //The getName method
        //Purpose: To return the value of name
        //Parameters: None
        //Return: Name in the form of a string
        public string getName()
        {
            return name;
        } // end method getName

        //The getWaiting method
        //Purpose: To return the value of waiting
        //Parameters: None
        //Return: Waiting in the form of a string
        public string getWaiting()
        {
            return waiting;
        } // end method getWaiting

        //The getTime method
        //Purpose: To return the value of time
        //Parameters: None
        //Return: Time in the form of a string
        public string getTime()
        {
            return time;
        } // end method getTime

        //The getStation method
        //Purpose: To return the value of station
        //Parameters: None
        //Return: Station in the form of a string
        public string getStation()
        {
            return station;
        } // end method getStation

        //The changeStnCmboBoxes method
        //Purpose: To change player forms' locations and station cmboBox text
        //Parameters: A list of player objects, represented as _myPlayers
        //Return: None
        public void changeStnCmboBoxes(List<Player> _myPlayers)
        {
            //Change station cmboBox text
            _myPlayers[0].stationCmboBox.Text = "1";
            _myPlayers[1].stationCmboBox.Text = "2";
            _myPlayers[2].stationCmboBox.Text = "3";
            _myPlayers[3].stationCmboBox.Text = "4";
            _myPlayers[4].stationCmboBox.Text = "5";
            //Change tabControl Index on each player form
            _myPlayers[5].tabControl1.SelectedIndex = 3;
            _myPlayers[5].stationCmboBox5.Text = "1";
            _myPlayers[6].tabControl1.SelectedIndex = 3;
            _myPlayers[6].stationCmboBox5.Text = "2";
            _myPlayers[7].tabControl1.SelectedIndex = 4;
            _myPlayers[7].stationCmboBox6.Text = "1";
            _myPlayers[8].tabControl1.SelectedIndex = 5;
            _myPlayers[8].stationCmboBox7.Text = "1";
            _myPlayers[9].tabControl1.SelectedIndex = 6;
            _myPlayers[9].stationCmboBox4.Text = "1";
            _myPlayers[10].tabControl1.SelectedIndex = 6;
            _myPlayers[10].stationCmboBox4.Text = "2";
        } // end method changeStnCmboBoxes

        //The guestInstanceHelper method
        //Purpose: To set the MdiParent and show form of guest object
        //Parameters: A guest object represented as _guestInstance
        //Return: None
        private void guestInstanceHelper(Guest _guestInstance)
        {
            myGuests.Add(_guestInstance); // add to list
            _guestInstance.MdiParent = this.MdiParent;  //Set parent
            _guestInstance.Show();  //Show form of guest object

            //Increment total count in parent class
            //Form1 parent = new Form1();
            //Form.MdiParent.incrementTotalCount(1);           //  THIS LINE OF CODE CREATES A HUGE LAG WHEN SHOWING GUEST FORM.  ALSO, INCREMENT COUNT IS NOT WORKING
        } // end method GuestInstanceHelper

        //The guestClear method
        //Purpose: To go through the list of guests and clear those associated with the given station
        //Parameters: A string representing the station number
        //Return: None
        private void guestClear(string _station)
        {
            //Clear station 5 guests
            if (_station == "5")
            {
                for (int i = 0; i < myGuests.Count(); i++)
                {
                    if (Point.Equals(myGuests[i].Location, new Point(981, 0)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(981, 124)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(1599, 0)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(1599, 124)))
                        myGuests[i].Close();
                }
            }
            //Clear station 4 guests
            if (_station == "4")
            {
                for (int i = 0; i < myGuests.Count(); i++)
                {
                    if (Point.Equals(myGuests[i].Location, new Point(472, 0)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(472, 124)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 0)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 124)))
                        myGuests[i].Close();
                }
            }
            //Clear station 3 guests
            if (_station == "3")
            {
                for (int i = 0; i < myGuests.Count(); i++)
                {
                    if (Point.Equals(myGuests[i].Location, new Point(472, 248)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(472, 372)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 248)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 372)))
                        myGuests[i].Close();
                }
            }
            //clear station 2 guests
            if (_station == "2")
            {
                for (int i = 0; i < myGuests.Count(); i++)
                {
                    if (Point.Equals(myGuests[i].Location, new Point(472, 496)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(472, 620)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 496)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 620)))
                        myGuests[i].Close();
                }
            }
            //Clear station 1 guests
            if (_station == "1")
            {
                for (int i = 0; i < myGuests.Count(); i++)
                {
                    if (Point.Equals(myGuests[i].Location, new Point(472, 744)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(472, 868)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 744)))
                        myGuests[i].Close();
                    if (Point.Equals(myGuests[i].Location, new Point(647, 868)))
                        myGuests[i].Close();
                }
            }
        } // end method guestClear

        //The clearBoxControlsHelper method
        //Purpose: To scan through and clear each txt and cmbo box controls in given tabPg
        //Parameters: A control represented as con
        //Return: None
        public void clearBoxControlsHelper(Control _con)
        {
            //Save player data
            //savePlayer(filePath, true);
            //Reset BackColor
            this.BackColor = default(Color);

            //Save station number
            string stnNum = getStationNumber(_con);

            //Clear all text and combo boxes
            foreach (Control guiControl in _con.Controls)
            {
                if (guiControl is TextBox) // clear txtBoxes
                    ((TextBox)guiControl).Clear();
                if (guiControl is ComboBox) // clear cmboBoxes
                    ((ComboBox)guiControl).Text = null;
                else
                    clearBoxControlsHelper(guiControl);  //RECURSIVE CALL
            } // end foreach

            //Reset station number
            setStationNumber(_con, stnNum);
        } // end method clearBoxControlsHelper

        //The getStationNumber method
        //Purpose: To find the statioCmboBox for the given tabPage
        //Parameters: A control represented as _tabPage
        //Return: station number in the form of a string
        private string getStationNumber(Control _tabPage)
        {
            //Declare helpers
            string stnNum = "";

            if (_tabPage.Text == "XBOX One")
                stnNum = stationCmboBox.Text;
            if (_tabPage.Text == "Wii U")
                stnNum = stationCmboBox2.Text;
            if (_tabPage.Text == "PlayStation 4")
                stnNum = stationCmboBox3.Text;
            if (_tabPage.Text == "Ping-Pong")
                stnNum = stationCmboBox5.Text;
            if (_tabPage.Text == "Air Hockey")
                stnNum = stationCmboBox6.Text;
            if (_tabPage.Text == "Foosball")
                stnNum = stationCmboBox7.Text;
            if (_tabPage.Text == "Billiards")
                stnNum = stationCmboBox4.Text;

            return stnNum;
        } // end method getStationNumber

        //The setStationNumber method
        //Purpose: To set the statioCmboBox for the given tabPage
        //Parameters: A control represented as _tabPage
        //Return: station number in the form of a string
        private void setStationNumber(Control _tabPage, string _stnNum)
        {
            if (_tabPage.Text == "XBOX One")
                stationCmboBox.Text = _stnNum;
            if (_tabPage.Text == "Wii U")
                stationCmboBox2.Text = _stnNum;
            if (_tabPage.Text == "PlayStation 4")
                stationCmboBox3.Text = _stnNum;
            if (_tabPage.Text == "Ping-Pong")
                stationCmboBox5.Text = _stnNum;
            if (_tabPage.Text == "Air Hockey")
                stationCmboBox6.Text = _stnNum;
            if (_tabPage.Text == "Foosball")
                stationCmboBox7.Text = _stnNum;
            if (_tabPage.Text == "Billiards")
                stationCmboBox4.Text = _stnNum;
        } // end method setStationNumber

        //The activeMdiChildLocationHelper method
        //Purpose: To move the active MdiChild form to the given station (location) on the parent form
        //Parameters: A ComboBox control represented as _stationCmboBox
        //Return: None
        private void activeMdiChildLocationHelper(ComboBox _stationCmboBox)
        {
            //Move this child form to specified station location
            if (_stationCmboBox.Text == "1")
                stationOneLocation();
            if (_stationCmboBox.Text == "2")
                stationTwoLocation();
            if (_stationCmboBox.Text == "3")
                stationThreeLocation();
            if (_stationCmboBox.Text == "4")
                stationFourLocation();
            if (_stationCmboBox.Text == "5")
                stationFiveLocation();
        } // end method activeMdiChildLocationHelper

        //The clearWaitingHelper method
        //Purpose: To uncheck waitChkBox, which changes waitingTxtBox visibility to false
        //Parameters: A CheckBox represented as _chkBox
        //Return: None
        public void clearWaitingHelper(CheckBox _chkBox)
        {
            _chkBox.Checked = false;
        } // end method clearWaitingHelper

        //*********************************************************Begin XBOX One***********************************************************

        //The clearPicBox_Click method
        //Purpose: To create a gamer object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox_Click(object sender, EventArgs e)
        {
            //XBOX ONE OBJECT
            Player player12 = new Gamer("XBOX One", stationCmboBox.Text, nameTxtBox.Text, idTxtBox.Text, titleCmboBox.Text, ctrlCmboBox.Text, waitingTxtBox.Text,
                stopWatch_Custom1._currentElapsedTime.ToString());

            //Create new StreamWriter object - append file
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player12.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox.Text = "";
            clearWaitingHelper(waitChkBox);

            //Reset timer
            stopWatch_Custom1.resetClock();

            //Clear Guests
            guestClear(stationCmboBox.Text);

            //Reset Combo Boxes
            titleCmboBox.SelectedIndex = 0;
            ctrlCmboBox.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on xBoxTabPg
            clearBoxControlsHelper(this.xBoxTabPg);
        } // end method clearPicBox_Click

        //The stationCmboBox_SelectedIndexChanged method
        //Purpose: To move the MdiChild form by calling activeMdiChildLocationHelper method
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Call helper method
            activeMdiChildLocationHelper(stationCmboBox);
            //Change Station text in all cmboBoxes
            stationCmboBox2.Text = stationCmboBox.Text;
            stationCmboBox3.Text = stationCmboBox.Text;
            //Move cursor to nameTxtBox
            this.ActiveControl = nameTxtBox;
        } // end method stationCmboBox_SelectedIndexChanged

        //The ctrlCmboBox_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void ctrlCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(ctrlCmboBox.Text) - 1);
        } // end method ctrlCmboBox_SelectedIndexChanged

        //The waitChkBox_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waitTxtBox visible
            if (waitChkBox.Checked == true)
                waitingTxtBox.Visible = true;
            else
                waitingTxtBox.Visible = false;
        } // end method waitChkBox_CheckedChanged

        //The addGuestPicBox_Click method
        //Purpose: To create a new instance of a guest form
        //Parameters: The object sending the event, and the event arguments
        //Return: None
        private void addGuestPicBox_Click(object sender, EventArgs e)
        {
            //Set location of guest forms based on player station number
            if (this.stationCmboBox.Text == "4")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest0 = new Guest();
                        guestInstanceHelper(guest0);
                        guest0.Location = new Point(472, 0);
                        break;
                    case 1:
                        Guest guest1 = new Guest();
                        guestInstanceHelper(guest1);
                        guest1.Location = new Point(472, 124);
                        break;
                    case 2:
                        Guest guest2 = new Guest();
                        guestInstanceHelper(guest2);
                        guest2.Location = new Point(647, 0);
                        break;
                    case 3:
                        Guest guest3 = new Guest();
                        guestInstanceHelper(guest3);
                        guest3.Location = new Point(647, 124);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "3" || this.stationCmboBox2.Text == "3")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest4 = new Guest();
                        guestInstanceHelper(guest4);
                        guest4.Location = new Point(472, 248);
                        break;
                    case 1:
                        Guest guest5 = new Guest();
                        guestInstanceHelper(guest5);
                        guest5.Location = new Point(472, 372);
                        break;
                    case 2:
                        Guest guest6 = new Guest();
                        guestInstanceHelper(guest6);
                        guest6.Location = new Point(647, 248);
                        break;
                    case 3:
                        Guest guest7 = new Guest();
                        guestInstanceHelper(guest7);
                        guest7.Location = new Point(647, 372);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "2")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest8 = new Guest();
                        guestInstanceHelper(guest8);
                        guest8.Location = new Point(472, 496);
                        break;
                    case 1:
                        Guest guest9 = new Guest();
                        guestInstanceHelper(guest9);
                        guest9.Location = new Point(472, 620);
                        break;
                    case 2:
                        Guest guest10 = new Guest();
                        guestInstanceHelper(guest10);
                        guest10.Location = new Point(647, 496);
                        break;
                    case 3:
                        Guest guest11 = new Guest();
                        guestInstanceHelper(guest11);
                        guest11.Location = new Point(647, 620);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "1" || this.stationCmboBox2.Text == "1")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest12 = new Guest();
                        guestInstanceHelper(guest12);
                        guest12.Location = new Point(472, 744);
                        break;
                    case 1:
                        Guest guest13 = new Guest();
                        guestInstanceHelper(guest13);
                        guest13.Location = new Point(472, 868);
                        break;
                    case 2:
                        Guest guest14 = new Guest();
                        guestInstanceHelper(guest14);
                        guest14.Location = new Point(647, 744);
                        break;
                    case 3:
                        Guest guest15 = new Guest();
                        guestInstanceHelper(guest15);
                        guest15.Location = new Point(647, 868);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "5" || this.stationCmboBox2.Text == "5" || this.stationCmboBox3.Text == "5")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest16 = new Guest();
                        guestInstanceHelper(guest16);
                        guest16.Location = new Point(981, 0); // 1010, 124
                        break;
                    case 1:
                        Guest guest17 = new Guest();
                        guestInstanceHelper(guest17);
                        guest17.Location = new Point(981, 124);
                        break;
                    case 2:
                        Guest guest18 = new Guest();
                        guestInstanceHelper(guest18);
                        guest18.Location = new Point(1599, 0);
                        break;
                    case 3:
                        Guest guest19 = new Guest();
                        guestInstanceHelper(guest19);
                        guest19.Location = new Point(1599, 124);
                        break;
                } // end switch
            } // end if
            guestCount++;
        } // end method addGuestPicBox_Click

        //The disablePicBox_Click method
        //Purpose: To send disable/enable command to the given stations A/C Networking device
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void disablePicBox_Click(object sender, EventArgs e)
        {
            //Network AC switch implementation
        } // end method disablePicBox_Click

        //************************************************************Begin Wii U***********************************************************

        //The clearPicBox2 method
        //Purpose: To create a gamer object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox2_Click(object sender, EventArgs e)
        {
            //WII U OBJECT
            Player player13 = new Wii("Wii U", stationCmboBox2.Text, nameTxtBox2.Text, idTxtBox2.Text, titleCmboBox2.Text, pctrlCmboBox.Text,
                rctrlCmboBox.Text, nctrlCmboBox.Text, gctrlCmboBox.Text, waitingTxtBox2.Text, stopWatch_Custom2._currentElapsedTime.ToString());

            //Create new StreamWriter object - append file
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player13.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox2.Text = "";
            clearWaitingHelper(waitChkBox2);

            //Reset timer
            stopWatch_Custom2.resetClock();

            //Clear Guests
            guestClear(stationCmboBox2.Text);

            //Reset Combo Boxes
            titleCmboBox2.SelectedIndex = 0;
            pctrlCmboBox.SelectedIndex = 0;
            rctrlCmboBox.SelectedIndex = 0;
            nctrlCmboBox.SelectedIndex = 0;
            gctrlCmboBox.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on wiiTabPg
            clearBoxControlsHelper(this.wiiTabPg);
        } // end method clearPicBox2_Click

        //The stationCmboBox2_SelectedIndexChanged method
        //Purpose: To move the MdiChild form by calling activeMdiChildLocationHelper method
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Call helper method
            activeMdiChildLocationHelper(stationCmboBox2);
            //Change Station text in all cmboBoxes
            stationCmboBox.Text = stationCmboBox2.Text;
            stationCmboBox3.Text = stationCmboBox2.Text;
            //Move cursor to nameTxtBox
            this.ActiveControl = nameTxtBox2;
        } // end method stationCmboBox2_SelectedIndexChanged

        //The pctrlCmboBox_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void pctrlCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(pctrlCmboBox.Text) - 1);
        } // end method pctrlCmboBox_SelectedIndexChanged

        //The rtrlCmcboBox_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void rctrlCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(rctrlCmboBox.Text) - 1);
        } // end method rctrlCmboBox_SelectedIndexChanged

        //The ntrlCmcboBox_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void nctrlCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(nctrlCmboBox.Text) - 1);
        } // end method nctrlCmboBox_SelectedIndexChanged

        //The gtrlCmcboBox_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void gctrlCmboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(gctrlCmboBox.Text) - 1);
        } // end method gctrlCmboBox_SelectedIndexChanged

        //The waitChkBox2_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waiting nameTxtBox appear
            if (waitChkBox2.Checked == true)
                waitingTxtBox2.Visible = true;
            else
                waitingTxtBox2.Visible = false;
        } // end method waitChkBox2_CheckedChanged

        //The addGuestPicBox2 method
        //Purpose: To create an instance of the Guest class and show form
        //Parameters: The object sending the event, and the event arguments
        //Return: None
        private void addGuestPicBox2_Click(object sender, EventArgs e)
        {
            //Set location of guest forms based on player station number
            if (this.stationCmboBox.Text == "4")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest0 = new Guest();
                        guestInstanceHelper(guest0);
                        guest0.Location = new Point(472, 0);
                        break;
                    case 1:
                        Guest guest1 = new Guest();
                        guestInstanceHelper(guest1);
                        guest1.Location = new Point(472, 124);
                        break;
                    case 2:
                        Guest guest2 = new Guest();
                        guestInstanceHelper(guest2);
                        guest2.Location = new Point(642, 0);
                        break;
                    case 3:
                        Guest guest3 = new Guest();
                        guestInstanceHelper(guest3);
                        guest3.Location = new Point(642, 124);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "3" || this.stationCmboBox2.Text == "3")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest4 = new Guest();
                        guestInstanceHelper(guest4);
                        guest4.Location = new Point(472, 248);
                        break;
                    case 1:
                        Guest guest5 = new Guest();
                        guestInstanceHelper(guest5);
                        guest5.Location = new Point(472, 372);
                        break;
                    case 2:
                        Guest guest6 = new Guest();
                        guestInstanceHelper(guest6);
                        guest6.Location = new Point(642, 248);
                        break;
                    case 3:
                        Guest guest7 = new Guest();
                        guestInstanceHelper(guest7);
                        guest7.Location = new Point(642, 372);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "2")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest8 = new Guest();
                        guestInstanceHelper(guest8);
                        guest8.Location = new Point(472, 496);
                        break;
                    case 1:
                        Guest guest9 = new Guest();
                        guestInstanceHelper(guest9);
                        guest9.Location = new Point(472, 620);
                        break;
                    case 2:
                        Guest guest10 = new Guest();
                        guestInstanceHelper(guest10);
                        guest10.Location = new Point(642, 496);
                        break;
                    case 3:
                        Guest guest11 = new Guest();
                        guestInstanceHelper(guest11);
                        guest11.Location = new Point(642, 620);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "1" || this.stationCmboBox2.Text == "1")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest12 = new Guest();
                        guestInstanceHelper(guest12);
                        guest12.Location = new Point(472, 744);
                        break;
                    case 1:
                        Guest guest13 = new Guest();
                        guestInstanceHelper(guest13);
                        guest13.Location = new Point(472, 868);
                        break;
                    case 2:
                        Guest guest14 = new Guest();
                        guestInstanceHelper(guest14);
                        guest14.Location = new Point(642, 744);
                        break;
                    case 3:
                        Guest guest15 = new Guest();
                        guestInstanceHelper(guest15);
                        guest15.Location = new Point(642, 868);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "5" || this.stationCmboBox2.Text == "5" || this.stationCmboBox3.Text == "5")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest16 = new Guest();
                        guestInstanceHelper(guest16);
                        guest16.Location = new Point(987, 0); // 1010, 124
                        break;
                    case 1:
                        Guest guest17 = new Guest();
                        guestInstanceHelper(guest17);
                        guest17.Location = new Point(987, 124);
                        break;
                    case 2:
                        Guest guest18 = new Guest();
                        guestInstanceHelper(guest18);
                        guest18.Location = new Point(1599, 0);
                        break;
                    case 3:
                        Guest guest19 = new Guest();
                        guestInstanceHelper(guest19);
                        guest19.Location = new Point(1599, 124);
                        break;
                } // end switch
            } // end if
            guestCount++;
        } // end method addGuestPicBox2

        //The disablePicBox2_Click method
        //Purpose: To send disable/enable command to the given stations A/C Networking device
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void disablePicBox2_Click(object sender, EventArgs e)
        {
            //Network AC switch implementation
        } // end method disablePicBox2_Click

        //*************************************************************Begin PS4************************************************************

        //The clearPicBox3 method
        //Purpose: To create a gamer object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox3_Click(object sender, EventArgs e)
        {
            //PS4 OBJECT
            Player player14 = new Gamer("PlayStation 4", stationCmboBox3.Text, nameTxtBox3.Text, idTxtBox3.Text, titleCmboBox3.Text, ctrlCmboBox3.Text, waitingTxtBox3.Text,
                stopWatch_Custom3._currentElapsedTime.ToString());

            //Create new StreamWriter object - append text
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player14.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox3.Text = "";
            clearWaitingHelper(waitChkBox3);

            //Reset timer
            stopWatch_Custom3.resetClock();

            //Clear Guests
            guestClear(stationCmboBox3.Text);

            //Reset Combo Boxes
            titleCmboBox3.SelectedIndex = 0;
            ctrlCmboBox3.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on pS4TabPg
            clearBoxControlsHelper(this.pS4TabPg);
        } // end method clearPicBox3_Click

        //The stationCmboBox3_SelectedIndexChanged method
        //Purpose: To move the MdiChild form by calling activeMdiChildLocationHelper method
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Call helper method
            activeMdiChildLocationHelper(stationCmboBox3);
            //Change Station text in all cmboBoxes
            stationCmboBox2.Text = stationCmboBox3.Text;
            stationCmboBox.Text = stationCmboBox3.Text;
            //Move cursor to nameTxtBox
            this.ActiveControl = nameTxtBox3;
        } // end method stationCmboBox3_SelectedIndexChanged

        //The ctrlCmboBox3_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void ctrlCmboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(ctrlCmboBox3.Text) - 1);
        } // end method ctrlCmboBox3_SelectedIndexChanged

        //The waitChkBox3_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waiting nameTxtBox appear
            if (waitChkBox3.Checked == true)
                waitingTxtBox3.Visible = true;
            else
                waitingTxtBox3.Visible = false;
        } // end method waitChkBox3_CheckedChanged

        //The addGuestPicBox3 method
        //Purpose: To create an instance of the Guest class and show form
        //Parameters: The object sending the event, and the event arguments
        //Return: None
        private void addGuestPicBox3_Click(object sender, EventArgs e)
        {
            //Set location of guest forms based on player station number
            if (this.stationCmboBox.Text == "4")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest0 = new Guest();
                        guestInstanceHelper(guest0);
                        guest0.Location = new Point(472, 0);
                        break;
                    case 1:
                        Guest guest1 = new Guest();
                        guestInstanceHelper(guest1);
                        guest1.Location = new Point(472, 124);
                        break;
                    case 2:
                        Guest guest2 = new Guest();
                        guestInstanceHelper(guest2);
                        guest2.Location = new Point(642, 0);
                        break;
                    case 3:
                        Guest guest3 = new Guest();
                        guestInstanceHelper(guest3);
                        guest3.Location = new Point(642, 124);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "3" || this.stationCmboBox2.Text == "3")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest4 = new Guest();
                        guestInstanceHelper(guest4);
                        guest4.Location = new Point(472, 248);
                        break;
                    case 1:
                        Guest guest5 = new Guest();
                        guestInstanceHelper(guest5);
                        guest5.Location = new Point(472, 372);
                        break;
                    case 2:
                        Guest guest6 = new Guest();
                        guestInstanceHelper(guest6);
                        guest6.Location = new Point(642, 248);
                        break;
                    case 3:
                        Guest guest7 = new Guest();
                        guestInstanceHelper(guest7);
                        guest7.Location = new Point(642, 372);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "2")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest8 = new Guest();
                        guestInstanceHelper(guest8);
                        guest8.Location = new Point(472, 496);
                        break;
                    case 1:
                        Guest guest9 = new Guest();
                        guestInstanceHelper(guest9);
                        guest9.Location = new Point(472, 620);
                        break;
                    case 2:
                        Guest guest10 = new Guest();
                        guestInstanceHelper(guest10);
                        guest10.Location = new Point(642, 496);
                        break;
                    case 3:
                        Guest guest11 = new Guest();
                        guestInstanceHelper(guest11);
                        guest11.Location = new Point(642, 620);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "1" || this.stationCmboBox2.Text == "1")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest12 = new Guest();
                        guestInstanceHelper(guest12);
                        guest12.Location = new Point(472, 744);
                        break;
                    case 1:
                        Guest guest13 = new Guest();
                        guestInstanceHelper(guest13);
                        guest13.Location = new Point(472, 868);
                        break;
                    case 2:
                        Guest guest14 = new Guest();
                        guestInstanceHelper(guest14);
                        guest14.Location = new Point(642, 744);
                        break;
                    case 3:
                        Guest guest15 = new Guest();
                        guestInstanceHelper(guest15);
                        guest15.Location = new Point(642, 868);
                        break;
                } // end switch
            } // end if
            if (this.stationCmboBox.Text == "5" || this.stationCmboBox2.Text == "5" || this.stationCmboBox3.Text == "5")
            {
                //If the maximum number of guests have already been created, reset count
                if (guestCount == 4)
                    guestCount = 0;

                switch (guestCount)
                {
                    case 0:
                        Guest guest16 = new Guest();
                        guestInstanceHelper(guest16);
                        guest16.Location = new Point(987, 0); // 1010, 124
                        break;
                    case 1:
                        Guest guest17 = new Guest();
                        guestInstanceHelper(guest17);
                        guest17.Location = new Point(987, 124);
                        break;
                    case 2:
                        Guest guest18 = new Guest();
                        guestInstanceHelper(guest18);
                        guest18.Location = new Point(1599, 0);
                        break;
                    case 3:
                        Guest guest19 = new Guest();
                        guestInstanceHelper(guest19);
                        guest19.Location = new Point(1599, 124);
                        break;
                } // end switch
            } // end if
            guestCount++;
        } // end method addGuestPicBox3

        //The disablePicBox3_Click method
        //Purpose: To send disable/enable command to the given stations A/C Networking device
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void disablePicBox3_Click(object sender, EventArgs e)
        {
            //Network AC switch implementation
        } // end method disablePicBox3_Click

        //**********************************************************Begin Billiards*********************************************************

        //The clearPicBox4 method
        //Purpose: To create a GamingCenter object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox4_Click(object sender, EventArgs e)
        {
            //BILLIARDS OBJECT
            Player player15 = new GamingCenter(tabControl1.SelectedTab.Text, nameTxtBox4.Text, idTxtBox4.Text, stationCmboBox4.Text,
                cuesCmboBox4.Text, waitingTxtBox4.Text, stopWatch_Custom7._currentElapsedTime.ToString());

            //Create new StreamWriter object - append text
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player15.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox4.Text = "";
            clearWaitingHelper(waitChkBox4);

            //Reset timer
            stopWatch_Custom7.resetClock();

            //Reset Combo Boxes
            cuesCmboBox4.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on billiardsTabPg
            clearBoxControlsHelper(this.billiardsTabPg);
        } // end method clearPicBox4_Click

        //The stationCmboBox4_SelectedIndexChanged method
        //Purpose: To move the MdiChild form to the given station (location) on the parent form
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Move this child form to specified station location
            if (stationCmboBox4.Text == "1")
                stationOneBilliardsLocation();
            if (stationCmboBox4.Text == "2")
                stationTwoBilliardsLocation();

            this.ActiveControl = nameTxtBox4;
        } // end method stationCmboBox4_SelectedIndexChanged

        //The cuesCmboBox4_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void cuesCmboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(cuesCmboBox4.Text) - 1);
        } // end method cuesCmboBox4_SelectedIndexChanged

        //The waitChkBox4_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waiting nameTxtBox appear
            if (waitChkBox4.Checked == true)
                waitingTxtBox4.Visible = true;
            else
                waitingTxtBox4.Visible = false;
        } // end method waitChkBox4_CheckedChanged

        //**********************************************************Begin Ping-Pong*********************************************************

        //The clearPicBox5 method
        //Purpose: To create a GamingCenter object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox5_Click(object sender, EventArgs e)
        {
            //PING-PONG OBJECT
            Player player16 = new GamingCenter("Ping-Pong", nameTxtBox5.Text, idTxtBox5.Text, stationCmboBox5.Text, setsCmboBox5.Text,
                waitingTxtBox5.Text, stopWatch_Custom4._currentElapsedTime.ToString());

            //Create new StreamWriter object - append file
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player16.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox5.Text = "";
            clearWaitingHelper(waitChkBox5);

            //Reset timer
            stopWatch_Custom4.resetClock();

            //Reset Combo Boxes
            setsCmboBox5.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on pongTabPg
            clearBoxControlsHelper(this.pongTabPg);
        } // end method clearPicBox5_Click

        //The stationCmboBox5_SelectedIndexChanged method
        //Purpose: To move the MdiChild form to the given station (location) on the parent form
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Move this child form to specified station location
            if (stationCmboBox5.Text == "1")
                stationOnePongLocation();
            if (stationCmboBox5.Text == "2")
                stationTwoPongLocation();

            this.ActiveControl = nameTxtBox5;
        } // end method stationCmboBox5_SelectedIndexChanged

        //The setsCmboBox5_SelectedIndexChanged method
        //Purpose: To add additional players to totalCount in parent class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void setsCmboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Add additional controller numbers to totalCount
            //parent.incrementTotalCount(Convert.ToInt32(setsCmboBox5.Text) - 1);
        } // end method setsCmboBox5_SelectedIndexChanged

        //The waitChkBox5_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waiting nameTxtBox appear
            if (waitChkBox5.Checked == true)
                waitingTxtBox5.Visible = true;
            else
                waitingTxtBox5.Visible = false;
        } // end method waitChkBox5_CheckedChanged

        //*********************************************************Begin Air Hockey*********************************************************

        //The clearPicBox6 method
        //Purpose: To create a GamingCenter object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox6_Click(object sender, EventArgs e)
        {
            //AIR HOCKEY OBJECT
            Player player17 = new GamingCenter("Air Hockey", nameTxtBox6.Text, idTxtBox5.Text, stationCmboBox6.Text, setsCmboBox6.Text,
                waitingTxtBox6.Text, stopWatch_Custom5._currentElapsedTime.ToString());

            //Create new StreamWriter object - append file
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player17.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox6.Text = "";
            clearWaitingHelper(waitChkBox6);

            //Reset timer
            stopWatch_Custom5.resetClock();

            //Reset Combo Boxes
            setsCmboBox6.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on hockeyTabPg
            clearBoxControlsHelper(this.hockeyTabPg);
        } // end method clearPicBox6_Click

        //The stationCmboBox6_SelectedIndexChanged method
        //Purpose: To move the MdiChild form to the given station (location) on the parent form
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Move this child form to specified station location
            if (stationCmboBox6.Text == "1")
                stationOneHockeyLocation();

            this.ActiveControl = nameTxtBox6;
        } // end method stationCmboBox6_SelectedIndexChanged

        //The waitChkBox6_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox6_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waiting nameTxtBox appear
            if (waitChkBox6.Checked == true)
                waitingTxtBox6.Visible = true;
            else
                waitingTxtBox6.Visible = false;
        } // end method waitChkBox6_SelectedIndexChanged

        //**********************************************************Begin Foosball**********************************************************

        //The clearPicBox7 method
        //Purpose: To create a GamingCenter object from user input, pass data members to writeData method, and clear controls
        //Parameters: The object generating the events and the event arguments
        //Return: None
        private void clearPicBox7_Click(object sender, EventArgs e)
        {
            //FOOSBALL OBJECT
            Player player18 = new GamingCenter("Foosball", nameTxtBox7.Text, idTxtBox7.Text, stationCmboBox7.Text, ballsCmboBox7.Text,
                waitingTxtBox7.Text, stopWatch_Custom6._currentElapsedTime.ToString());

            //Create new StreamWriter object - append file
            StreamWriter outStream = new StreamWriter(filePath, true);

            //Call writeData method and pass outStream as args
            player18.writeData(outStream);

            //Close the StreamWriter object
            outStream.Close();

            //Uncheck waitChkBox to hide waitingTxtBox
            waitingTxtBox7.Text = "";
            clearWaitingHelper(waitChkBox7);

            //Reset timer
            stopWatch_Custom6.resetClock();

            //Reset Combo Boxes
            ballsCmboBox7.SelectedIndex = 0;
            //Clear textBoxes & comboBoxes on foosTabPg
            clearBoxControlsHelper(this.foosTabPg);
        } // end method clearPicBox7_Click

        //The waitChkBox7_CheckedChanged method
        //Puropse: To change the waitingTxtBox visibility based on waitChkBox state
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void waitChkBox7_CheckedChanged(object sender, EventArgs e)
        {
            //If user checks the waiting box, make waiting nameTxtBox appear
            if (waitChkBox7.Checked == true)
                waitingTxtBox7.Visible = true;
            else
                waitingTxtBox7.Visible = false;
        } // end method waitChkBox7_CheckedChanged

        //The stationCmboBox7_SelectedIndexChanged method
        //Purpose: To move the MdiChild form to the given station (location) on the parent form
        //Parameters: The object generating the event and the event arguments
        //Return: None
        private void stationCmboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create Form1 object in order to call parent method
            //Form1 parent = this.MdiParent as Form1;

            //Move this child form to specified station location
            if (stationCmboBox7.Text == "1")
                stationOneFoosLocation();

            this.ActiveControl = nameTxtBox7;
        } // end method statioCmboBox7_SelectedIndexChanged

        //***********************************************************End Foosball***********************************************************

        //The stationOneLocation method
        //Purpose: To set the location of the player form to station one
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationOneLocation()
        {
            this.Location = new Point(30, 744);
        } // end method stationOneLocation

        //The stationTwoLocation method
        //Purpose: To set the location of the player form to station two
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationTwoLocation()
        {
            this.Location = new Point(30, 496);
        } // end method stationTwoLocation

        //The stationThreeLocation method
        //Purpose: To set the location of the player form to station three
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationThreeLocation()
        {
            this.Location = new Point(30, 248);
        } // end method stationThreeLocation

        //The stationFourLocation method
        //Purpose: To set the location of the player form to station four
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationFourLocation()
        {
            this.Location = new Point(30, 0);
        } // end method stationFourLocation

        //The stationFiveLocation method
        //Purpose: To set the location of the player form to station five
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationFiveLocation()
        {
            this.Location = new Point(1157, 0);
        } // end method stationFiveLocation

        //The stationOnePongLocation method
        //Purpose: To set the location of the player form to station one - PONG
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationOnePongLocation()
        {
            this.Location = new Point(890, 248);
        } // end method stationOnePongLocation

        //The stationTwoPongLocation method
        //Purpose: To set the location of the player form to station two - PONG
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationTwoPongLocation()
        {
            this.Location = new Point(1423, 248);
        } // end method stationTwoPongLocation

        //The stationOneHockeyLocation method
        //Purpose: To set the location of the player form to station one - HOCKEY
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationOneHockeyLocation()
        {
            this.Location = new Point(890, 496);
        } // end method stationOneHockeyLocation

        //The stationOneFoosLocation method
        //Purpose: To set the location of the player form to station one - FOOS
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationOneFoosLocation()
        {
            this.Location = new Point(1423, 496);
        } // end method stationOneFoosLocation

        //The stationOneBilliardsLocation method
        //Purpose: To set the location of the player form to station one - BILLIARDS
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationOneBilliardsLocation()
        {
            this.Location = new Point(890, 744); // 913, 744
        } // end method stationOneBilliardsLocation

        //The stationTwoBilliardsLocation method
        //Purpose: To set the location of the player form to station one - BILLIARDS
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void stationTwoBilliardsLocation()
        {
            this.Location = new Point(1423, 744);
        } // end method stationTwoBilliardsLocation

    } // end class Player
}// end namespace UVU_Gaming_Center_App
