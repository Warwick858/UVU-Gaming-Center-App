using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch_Custom
{
    public partial class StopWatch_Custom : UserControl
    {
        // Because we have not specified a namespace, this
        // will be a System.Windows.Forms.Timer instance
        private Timer _timer;

        // The last time the timer was started
        private DateTime _startTime = DateTime.MinValue;
        //private TimeSpan _startTime = TimeSpan.Zero;

        // Time between now and when the timer was started last
        public TimeSpan _currentElapsedTime = TimeSpan.Zero;

        // Time between now and the first time timer was started after a reset
        public TimeSpan _totalElapsedTime = TimeSpan.Zero;

        // Whether or not the timer is currently running
        private bool _timerRunning = false;

        public StopWatch_Custom()
        {
            InitializeComponent();

            // Set up a timer and fire the Tick event once per second (1000 ms)
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timerLbl.Text = DateTime.Now.ToLongTimeString();


            // We do this to chop off any stray milliseconds resulting from 
            // the Timer's inherent inaccuracy, with the bonus that the 
            // TimeSpan.ToString() method will now show correct HH:MM:SS format
            var timeSinceStartTime = DateTime.Now - _startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);

            // The current elapsed time is the time since the start button was
            // clicked, plus the total time elapsed since the last reset
            _currentElapsedTime = timeSinceStartTime + _totalElapsedTime;

            // These are just two Label controls which display the current 
            // elapsed time and total elapsed time
            //_totalElapsedTimeDisplay.Text = _currentElapsedTime.ToString();
            //_currentElapsedTimeDisplay.Text = timeSinceStartTime.ToString();

            timerLbl.Text = _currentElapsedTime.ToString();
        }

        public void startPicBox_Click(object sender, EventArgs e)
        {
            // If the timer isn't already running
            if (!_timerRunning)
            {
                // Set the start time to Now
                _startTime = DateTime.Now;

                // Store the total elapsed time so far
                _totalElapsedTime = _currentElapsedTime;

                _timer.Start();
                _timerRunning = true;
            }
            else // If the timer is already running
            {
                timerLbl.Text = _currentElapsedTime.ToString();
                _timer.Start();
            }
        }

        public void stopPicBox_Click(object sender, EventArgs e)
        {
            if (_timerRunning)
            {
                _timer.Stop();
                _timerRunning = false;
            }
        }

        public void resetPicBox_Click(object sender, EventArgs e)
        {
            // Stop and reset the timer if it was running
            _timer.Stop();
            _timerRunning = false;

            // Reset the elapsed time TimeSpan objects
            _totalElapsedTime = TimeSpan.Zero;
            _currentElapsedTime = TimeSpan.Zero;

            timerLbl.Text = "00:00:00";
        }

        public void resetClock()
        {
            // Stop and reset the timer if it was running
            _timer.Stop();
            _timerRunning = false;

            // Reset the elapsed time TimeSpan objects
            _totalElapsedTime = TimeSpan.Zero;
            _currentElapsedTime = TimeSpan.Zero;

            timerLbl.Text = "00:00:00";
        }

    }
}
