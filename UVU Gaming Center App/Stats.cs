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
    public partial class Stats : Form
    {
        //Declare constants
        const int NEG_EIGHT = -8;
        const int FIFTEEN = 15;
        const int NEG_TWENTY = -20;
        const int AVG_MONTH = 30;

        //Declare TimeSpans:
        static private TimeSpan twentyFourHours = new TimeSpan(24, 00, 00);

        //Declare DateTimes
        //Today
        static private DateTime todayDT = DateTime.Now;  //  m/dd/yyy hh:mm:ss
        private string today = DateTime.Now.ToString("MM/dd/yyyy");  // mm/dd/yyy
        //Yesterday
        static private DateTime yesterdayDT = todayDT.Subtract(twentyFourHours);
        static private string yesterday = yesterdayDT.ToString("MM/dd/yyyy");
        //StartOfWeek -- Monday
        static private DayOfWeek monday = DayOfWeek.Monday;
        //EndOfWeek -- Saturday
        static private DayOfWeek saturday = DayOfWeek.Saturday;
        //Decalre From-To Calendar Dates
        DateTime fromClndrDate;
        DateTime toClndrDate;

        //Declare Semester DateTimes
        static private DateTime fallStart = new DateTime(todayDT.Year, 08, 24);
        static private DateTime fallEnd = new DateTime(todayDT.Year, 01, 03);
        static private DateTime springStart = new DateTime(todayDT.Year, 01, 04);
        static private DateTime springEnd = new DateTime(todayDT.Year, 05, 02);
        static private DateTime summerStart = new DateTime(todayDT.Year, 05, 03);
        static private DateTime summerEnd = new DateTime(todayDT.Year, 08, 23);

        public Stats()
        {
            InitializeComponent();
        }

        //The getStartOfWeek method
        //Purpose: To find the first day of the week (Monday), and return its date
        //Parameters: A DateTime represented as _centeredDT
        //Return: startOfWeek in the form of a string
        private string getStartOfWeek(DateTime _centeredDT)
        {
            //Subtract monday from the current day of the week
            int diffInDays = _centeredDT.DayOfWeek - monday; // today.Saturday = 5
            //Add 7 to diffInDays, only if today is Sunday (before start of week)
            if (diffInDays < 0)
                diffInDays += 7;

            return _centeredDT.AddDays(-1 * diffInDays).Date.ToString("MM/dd/yyyy");
        } // end method getStartOfWeek

        //The getEndOfWeek method
        //Purpose: To find the last day of the week, and return the date
        //Parameters: A DateTime represented as _centeredDT
        //Return: endOfWeek in the form of a string
        private string getEndOfWeek(DateTime _centeredDT)
        {
            //Subtract saturday from the current day of the week
            int diffInDays = _centeredDT.DayOfWeek - saturday; // today.Monday = 2

            return _centeredDT.AddDays(-1 * diffInDays).Date.ToString("MM/dd/yyyy");
        } // end method getEndOfWeek

        //The getLastWeek method
        //Purpose: To return the DateTime of 8 days prior to today
        //Parameters: None
        //Return: lastWeek in the form of a DateTime
        private DateTime getLastWeek()
        {
            DateTime lastWeek = todayDT.AddDays(NEG_EIGHT);
            return lastWeek;
        } // end method getLastWeek

        //The getLastMonth method
        //Purpose: To return a DateTime from last month
        //Parameters: None
        //Return: lastMonth in the form of a DateTime
        private DateTime getLastMonth()
        {
            //Declare DateTime to help with assignments
            DateTime lastMonth;

            //If the current day is less than the 15th, subtract 20 days
            if (todayDT.Day < FIFTEEN)
                lastMonth = todayDT.AddDays(NEG_TWENTY);
            else // subtract 31 days
                lastMonth = todayDT.AddDays(-1 * AVG_MONTH - 1);

            return lastMonth;
        } // end method getLastMonth

        //The getStartOfMonth method
        //Purpose: To return the ShortStringDate of the first day of the current month
        //Parameters: A DateTime represented as _centeredDT
        //Return: startOfMonth in the form of a string
        private string getStartOfMonth(DateTime _centeredDT)
        {
            //Create DateTime that represents the first day of the month
            DateTime startOfMonthDT = new DateTime(_centeredDT.Year, _centeredDT.Month, 01);
            string startOfMonth = startOfMonthDT.ToString("MM/dd/yyyy"); // format as string

            return startOfMonth;
        } // end method getStartOfMonth

        //The getEndOfMonth method
        //Purpose: To return the ShortStringDate of the last day of the current month
        //Parameters: A DateTime represented as _centeredDT
        //Return: endOfMonth in the form of a string
        private string getEndOfMonth(DateTime _centeredDT)
        {
            //Create DateTime that represents the last day of the month
            DateTime endOfMonthDT = new DateTime(_centeredDT.Year, _centeredDT.Month, DateTime.DaysInMonth(_centeredDT.Year, _centeredDT.Month));
            string endOfMonth = endOfMonthDT.ToString("MM/dd/yyyy"); // format as string

            return endOfMonth;
        } // end method getEndOfMonth

        //The getStartOfSemester method
        //Purpose: To return the start date of the given semester
        //Parameters: A DateTime represented as _centeredDT
        //Return: startOfSemester in the form of a string
        private string getStartOfSemester(DateTime _centeredDT)
        {
            if (_centeredDT >= fallStart && _centeredDT <= fallEnd)
                return fallStart.ToString("MM/dd/yyyy");
            if (_centeredDT >= springStart && _centeredDT <= springEnd)
                return springStart.ToString("MM/dd/yyyy");
            if (_centeredDT >= summerStart && _centeredDT <= summerEnd)
                return summerStart.ToString("MM/dd/yyyy");
            else
            {
                MessageForm.Show("DATES ARE NOT WITHIN A SEMESTER", "OK", "Criteria Error");  // pass args to Show method
                return "";
            } // end else
        } // end method getStartOfSemester

        //The getEndOfSemester method
        //Purpose: To return the end date of the given semester
        //Parameters: A DateTime represented as _centeredDT
        //Return: startOfSemester in the form of a string
        private string getEndOfSemester(DateTime _centeredDT)
        {
            if (_centeredDT >= fallStart && _centeredDT <= fallEnd)
                return fallEnd.ToString("MM/dd/yyyy");
            if (_centeredDT >= springStart && _centeredDT <= springEnd)
                return springEnd.ToString("MM/dd/yyyy");
            if (_centeredDT >= summerStart && _centeredDT <= summerEnd)
                return summerEnd.ToString("MM/dd/yyyy");
            else
            {
                MessageForm.Show("DATES ARE NOT WITHIN A SEMESTER", "OK", "Criteria Error");  // pass args to Show method
                return "";
            } // end else
        } // end method getEndOfSemester

        //The getStartOflastSemester method
        //Purpose: To return the end date of the last semester
        //Parameters: A DateTime represented as _centeredDT
        //Return: startOfSemester in the form of a string
        private string getStartOfLastSemester(DateTime _centeredDT)
        {
            if (_centeredDT >= fallStart && _centeredDT <= fallEnd)
                return summerStart.ToString("MM/dd/yyyy");
            if (_centeredDT >= springStart && _centeredDT <= springEnd)
                return fallStart.ToString("MM/dd/yyyy");
            if (_centeredDT >= summerStart && _centeredDT <= summerEnd)
                return springStart.ToString("MM/dd/yyyy");
            else
            {
                MessageForm.Show("DATES ARE NOT WITHIN A SEMESTER", "OK", "Criteria Error");  // pass args to Show method
                return "";
            } // end else
        } // end method getStartOfLastSemester

        //The getEndOflastSemester method
        //Purpose: To return the end date of the last semester
        //Parameters: A DateTime represented as _centeredDT
        //Return: startOfSemester in the form of a string
        private string getEndOfLastSemester(DateTime _centeredDT)
        {
            if (_centeredDT >= fallStart && _centeredDT <= fallEnd)
                return summerEnd.ToString("MM/dd/yyyy");
            if (_centeredDT >= springStart && _centeredDT <= springEnd)
                return fallEnd.ToString("MM/dd/yyyy");
            if (_centeredDT >= summerStart && _centeredDT <= summerEnd)
                return springEnd.ToString("MM/dd/yyyy");
            else
            {
                MessageForm.Show("DATES ARE NOT WITHIN A SEMESTER", "OK", "Criteria Error");  // pass args to Show method
                return "";
            } // end else
        } // end method getEndOfLastSemester

        //The searchPicBox_Click method
        //Purpose: To call the associated functions that search for data
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void searchPicBox_Click(object sender, EventArgs e)
        {
            clearResults();
            evaluateShortCut();
        } // end method searchPicBoc_Click

        //The evaluateShortCut method
        //Purpose: To determine which shortcut radio button is selected
        //Parameters: None
        //Return: None
        private void evaluateShortCut()
        {
            //Determines which radio btn is selected      --- EXCEPTION WHEN NO RADIO BUTTON IS SELECTED
            RadioButton checkedRBtn = radioPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            if (checkedRBtn != null)
            {
                //Determine checked radioBtn and call corresponding data method
                if (checkedRBtn.Text == "Today")
                    getTodaysData();
                if (checkedRBtn.Text == "Yesterday")
                    getYesterdaysData();
                if (checkedRBtn.Text == "This Week")
                    getThisWeeksData();
                if (checkedRBtn.Text == "Last Week")
                    getLastWeeksData();
                if (checkedRBtn.Text == "This Month")
                    getThisMonthsData();
                if (checkedRBtn.Text == "Last Month")
                    getLastMonthsData();
                if (checkedRBtn.Text == "This Semester")
                    getThisSemestersData();
                if (checkedRBtn.Text == "Last Semester")
                    getLastSemestersData();
            } // end if
            else  // if radioBtn is not checked, pull search dates from calendar txtBoxes
            {
                DateTime fromDT = DateTime.Parse(fromTxtBox.Text);
                DateTime toDT = DateTime.Parse(toTxtBox.Text);
                searchDirectory(fromDT.ToString("MM/dd/yyyy"), toDT.ToString("MM/dd/yyyy"));
            } // end else
        } // end method evaluateShortCut

        //The getTodaysData method
        //Purpose: To call the searchDirectory() and pass today's date as to, from args
        //Parameters: None
        //Return: None
        private void getTodaysData()
        {
            searchDirectory(today, today);
        } // end method getTodaysData

        //The getYesterdaysData method
        //Purpose: To call the searchDirectory() and pass yesterday's date as to, from args
        //Parameters: None
        //Return: None
        private void getYesterdaysData()
        {
            searchDirectory(yesterday, yesterday);
        } // end method getYesterdaysData

        //The getThisWeeksData method
        //Purpose: To call the searchDirectory() and pass this weeks dates as to, from args
        //Parameters: None
        //Return: None
        private void getThisWeeksData()
        {
            searchDirectory(getStartOfWeek(todayDT), getEndOfWeek(todayDT));
        } // end method getThisWeeksData

        //The getLastWeeksData method
        //Purpose: To call the searchDirectory() and pass last weeks dates as to, from args
        //Parameters: None
        //Return: None
        private void getLastWeeksData()
        {
            searchDirectory(getStartOfWeek(getLastWeek()), getEndOfWeek(getLastWeek()));
        } // end method getLastWeeksData

        //The getThisMonthsData method
        //Purpose: To call the searchDirectory() and pass this months dates as to, from args
        //Parameters: None
        //Return: None
        private void getThisMonthsData()
        {
            searchDirectory(getStartOfMonth(todayDT), getEndOfMonth(todayDT));
        } // end method getThisMonthsData

        //The getLastMonthsData method
        //Purpose: To call the searchDirectory() and pass last months dates as to, from args
        //Parameters: None
        //Return: None
        private void getLastMonthsData()
        {
            searchDirectory(getStartOfMonth(getLastMonth()), getEndOfMonth(getLastMonth()));
        } // end method getLastMonthsData

        //The getThisSemestersData method
        //Purpose: To call the searchDirectory() and pass this semesters dates as to, from args
        //Parameters: None
        //Return: None
        private void getThisSemestersData()
        {
            searchDirectory(getStartOfSemester(todayDT), getEndOfSemester(todayDT));
        } // end method getThisSemestersData

        //The getLastSemestersData method
        //Purpose: To call the searchDirectory() and pass last semesters dates as to, from args
        //Parameters: None
        //Return: None
        private void getLastSemestersData()
        {
            searchDirectory(getStartOfLastSemester(todayDT), getEndOfLastSemester(todayDT));
        } // end method getLastSemestersData

        //The searchDirectory method
        //Purpose: To search the data directory for the requested files, based on to-from args
        //Parameters: Two strings, represented as _to, _from
        //Return: None
        private void searchDirectory(string _from, string _to)
        {
            //Declare helpers
            List<string> fileRange = new List<string>();
            List<DateTime> myDTs = new List<DateTime>();
            DateTime fromDT = DateTime.Parse(_from);
            DateTime toDT = DateTime.Parse(_to);
            DateTime fileDT = new DateTime();

            //Send search range to label
            currSearchCritLbl.Text = _from + " - " + _to;

            //Create path of directory which holds data files
            string dirPath = @"C:\Bowling Alley\UVU Gaming Center App\Data";

            //Get all file names in dirPath directory and store in an array of strings
            string[] fileNames = Directory.GetFiles(dirPath);

            //Index through each file name, reformat it, and check against desired search criteria
            for (int i = 0; i < fileNames.Length; i++)
            {
                //String before this line: C:\\Bowling Alley\\UVU Gaming Center App\\Data\\6.20.2015.txt
                string fileName = fileNames[i].Remove(0, 44);  // remove file path

                //String before this line: 06.20.2015.txt
                fileName = fileName.Remove(10, 4); // remove .txt file extension
                //New trimmedFile = 06.20.2015

                //Replace all '/' with '.'  ---- Note: File naming conventions in NotePad restrict '/'
                fileName = fileName.Replace('.', '/');

                //Save fileName as DateTime
                fileDT = DateTime.Parse(fileName);

                //Parse fileName as DT and add to list
                if (fileDT >= fromDT && fileDT <= toDT)
                    fileRange.Add(fileNames[i]);
            } // end for

            //If no files within range
            if (fileRange.Count() == 0)
            {
                clearResults(); // clear stats results
                MessageForm.Show("NO DATA WITHIN GIVEN SEARCH CRITERIA", "OK", "File Issue");  // pass args to Show method
            }
            else // read data from files within range
                readDate(fileRange);
        } // end method searchDirectory

        //The defineFileRange method
        //Purpose: To define the range of files needed based on lastWriteTimes
        //Parameters: 2 strings, represented as searchArg1, searchArg2
        //Return: None
        private void defineFileRange(string _searchArg1, string _searchArg2)
        {
            //File.Exists(_searchArg1) && File.Exists(_searchArg2)
            if (_searchArg1 != "" && _searchArg2 != "") // Check to ensure file exists
            {
                //Get DateTimes of searchArgs
                DateTime startDate = File.GetLastWriteTime(_searchArg1);
                DateTime endDate = File.GetLastWriteTime(_searchArg2);

                //Create path of directory which holds data files
                string dirPath = @"C:\Bowling Alley\UVU Gaming Center App\Data";

                //Get all file names in dirPath directory and store in an array of strings
                string[] fileNames = Directory.GetFiles(dirPath);

                //Create list to hold fileRange
                List<string> fileRange = new List<string>();

                //Index through each file name and check against desired search criteria
                for (int i = 0; i < fileNames.Length; i++)
                {
                    //If file falls between searchArgs, save to array
                    DateTime writeTime = File.GetLastWriteTime(fileNames[i]);

                    if (writeTime >= startDate && writeTime <= endDate)
                        fileRange.Add(fileNames[i]);
                } // end for

                //Pass fileRange array to readData method
                readDate(fileRange);
            } // end if
            else // else file does not exist
            {
                clearResults(); // clear stats results
                MessageForm.Show("NO DATA WITHIN GIVEN SEARCH CRITERIA", "OK", "File Issue");  // pass args to Show method
            } // end else
        } // end method defineFileRange

        //The readDate method
        //Purpose: To read all file in fileRange and fill array
        //Parameters: A string list represented as _fileRange
        //Return: None
        private void readDate(List<string> _fileRange)
        {
            //Create new StreamReader
            StreamReader inStream = null;

            //Create Lists to store file data and dataLists
            List<string> data = new List<string>();

            //Increment through each file
            for (int i = 0; i < _fileRange.Count(); i++)
            {
                //Create new StreamReader
                inStream = new StreamReader(_fileRange[i]);

                //Read while file is not null
                while (!inStream.EndOfStream)
                {
                    data.Add(inStream.ReadLine());
                } // end while
            } // end for
         
            //Pass data array to query
            dataQuery(data);
        } // end method readDate

        //The dataQuery method
        //Purpose: To query the file data for the desired criteria
        //Parameters: A string array represented as _data
        //Return: None
        private void dataQuery(List<string> _data)
        {
            //Declare helpers
            string strHolder = "";
            int itemTotal = 0;
            int billiardPlayers = 0;
            int pongPlayers = 0;
            int hockeyPlayers = 0;
            int foosPlayers = 0;
            List<string> times = new List<string>();
            List<string> names = new List<string>();
            List<string> games = new List<string>();
            List<int> items = new List<int>();
            List<string> billiardTimes = new List<string>();
            List<string> pongTimes = new List<string>();
            List<string> hockeyTimes = new List<string>();
            List<string> foosTimes = new List<string>();

            //Increment through data array and test each element for below game types
            for (int i = 0; i < _data.Count(); i++)
            {
                //Take first word of element and save as strHolder
                strHolder = _data[i].Substring(0, _data[i].IndexOf(" "));

                //Add times
                if (strHolder == "Time:")
                {
                    strHolder = _data[i];
                    strHolder = strHolder.Substring(6, strHolder.Length - 6);  //Remove label and save time data
                    times.Add(strHolder);   //Add time to list
                } // end if

                //Add names
                if (strHolder == "Name:")
                {
                    strHolder = _data[i];
                    strHolder = strHolder.Substring(6, strHolder.Length - 6);  //Remove label and save name data
                    names.Add(strHolder);   //Add names to list
                } // end if

                //Add games
                if (strHolder == "Title:")
                {
                    strHolder = _data[i];
                    strHolder = strHolder.Substring(7, strHolder.Length - 7);  //Remove label and save game data
                    games.Add(strHolder);   //Add games to list
                } // end if

                //Add controllers
                if (strHolder == "Controllers:")
                {
                    strHolder = _data[i];
                    strHolder = strHolder.Substring(13, strHolder.Length - 13);  //Remove label and save game data

                    try
                    {
                        Convert.ToInt32(strHolder);
                        if (strHolder != "1" && Convert.ToInt32(strHolder) <= 8 && Convert.ToInt32(strHolder) >= 1)
                            items.Add(Convert.ToInt32(strHolder));   //Add items to list
                    }
                    catch
                    {
                        items.Add(Convert.ToInt32("1"));   //Add items to list
                    }

                    //If user is not already accounted for via Name data, and controller data exists
                    //if (strHolder != "1" && Convert.ToInt32(strHolder) <= 12 && Convert.ToInt32(strHolder) >= 1)
                    //    items.Add(Convert.ToInt32(strHolder));   //Add items to list
                } // end if

                //Add items
                if (strHolder == "Items:")
                {
                    strHolder = _data[i];
                    strHolder = strHolder.Substring(7, strHolder.Length - 7);  //Remove label and save game data

                    try
                    {
                        Convert.ToInt32(strHolder);
                        if (Convert.ToInt32(strHolder) <= 12 && Convert.ToInt32(strHolder) >= 1)
                            items.Add(Convert.ToInt32(strHolder));   //Add items to list
                    }
                    catch 
                    {
                        items.Add(Convert.ToInt32("1"));   //Add items to list
                    }
                    //If data exists
                    //if (Convert.ToInt32(strHolder) <= 12 && Convert.ToInt32(strHolder) >= 1)
                    //    items.Add(Convert.ToInt32(strHolder));   //Add items to list
                } // end if

                //Add game types
                if (strHolder == "Game:")
                {
                    strHolder = _data[i]; // grab entire file string
                    string strHolderType = strHolder.Substring(6, strHolder.Length - 6);  //Remove label and save game type data

                    //Save Billiard Times
                    if (strHolderType == "Billiards")
                    {
                        billiardPlayers++;
                        int intHelper = i; // set i to intHelper so we don't change i
                        int currCount = 0;

                        //Increment through file until Biliard Time is found
                        while (_data[intHelper].Substring(0, _data[intHelper].IndexOf(" ")) != "Time:" && currCount < 6) 
                        {
                            if (intHelper < _data.Count() - 1)
                            {
                                intHelper++;
                                currCount++;
                            } // end if
                            else // no time found
                            {
                                currCount = 6; // force exit
                            } // end else
                        } // end while

                        if (currCount < 6) //test to make sure there is a billiard time
                        {
                            //Save billiard time
                            string billTime = _data[intHelper].Substring(6, _data[intHelper].Length - 6);
                            billiardTimes.Add(billTime);
                        } // end if
                    } // end if

                    // Save Pong Times
                    if (strHolderType == "Ping-Pong")
                    {
                        pongPlayers++;
                        int intHelper = i; // set i to intHelper so we don't change i
                        int currCount = 0;

                        //Increment through file until Pong Time is found
                        while (_data[intHelper].Substring(0, _data[intHelper].IndexOf(" ")) != "Time:" && currCount < 6)
                        {
                            if (intHelper < _data.Count() - 1)
                            {
                                intHelper++;
                                currCount++;
                            } // end if
                            else // no time found
                            {
                                currCount = 6; // force exit
                            } // end else
                        } // end while

                        if (currCount < 6) //test to make sure there is a pong time
                        {
                            //Save pong time
                            string pongTime = _data[intHelper].Substring(6, _data[intHelper].Length - 6);
                            pongTimes.Add(pongTime);
                        } // end if
                    } // end if

                    //Save Hockey Times
                    if (strHolderType == "Air Hockey")
                    {
                        hockeyPlayers++;
                        int intHelper = i; // set i to intHelper so we don't change i
                        int currCount = 0;

                        //Increment through file until Hockey Time is found
                        while (_data[intHelper].Substring(0, _data[intHelper].IndexOf(" ")) != "Time:" && currCount < 6)
                        {
                            if (intHelper < _data.Count() - 1)
                            {
                                intHelper++;
                                currCount++;
                            } // end if
                            else // no time found
                            {
                                currCount = 6; // force exit
                            } // end else
                        } // end while

                        if (currCount < 6) //test to make sure there is a hockey time
                        {
                            //Save hockey time
                            string hockeyTime = _data[intHelper].Substring(6, _data[intHelper].Length - 6);
                            hockeyTimes.Add(hockeyTime);
                        } // end if
                    } // end if

                    //Save Foos Times
                    if (strHolderType == "Foosball")
                    {
                        foosPlayers++;
                        int intHelper = i; // set i to intHelper so we don't change i
                        int currCount = 0;

                        //Increment through file until Foos Time is found
                        while (_data[intHelper].Substring(0, _data[intHelper].IndexOf(" ")) != "Time:" && currCount < 6)
                        {
                            if (intHelper < _data.Count() - 1)
                            {
                                intHelper++;
                                currCount++;
                            } // end if
                            else // no time found
                            {
                                currCount = 6; // force exit
                            } // end else
                        } // end while

                        if (currCount < 6) //test to make sure there is a foos time
                        {
                            //Save foos time
                            string foosTime = _data[intHelper].Substring(6, _data[intHelper].Length - 6);
                            foosTimes.Add(foosTime);
                        } // end if
                    } // end if

                } // end if
            } // end for

            //Display number of player types
            totalBilliardPlayersNum.Text = billiardPlayers.ToString();
            totalPongPlayersNum.Text = pongPlayers.ToString();
            totalHockeyPlayersNum.Text = hockeyPlayers.ToString();
            totalFoosPlayersNum.Text = foosPlayers.ToString();

            //Display total players
            for (int i = 0; i < items.Count(); i++)
            {
                itemTotal += items[i];
            }
            int totalPlayers = itemTotal + names.Count();
            numberOfPlayersNum.Text = totalPlayers.ToString();

            //numberOfPlayersNum.Text = names.Count().ToString();

            if (times.Count() > 0)
                getPrimaryTimes(times);  //Pass times list to find long/short times
            if (games.Count() > 0)
                getTopThreeGames(games); //Pass games list to find game stats

            //Pass times list to find avg times, then display them
            if (pongTimes.Count > 0)
                avgPongTimeNum.Text = getAvgTimes(pongTimes);
            if (times.Count() > 0)
                avgPlayerTimeNum.Text = getAvgTimes(times);
            if (billiardTimes.Count > 0)
                avgBilliardTimeNum.Text = getAvgTimes(billiardTimes);
            if (hockeyTimes.Count > 0)
                avgHockeyTimeNum.Text = getAvgTimes(hockeyTimes);
            if (foosTimes.Count > 0)
                avgFoosTimeNum.Text = getAvgTimes(foosTimes);

        } // end method dataQuery

        //The getPrimaryTimes method
        //Purpose: To find the longest, shortest, and average player times
        //Parameters: A list of strings represented as _times
        //Return: None
        private void getPrimaryTimes(List<string> _times)
        {
            //Create helpers
            List<TimeSpan> timeSpans = new List<TimeSpan>();
            TimeSpan avgSpan = TimeSpan.Zero;

            //Convert time strings to TimeSpan objects
            for (int i = 0; i < _times.Count(); i++)
            {
                TimeSpan timeHelper = TimeSpan.Parse(_times[i]);
                timeSpans.Add(timeHelper);
            } // end for

            //Sort for Longest Time
            for (int j = 0; j < timeSpans.Count(); j++)
            {
                for (int i = 0; i < timeSpans.Count() - 1; i++)
                {
                    if (timeSpans[i] < timeSpans[i + 1]) // SWAP - SHOULD REALLY BE IN ITS OWN METHOD - OPERATOR HERE DETERMINES SMALLEST OR LARGEST SORT
                    {
                        TimeSpan x = timeSpans[i];
                        timeSpans[i] = timeSpans[i + 1];
                        timeSpans[i + 1] = x;
                    } // end if
                } // end for
            } // end for

            //Display longest & shortest times
            longestPlayerTimeNum.Text = timeSpans[0].ToString();
            shortestPlayerTimeNum.Text = timeSpans[timeSpans.Count() - 1].ToString();
        } // end method getPrimaryTimes

        //The getAvgTimes method
        //Purpose: To calculate the average time using a list of times
        //Parameters: A list of strings represented as _times
        //Return: avgSpan in the form of a string
        private string getAvgTimes(List<string> _times)
        {
            //Create helpers
            List<TimeSpan> timeSpans = new List<TimeSpan>();
            TimeSpan avgSpan = TimeSpan.Zero;

            //Convert time strings to TimeSpan objects
            for (int i = 0; i < _times.Count(); i++)
            {
                TimeSpan timeHelper = TimeSpan.Parse(_times[i]);
                timeSpans.Add(timeHelper);
            } // end for

            //Calc Average Time
            for (int i = 0; i < timeSpans.Count(); i++)
            {
                avgSpan += timeSpans[i];
            } // end for

            //Find average time and format
            double dblHolder = avgSpan.TotalMinutes / timeSpans.Count();
            if (dblHolder <= 60) // if less than 1 hour
            {
                string strHolder = String.Format("{0:00}", dblHolder);
                strHolder = "00:" + strHolder + ":00";
                avgSpan = TimeSpan.Parse(strHolder);
            } // end if
            else   //  else over 1 hour
            {
                double dblHolderMinute = dblHolder - 60;
                string strHolder = "";

                if (dblHolderMinute <= 60) //Roll over - 1 HOUR
                {
                    strHolder = String.Format("{0:00}", dblHolderMinute);
                    strHolder = "01:" + strHolder + ":00";
                } // end if
                if (dblHolderMinute > 60) //Roll over - 2 HOURS
                {
                    dblHolderMinute = dblHolderMinute - 60;
                    strHolder = String.Format("{0:00}", dblHolderMinute);
                    strHolder = "02:" + strHolder + ":00";
                } // end if
                if (dblHolderMinute > 60) //Roll over - 3 HOURS
                {
                    dblHolderMinute = dblHolderMinute - 60;
                    strHolder = String.Format("{0:00}", dblHolderMinute);
                    strHolder = "03:" + strHolder + ":00";
                } // end if
                if (dblHolderMinute > 60) //Roll over - 4 HOURS
                {
                    dblHolderMinute = dblHolderMinute - 60;
                    strHolder = String.Format("{0:00}", dblHolderMinute);
                    strHolder = "04:" + strHolder + ":00";
                } // end if
                if (dblHolderMinute > 60) //Roll over - 5 HOURS
                {
                    dblHolderMinute = dblHolderMinute - 60;
                    strHolder = String.Format("{0:00}", dblHolderMinute);
                    strHolder = "05:" + strHolder + ":00";
                } // end if
                avgSpan = TimeSpan.Parse(strHolder);
            } // end else

            return avgSpan.ToString();
        } // end method getAvgTimes

        //The getTopThreeGames method
        //Purpose: To sort the games list and find the top three occurances
        //Parameters: A list of strings represented as _games
        //Return: None
        private void getTopThreeGames(List<string> _games)
        {
            //Create helpers
            List<int> gameCount = new List<int>();
            List<string> games = new List<string>();

            //Group game titles
            var groupedGames = _games.GroupBy(i => i);
            //Foreach type, add title and title occurrances to lists
            foreach (var type in groupedGames)
            {
                gameCount.Add(type.Count());
                games.Add(type.Key);
            } // end foreach

            //Sort by highest game count
            for (int j = 0; j < gameCount.Count(); j++)
            {
                for (int i = 0; i < gameCount.Count() - 1; i++)
                {
                    if (gameCount[i] < gameCount[i + 1]) // SWAP - SHOULD REALLY BE IN ITS OWN METHOD - OPERATOR HERE DETERMINES SMALLEST OR LARGEST SORT
                    {
                        int x = gameCount[i];
                        string z = games[i];

                        gameCount[i] = gameCount[i + 1];
                        games[i] = games[i + 1];

                        gameCount[i + 1] = x;
                        games[i + 1] = z;

                    } // end if
                } // end for
            } // end for

            //Display Top 3 titles
            if (games.Count() > 3) // ensure enough titles to have a top 3
            {
                top1VGPlayedNum.Text = games[0];
                top2VGPlayedNum.Text = games[1];
                top3VGPlayedNum.Text = games[2];
            } // end if
            else
                MessageForm.Show("NOT ENOUGH VIDEO GAMES IN FILE FOR RANKING", "OK", "No Top 3");

        } // end method getTopThreeGames

        //The clearResults method
        //Purpose: To clear all the labels holding stats results
        //Parameters: None
        //Return: None
        private void clearResults()
        {
            avgPlayerTimeNum.Text = "00";
            numberOfPlayersNum.Text = "00";
            longestPlayerTimeNum.Text = "00";
            shortestPlayerTimeNum.Text = "00";
            top1VGPlayedNum.Text = "00";
            top2VGPlayedNum.Text = "00";
            top3VGPlayedNum.Text = "00";
            totalBilliardPlayersNum.Text = "00";
            totalPongPlayersNum.Text = "00";
            totalHockeyPlayersNum.Text = "00";
            totalFoosPlayersNum.Text = "00";
            avgBilliardTimeNum.Text = "00";
            avgPlayerTimeNum.Text = "00";
            avgPongTimeNum.Text = "00";
            avgHockeyTimeNum.Text = "00";
            avgFoosTimeNum.Text = "00";
            currSearchCritLbl.Text = "Pending...";
        } // end method clearResults

        //The fromTxtBox_Enter method
        //Purpose: To display fromClndr so the user can pick a date to search from
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void fromTxtBox_Enter(object sender, EventArgs e)
        {
            fromTxtBox.Text = "";
            fromClndr.Visible = true;

            //If user manually enters search dates, uncheck all radioButtons
            foreach (Control rBtn in radioPanel.Controls)
            {
                if (rBtn is RadioButton)
                    ((RadioButton)rBtn).Checked = false;
            } // end foreach
        } // end method fromTxtBox_Enter

        //The toTxtBox_Enter method
        //Purpose: To display monthCalendar2 so the user can pick a date to search to
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void toTxtBox_Enter(object sender, EventArgs e)
        {
            toClndr.Visible = true;

            //If user manually enters search dates, uncheck all radioButtons
            foreach (Control rBtn in radioPanel.Controls)
            {
                if (rBtn is RadioButton)
                    ((RadioButton)rBtn).Checked = false;
            } // end foreach
        } // end method toTxtBox_Enter

        //The fromTxtBox_Leave method
        //Purpose: 
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void fromTxtBox_Leave(object sender, EventArgs e)
        {

        } // end method fromTxtBox_Leave

        //The toTxtBox_Leave method
        //Purpose: 
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void toTxtBox_Leave(object sender, EventArgs e)
        {

        } // end method toTxtBox_Leave

        //The fromClndr_DateSelected method
        //Purpose: To set the fromClndr date as fromTxtBox.Text
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void fromClndr_DateSelected(object sender, DateRangeEventArgs e)
        {
            fromClndrDate = e.Start; // set fromClndrDate as selected date
            fromTxtBox.Text = e.Start.ToShortDateString(); // format selected date as string and display in txtBox
            int decision = checkDates(); // check whether from-date is not after to-date
            if (decision == -1) // if from-to discrepency 
            {
                MessageForm.Show("FROM-DATE CANNOT BE AFTER TO-DATE", "OK", "Date Selection Conflict");  // pass args to Show method
                fromTxtBox.Clear();
            }
            else
                fromTxtBox.Text = e.Start.ToShortDateString();

            fromClndr.Visible = false;
        } // end method fromClndr_DateSelected

        //The toClndr_DateSelected method
        //Purpose: To set the toClndr date as toTxtBox.Text
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void toClndr_DateSelected(object sender, DateRangeEventArgs e)
        {
            toClndrDate = e.Start; // set toClndrDate as selected date
            toTxtBox.Text = e.End.ToShortDateString(); // format selected date as string and display in txtBox
            int decision = checkDates(); // check whether from-date is not after to-date
            if (decision == -1) // if from-to discrepency 
            {
                MessageForm.Show("FROM-DATE CANNOT BE AFTER TO-DATE", "OK", "Date Selection Conflict");  // pass args to Show method
                toTxtBox.Text = "";
            }
            else
                toTxtBox.Text = e.End.ToShortDateString();

            toClndr.Visible = false;
        } // end method toClndr_DateSelected

        //The checkDates method
        //Purpose: To check whether from-date is after to-date
        //Parameters: None
        //Return: An integer (-1 for error, 0 for no error)
        private int checkDates()
        {
            if (fromTxtBox.Text != "" && toTxtBox.Text != "" && toClndrDate < fromClndrDate)
                return -1;
            else
                return 0;
        } // end method checkDates

        //The radioPanel_Enter method
        //Purpose: To clear To/From txtBoxes is user selects search criteria shortcut
        //Parameters: The object generating the event, and the event arguments
        //Return: None
        private void radioPanel_Enter(object sender, EventArgs e)
        {
            fromTxtBox.Clear();
            toTxtBox.Clear();
        } // end method radioPanel_Enter

    } // end class Stats
} // end namespace UVU_Gaming_Center_App