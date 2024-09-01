using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Windows_Application_PIXELPAW_LABS
{
    public sealed partial class MainWindow : Window
    {
        private bool isAccelerating = false;
        private DispatcherTimer timer;
        private double accelerationValue = 0;
        private const double MaxValue = 100; // Maximum value for the ProgressBar

        public MainWindow()
        {
            this.InitializeComponent();
            PopulateSessionHistory();
            
            this.ExtendsContentIntoTitleBar = true; // Enable extending content into the title bar area
            this.SetTitleBar(AppTitleBar );
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50) // Adjust the update rate for smoother animation
            };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            if (isAccelerating)
            {
                // Increase the acceleration value
                accelerationValue += 1; // Adjust increment to control the acceleration speed
                if (accelerationValue > MaxValue)
                {
                    accelerationValue = MaxValue;
                }
                AccelerationBar.Value = accelerationValue;
            }
        }
        // Accelerate Button Pressed
        private void AccelerateButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            isAccelerating = true;
            timer.Start(); // Start the timer when the button is pressed
        }


        // Accelerate Button Released
        private void AccelerateButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            isAccelerating = false;
            timer.Stop(); // Stop the timer when the button is released
            accelerationValue = 0; // Reset the value when the button is released
            AccelerationBar.Value = 0; // Reset the ProgressBar
        }
        // Populate the session history list
        private void PopulateSessionHistory()
        {
            // Updated session data with both date and time
            List<string> sessionData = new List<string>
            {
                "Session 1 - Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                "Session 2 - Date: " + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"),
                "Session 3 - Date: " + DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd HH:mm:ss")
            };

            foreach (var session in sessionData)
            {
                // Create a ListBoxItem with session data
                var listBoxItem = new ListBoxItem
                {
                    Content = session
                };

                SessionHistoryList.Items.Add(listBoxItem);
            }
        }

            // Additional event handlers for the buttons (if needed)
            private void AccelerateButton_Click(object sender, RoutedEventArgs e)
        {
            // Optionally handle click event
        }
    }
}
