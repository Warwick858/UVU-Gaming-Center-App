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
    public partial class Form1 : Form
    {
        //Declare class variables:
        public int currentCount = 0;
        public int totalCount = 0;
        private List<Player> myPlayers = new List<Player>();

        //The Default Constructor
        //Purpose: To initialize components
        //Parameters: None
        //Return: None
        public Form1()
        {
            InitializeComponent();

            //Create 11 player forms
            //for (int i = 0; i < 11; i++)
            //{
            //    myPlayers.Add(new Player());
            //    myPlayers[i].MdiParent = this;
            //    myPlayers[i].Show();

            //    //Increment counts
            //    currentCount++;
            //    totalCount++;
            //} // end for
        } // end constructor

        //The exitToolStripMenuItem method
        //PUrpose: To close the application and terminate the program
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set flags if parent form is closing to avoid uneccessary player form error checking
            for (int i = 0; i < myPlayers.Count(); i++)
            {
                myPlayers[i].parentFormClosingFlag = true; // set flag for each player
            } // end for

            this.Close();
        } // end method exitToolStripMenuItem_Click

        //The aboutToolStripMenuItem method
        //Purpose: Display MessageBox containing strings of title, author, etc.
        //Parameters: The object generating the events, and the event arguments
        //Return: None
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Utah Valley University \nUVU Gaming Center App\nCopyright 2015, James LoForti ");
        } // end method aboutToolStripMenuItem_Click

        //The save ToolStripMenuItem method
        //Purpose: To initiate the saveAll process by sending MdiChildren to player class
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create file path
            string filePath = @"C:\Bowling Alley\UVU Gaming Center App\Data\Recent Data\Recent Data.txt";
            //Write current data to file
            Player writePlayers = new Player();
            writePlayers.saveAll(filePath, this.MdiChildren);
        } // end method saveToolStripMenuItem_Click

        //The openToolStripMenuItem method
        //Purpose: To open the most recent file write located in Recent Data
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare helpers
            List<string> data = new List<string>();
            string strHolder = "";

            //Declare Player & Guest variables:
            string game = "";
            string name = "";
            string id = "";
            string waiting = "";
            string time = "";
            string station = "";
            string title = "";
            string ctrls = "";
            string pctrls = "";
            string rctrls = "";
            string nctrls = "";
            string gctrls = "";
            string items = "";
            string guestLocation = "";
            string guestName = "";
            string guestCtrl = "";

            //Save path to recent data file
            string path = @"C:\Bowling Alley\UVU Gaming Center App\Data\Recent Data\Recent Data.txt";

            //If file does not exist
            if (!File.Exists(path))
            {
                MessageForm.Show("NO PREVIOUSLY SAVED FILES FOUND", "OK", "File Issue");
            }
            else // file exists
            {
                //Create new StreamReader using recent data file path 
                StreamReader inStream = new StreamReader(path);

                //Read while file is not null
                while (!inStream.EndOfStream)
                {
                    data.Add(inStream.ReadLine()); // add to list
                } // end while
                inStream.Close();  // close file
                File.Delete(path); // delete file

                //Search data and set values as appropriate variables
                for (int i = 0; i < data.Count(); i++)
                {
                    //Grab first label
                    strHolder = data[i].Substring(0, data[i].IndexOf(" "));

                    //Find game type
                    if (strHolder == "Game:" || strHolder == "guestLocation:") // New player or guest data is found
                    {
                        //Write previous player data  pongSets, hockeySets, balls
                        setPlayers(game, station, name, id, title, items, ctrls, pctrls, rctrls, nctrls, gctrls, waiting, time);
                        setGuests(guestLocation, guestName, guestCtrl);

                        //Reset values for next player data
                        name = "";
                        id = "";
                        waiting = "";
                        station = "";
                        title = "";
                        ctrls = "";
                        pctrls = "";
                        rctrls = "";
                        nctrls = "";
                        gctrls = "";
                        items = "";
                        guestLocation = "";
                        guestName = "";
                        guestCtrl = "";

                        //If new player, save game
                        if (strHolder == "Game:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            game = strHolder.Substring(6, strHolder.Length - 6);  //Remove label and save station data
                        } // end if

                        //If new guest, save guestLocation
                        if (strHolder == "guestLocation:")
                        {
                            strHolder = data[i];
                            guestLocation = strHolder.Substring(15, strHolder.Length - 15);
                        }// end if
                    } // end if

                    if (strHolder != "Game:") // still on current player data
                    {
                        //Find names
                        if (strHolder == "Name:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            name = strHolder.Substring(6, strHolder.Length - 6);  //Remove label and save name data
                        } // end if
                        //Find ID
                        if (strHolder == "ID:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            id = strHolder.Substring(4, strHolder.Length - 4);  //Remove label and save name data
                        } // end if
                        //Find station
                        if (strHolder == "Station:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            station = strHolder.Substring(9, strHolder.Length - 9);  //Remove label and save name data
                        } // end if
                        //Find waiting
                        if (strHolder == "Waiting:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            waiting = strHolder.Substring(9, strHolder.Length - 9);  //Remove label and save waiting data
                        } // end if
                        //Find times
                        if (strHolder == "Time:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            time = strHolder.Substring(6, strHolder.Length - 6);  //Remove label and save data
                        } // end if
                        //Find title
                        if (strHolder == "Title:")
                        {
                            strHolder = data[i]; // re-rab selected element string
                            title = strHolder.Substring(7, strHolder.Length - 7);  //Remove label and save data
                        } // end if
                        //Find ctrls
                        if (strHolder == "Controllers:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            ctrls = strHolder.Substring(13, strHolder.Length - 13);  //Remove label and save data
                        } // end if
                        //Find pctrls
                        if (strHolder == "ProCtlrs:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            pctrls = strHolder.Substring(10, strHolder.Length - 10);  //Remove label and save data
                        } // end if
                        //Find wctrls
                        if (strHolder == "WiiRemotes:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            rctrls = strHolder.Substring(12, strHolder.Length - 12);  //Remove label and save data
                        } // end if
                        //Find nctrls
                        if (strHolder == "Nunchuks:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            nctrls = strHolder.Substring(10, strHolder.Length - 10);  //Remove label and save data
                        } // end if
                        //Find gctrls
                        if (strHolder == "Gamepads:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            gctrls = strHolder.Substring(10, strHolder.Length - 10);  //Remove label and save data
                        } // end if
                        //Find sets
                        if (strHolder == "Items:") // previously sets
                        {
                            strHolder = data[i]; // re-grab selected element string
                            items = strHolder.Substring(7, strHolder.Length - 7);  //Remove label and save data
                        } // end if

                        //GUEST PORTION
                        //Find guestLocation
                        if (strHolder == "guestLocation:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            guestLocation = strHolder.Substring(15, strHolder.Length - 15);  //Remove label and save data
                        } // end if
                        //Find guestName
                        if (strHolder == "guestName:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            guestName = strHolder.Substring(11, strHolder.Length - 11);  //Remove label and save data
                        } // end if
                        //Find guestCtrl
                        if (strHolder == "guestCtrl:")
                        {
                            strHolder = data[i]; // re-grab selected element string
                            guestCtrl = strHolder.Substring(11, strHolder.Length - 11);  //Remove label and save data
                        } // end if
                    } // end if
                } // end for

                //Write Last Cycle through  pongSets, hockeySets, balls, cues
                setPlayers(game, station, name, id, title, items, ctrls, pctrls, rctrls, nctrls, gctrls, waiting, time);
                setGuests(guestLocation, guestName, guestCtrl);

            } // end else
        } // end method openToolStripMenuItem_Click  // , string hockeySets, string balls, string cues

        //The setPlayers method
        //Purpose: To select the appropriate show method based on game label
        //Parameters: Strings representing player data
        //Return: None
        private void setPlayers(string game, string station, string name, string id, string title, string items, string ctrls, string pctrls,
            string rctrls, string nctrls, string gctrls, string waiting, string time)
        {
            //Set time to 00:00:00 if null
            if (time == "")
                time = "00:00:00";
            //Check to make sure there is data (avoids writing first cycle through)
            if (name != "")
            {
                //Set player forms
                if (game == "XBOX One") { showStationXbox(station, name, id, title, ctrls, waiting, time); } // end if
                if (game == "Wii U") { showStationWii(station, name, id, title, pctrls, rctrls, nctrls, gctrls, waiting, time); } // end if
                if (game == "PlayStation 4") { showStationPS4(station, name, id, title, ctrls, waiting, time); } // end if
                if (game == "Ping-Pong") { showStationPong(station, name, id, title, items, waiting, time); } // end if
                if (game == "Air Hockey") { showStationHockey(station, name, id, title, items, waiting, time); } // end if
                if (game == "Foosball") { showStationFoos(station, name, id, title, items, waiting, time); } // end if
                if (game == "Billiards") { showStationBilliards(station, name, id, title, items, waiting, time); } // end if
            } // end if
        } // end method setPlayers

        //The setGuests method
        //Purpose: To show the guest form using the given data
        //Parameters: 3 strings that represent guest data
        //Return: None
        private void setGuests(string _guestLocation, string _guestName, string _guestCtrl)
        {
            if (_guestLocation != "") // make sure there's data
            {
                //Take _guestLocation string and split coordinates
                string[] coords = _guestLocation.Split(','); // {X=400,Y=50}
                coords[0] = coords[0].Remove(0, 3); // {X=400 becomes 400
                coords[1] = coords[1].Remove(0, 2); // Y=50} becomes 50}
                coords[1] = coords[1].Remove(coords[1].Length - 1, 1); // 50} becomes 50

                //Show and set data
                Guest guest = new Guest();
                guest.MdiParent = this;
                guest.Show();
                guest.Location = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                guest.guestNameTxtBox.Text = _guestName;
                guest.guestCtrlCmboBox.Text = _guestCtrl;
            } // end if
        } // end method setGuests

        //The showStationXbox method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationXbox(string _station, string _name, string _id, string _title, string _ctrls, string _waiting, string _time)
        {
            Player xbox = new Player();
            addToPlayerList(xbox); // add to list and show
            xbox.stationFiveLocation();
            xbox.tabControl1.SelectedIndex = 0;
            xbox.stationCmboBox.Text = _station;
            xbox.nameTxtBox.Text = _name;
            xbox.idTxtBox.Text = _id;
            xbox.titleCmboBox.Text = _title;
            xbox.ctrlCmboBox.Text = _ctrls;
            if (_waiting != "") // only show waiting if not null
            {
                xbox.waitChkBox.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                xbox.waitingTxtBox.Text = _waiting;
            } // end if
            xbox.stopWatch_Custom1._currentElapsedTime = TimeSpan.Parse(_time);
            xbox.stopWatch_Custom1.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method showStationXbox

        //The showStationWii method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationWii(string _station, string _name, string _id, string _title, string _pctrls, string _rctrls, string _nctrls, string _gctrls, string _waiting, string _time)
        {
            Player wii = new Player();
            addToPlayerList(wii); // add to list and show
            wii.stationFiveLocation();
            wii.tabControl1.SelectedIndex = 1;
            wii.stationCmboBox2.Text = _station;
            wii.nameTxtBox2.Text = _name;
            wii.idTxtBox2.Text = _id;
            wii.titleCmboBox2.Text = _title;
            wii.pctrlCmboBox.Text = _pctrls;
            wii.rctrlCmboBox.Text = _rctrls;
            wii.nctrlCmboBox.Text = _nctrls;
            wii.gctrlCmboBox.Text = _gctrls;
            if (_waiting != "") // only show waiting if not null
            {
                wii.waitChkBox2.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                wii.waitingTxtBox2.Text = _waiting;
            } // end if
            wii.stopWatch_Custom2._currentElapsedTime = TimeSpan.Parse(_time);
            wii.stopWatch_Custom2.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method showStationWii

        //The showStationPS4 method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationPS4(string _station, string _name, string _id, string _title, string _ctrls, string _waiting, string _time)
        {
            Player pS4 = new Player();
            addToPlayerList(pS4); // add to list and show
            pS4.stationFiveLocation();
            pS4.tabControl1.SelectedIndex = 2;
            pS4.stationCmboBox3.Text = _station;
            pS4.nameTxtBox3.Text = _name;
            pS4.idTxtBox3.Text = _id;
            pS4.titleCmboBox3.Text = _title;
            pS4.ctrlCmboBox3.Text = _ctrls;
            if (_waiting != "") // only show waiting if not null
            {
                pS4.waitChkBox3.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                pS4.waitingTxtBox3.Text = _waiting;
            } // end if
            pS4.stopWatch_Custom3._currentElapsedTime = TimeSpan.Parse(_time);
            pS4.stopWatch_Custom3.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method showStationPS4

        //The showStationPong method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationPong(string _station, string _name, string _id, string _title, string _ctrls, string _waiting, string _time)
        {
            Player pong = new Player();
            addToPlayerList(pong); // add to list and show
            pong.stationFiveLocation();
            pong.tabControl1.SelectedIndex = 3;
            pong.stationCmboBox5.Text = _station;
            pong.nameTxtBox5.Text = _name;
            pong.idTxtBox5.Text = _id;
            pong.setsCmboBox5.Text = _ctrls;
            if (_waiting != "") // only show waiting if not null
            {
                pong.waitChkBox5.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                pong.waitingTxtBox5.Text = _waiting;
            } // end if
            pong.stopWatch_Custom4._currentElapsedTime = TimeSpan.Parse(_time);
            pong.stopWatch_Custom4.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method showStationPong

        //The showStationHockey method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationHockey(string _station, string _name, string _id, string _title, string _ctrls, string _waiting, string _time)
        {
            Player hockey = new Player();
            addToPlayerList(hockey); // add to list and show
            hockey.stationFiveLocation();
            hockey.tabControl1.SelectedIndex = 4;
            hockey.stationCmboBox6.Text = _station;
            hockey.nameTxtBox6.Text = _name;
            hockey.idTxtBox6.Text = _id;
            hockey.setsCmboBox6.Text = _ctrls;
            if (_waiting != "") // only show waiting if not null
            {
                hockey.waitChkBox6.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                hockey.waitingTxtBox6.Text = _waiting;
            } // end if
            hockey.stopWatch_Custom5._currentElapsedTime = TimeSpan.Parse(_time);
            hockey.stopWatch_Custom5.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method showStationHockey

        //The showStationFoos method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationFoos(string _station, string _name, string _id, string _title, string _ctrls, string _waiting, string _time)
        {
            Player foos = new Player();
            addToPlayerList(foos); // add to list and show
            foos.stationFiveLocation();
            foos.tabControl1.SelectedIndex = 5;
            foos.stationCmboBox7.Text = _station;
            foos.nameTxtBox7.Text = _name;
            foos.idTxtBox7.Text = _id;
            foos.ballsCmboBox7.Text = _ctrls;
            if (_waiting != "") // only show waiting if not null
            {
                foos.waitChkBox7.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                foos.waitingTxtBox7.Text = _waiting;
            } // end if
            foos.stopWatch_Custom6._currentElapsedTime = TimeSpan.Parse(_time);
            foos.stopWatch_Custom6.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method showStationFoos

        //The showStationBilliards method
        //Purpose: To show a player object and set the given data
        //Parameters: 6 strings which represent the players data to set
        //Return: None
        private void showStationBilliards(string _station, string _name, string _id, string _title, string _ctrls, string _waiting, string _time)
        {
            Player billiard = new Player();
            addToPlayerList(billiard); // add to list and show
            billiard.stationFiveLocation();
            billiard.tabControl1.SelectedIndex = 6;
            billiard.stationCmboBox4.Text = _station;
            billiard.nameTxtBox4.Text = _name;
            billiard.cuesCmboBox4.Text = _ctrls;
            if (_waiting != "") // only show waiting if not null
            {
                billiard.waitChkBox4.Checked = true;
                //xbox5.waitingTxtBox.Visible = true;
                billiard.waitingTxtBox4.Text = _waiting;
            } // end if
            billiard.stopWatch_Custom7._currentElapsedTime = TimeSpan.Parse(_time);
            billiard.stopWatch_Custom7.startPicBox_Click(null, EventArgs.Empty); // start timer
        } // end method howStationBilliards

        //The addToPlayerList method
        //Purpose: To add the given player to the myPlayers list, set its parent, and show
        //Parameters: A Player object, represented as _player
        //Return: None
        private void addToPlayerList(Player _player)
        {
            myPlayers.Add(_player);
            _player.MdiParent = this;
            _player.Show();
        } // end method addToPlayerList

        //The windowsMenuItem_Click method
        //Purpose: To display a list of active player windows to select from
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.MdiWindowListItem = windowsToolStripMenuItem;
        } // end method windowsToolStripMenuItem_Click

        //The bookingMenuItem_Click method
        //Purpose: To open the primary reservations document located on the C: drive
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Bowling Alley\Bowling Alley & Gaming Center Reservation Form.xlsx";  // save file path
            var fileInfo = new FileInfo(path);  // create FileInfo using path
            if (!fileInfo.Exists)  // if file not found
            {
                MessageForm.Show("RESERVATION SHEET NOT FOUND", "OK", "File Issue");
            }
            else  // if exists, open
                System.Diagnostics.Process.Start(path);
        } // end method bookingToolStripMenuItem_Click

        //The signageMenuItem_Click method
        //Purpose: To open the reservation sign template located on the C: drive
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void signageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Bowling Alley\Bowling Alley Reservation Signage Template.docx";  // save file path
            var fileInfo = new FileInfo(path);  //create FileInfo using path
            if (!fileInfo.Exists)  // if file not found
            {
                MessageForm.Show("SIGNAGE TEMPLATE NOT FOUND", "OK", "File Issue");
            }
            else  // if exists, open
                System.Diagnostics.Process.Start(path);
        } // end method signageToolStripMenuItem_Click

        //The confirmationMenuItem_Click method
        //Purpose: To open the reservation invoice template located on the C: drive
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void confirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Bowling Alley\Event Receipts & Confirmations\Event Confirmation Template.docx";  // save file path
            var fileInfo = new FileInfo(path); // create FileInfo using path
            if (!fileInfo.Exists)  // if file not found
            {
                MessageForm.Show("CONFIRMATION TEMPLATE NOT FOUND", "OK", "File Issue");
            }
            else  // if exists, open
                System.Diagnostics.Process.Start(path);
        } // end method confirmationToolStripMenuItem_Click

        //The receiptMenuItem_Click method
        //Purpose: To open the reservation receipt template located on the C: drive
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"C:\Bowling Alley\Event Receipts & Confirmations\Event Receipt Template.docx";  // save file path
            var fileInfo = new FileInfo(path);  // create FileInfo using path
            if (!fileInfo.Exists)  // if file not found
            {
                MessageForm.Show("RECEIPT TEMPLATE NOT FOUND", "OK", "File Issue");
            }
            else  // if exists, open
                System.Diagnostics.Process.Start(path);
        } // end method receiptToolStripMenuItem_Click

        //The sLWCWebsiteMenuItem_Click method
        //Purpose: To open the Student Life & Wellness Center Website
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void sLWCWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.uvu.edu/slwc/");
        } // end method sLWCWebsiteToolStripMenuItem_Click

        //The gamingDiagramMenuItem_Click method
        //Purpose: To open the gaming diagram located on the C: drive
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void gamingDiagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save file path
            string path = @"C:\Bowling Alley\Gaming Diagram.jpg";
            var fileInfo = new FileInfo(path);  // create FileInfo using path
            if (!fileInfo.Exists)  // if file not found
            {
                MessageForm.Show("GAMING DIAGRAM NOT FOUND", "OK", "File Issue");
            }
            else  // if exists, open
                System.Diagnostics.Process.Start(path);
        } // end method gamingDiagramToolStripMenuItem_Click

        //The youTubePlayListsMenuItem_Click method
        //Purpose: To open YouTube.com/playlists
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void youTubePlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com");

            //Give user login info for UVU youtube account
            MessageForm msgForm = new MessageForm();  // create new instance of MessageForm
            MessageForm.Show("YouTube Login Info \n•Email: uvuwilly@gmail.com \n•Password: wolverine1941", "OK", "Credentials");  // pass args to Show method
        } // end method youTubePlaylistsToolStripMenuItem_Click

        //The statsFormToolStripMenuItem_Click method
        //Purpose: To display the statistics form
        //Parameters: The object generating the event, and the event, arguments
        //Return: None
        private void statsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stats stats = new Stats();
            stats.Show();
        } // end method statsFormToolStripMenuItem_Click

        //The getCurrentCount method
        //Purpose: To return the value of currentCount
        //Parameters: None
        //Return: currentCount in the form of an integer
        public int getCurrentCount()
        {
            return currentCount;
        } // end method getCurrentCount

        //The incrementCurrentCount method
        //Purpose: To increment the value of currentCount
        //Parameters: None
        //Return: None
        public void incrementCurrentCount()
        {
            currentCount++;
        } // end method incrementCurrentCount

        //The decrementCurrentCount method
        //Purpose: To decrement the value of currentCount
        //Parameters: None
        //Return: None
        public void decrementCurrentCount()
        {
            currentCount--;
        } // end method decrementCurrentCount

        //The incrementTotalCount method
        //Purpose: To add players to the totalCount
        //Parameters: An int represented as _additionalPlayers
        //Return: None
        public void incrementTotalCount(int _additionalPlayers)
        {
            totalCount += _additionalPlayers;
        } // end method incrementTotalCount

        //The getCurrTime method
        //Purpose: To return the current time
        //Parameters: None
        //Return: currTime in the form of a string
        public string getCurrTime()
        {
            string currTime = DateTime.Now.ToShortTimeString();
            return currTime;
        } // end method getCurrTime

        ////The MDIChildActivate method
        ////Purpose: 
        ////Parameters: The object generating the event and the event arguments
        ////Return: None
        //private void Form1_MdiChildActivate(object sender, EventArgs e)
        //{
        //    //count++;
        //} // end method Form1_MdiChildActivate

        //The timer2_Tick method
        //Purpose: TO display the current time on the status strip
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Display current time and date on menu
            this.timeMenuLbl.Text = DateTime.Now.ToLongTimeString();
            this.dateMenuLbl.Text = DateTime.Now.ToLongDateString();

            //Display total number of players (this session) on menu
            //this.totalPlayersMenuLbl.Text = totalCount.ToString();

            //Create helper TimeSpan
            TimeSpan maxTime = new TimeSpan(00, 40, 00);
            TimeSpan minTime = new TimeSpan(00, 00, 01);
            //Change Player form color to red if player's time is up
            foreach (Player player in myPlayers)
            {
                //Change form backColor to red if greater than 40 mins
                if (player.stopWatch_Custom1._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                if (player.stopWatch_Custom2._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                if (player.stopWatch_Custom3._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                if (player.stopWatch_Custom4._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                if (player.stopWatch_Custom5._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                if (player.stopWatch_Custom6._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                if (player.stopWatch_Custom7._currentElapsedTime >= maxTime)
                    player.BackColor = System.Drawing.Color.Red;
                //Change form backColor to green if time has been started
                if (player.stopWatch_Custom1._currentElapsedTime >= minTime && player.stopWatch_Custom1._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
                if (player.stopWatch_Custom2._currentElapsedTime >= minTime && player.stopWatch_Custom2._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
                if (player.stopWatch_Custom3._currentElapsedTime >= minTime && player.stopWatch_Custom3._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
                if (player.stopWatch_Custom4._currentElapsedTime >= minTime && player.stopWatch_Custom4._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
                if (player.stopWatch_Custom5._currentElapsedTime >= minTime && player.stopWatch_Custom5._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
                if (player.stopWatch_Custom6._currentElapsedTime >= minTime && player.stopWatch_Custom6._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
                if (player.stopWatch_Custom7._currentElapsedTime >= minTime && player.stopWatch_Custom7._currentElapsedTime < maxTime)
                    player.BackColor = System.Drawing.Color.Lime;
            } // end foreach

            ////PROGRESS BAR
            //if (progressBar.Value < progressBar.Maximum)
            //    progressBar.Increment(5);
            //else
            //    progressBar.Value = progressBar.Minimum;
        } // end method timer2_Tick

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ////Set flags if parent form is closing to avoid uneccessary player form error checking
            for (int i = 0; i < myPlayers.Count(); i++)
            {
                myPlayers[i].parentFormClosingFlag = true;
            } // end for
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Set flags if parent form is closing to avoid uneccessary player form error checking
            for (int i = 0; i < myPlayers.Count(); i++)
            {
                myPlayers[i].parentFormClosingFlag = true;
            } // end for

            for (int i = 0; i < myPlayers.Count(); i++)
            {
                myPlayers[i].Close();
            } // end for
        } // end method Form1_FormClosed

        private void lineUpBtn_Click(object sender, EventArgs e)
        {
            //Create 11 player forms
            for (int i = 0; i < 11; i++)
            {
                myPlayers.Add(new Player());
                myPlayers[i].MdiParent = this;
                myPlayers[i].Show();

                //Increment counts
                currentCount++;
                totalCount++;
            } // end for
        } // end method lineUpBtn_Click()

        //The rackBtn_Click method
        //Purpose: To send the player forms to the appropriate location points, and change their station comboBoxes
        //Parameters: The object sending the event, and the event arguments
        //Return: None
        private void rackBtn_Click(object sender, EventArgs e)
        {
            //Ensure players EXIST
            if (myPlayers.Count == 11)
            {
                //Change player form locations, and station cmboBox text
                Player plyr = new Player();
                plyr.changeStnCmboBoxes(myPlayers);
            } // end if
            else // players do NOT exist
            {
                //Prompt user to click "line-up" button first
                MessageForm.Show("NO PLAYERS EXIST!  CLICK LINE-UP BUTTON FIRST SILLY", "OK", "No Players To Rack");
            } // end else

        } // end method rackBtn_Click

        //The playerToolStripMenuItem_Click method
        //Purpose: To add a new player form
        //Parameters: The object sending the event, and the event arguments
        //Return: None
        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add player to list
            myPlayers.Add(new Player());
            myPlayers[myPlayers.Count() - 1].MdiParent = this;
            myPlayers[myPlayers.Count() - 1].Show();
            //Increment counts
            currentCount++;
            totalCount++;
        } // end method playerToolStripMenuItem_Click



    } // end class Form1
} // end namespace UVU_Gaming_Center_App