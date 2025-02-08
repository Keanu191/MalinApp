using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MalinApp.Services;

namespace MalinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SensorDataService _sensorService = new SensorDataService();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for loading sensor data and displaying it.
        /// </summary>
        private void BtnLoadAB_Click(object sender, RoutedEventArgs e)
        {
            _sensorService.LoadData(mu: mu1.Text, sigma: sigma1.Text);
            _sensorService.ShowAllSensorData(listView1);
            _sensorService.DisplayListBoxData(_sensorService.SensorA, listBoxA);
            _sensorService.DisplayListBoxData(_sensorService.SensorB, listBoxB);
        }

        /// <summary>
        /// Validates that only numeric input is allowed in the text box.
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Handles the click event for iterative binary search on sensor A data.
        /// </summary>
        private void BtnBSIA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SortingHelper.SelectionSort(_sensorService.SensorA);
                int searchDetail = int.Parse(searchValA.Text);
                int lowest = 0;
                int highest = _sensorService.SensorA.Count;

                Stopwatch stopwatch = Stopwatch.StartNew();
                int foundIndex = SortingHelper.BinarySearchIterative(_sensorService.SensorA, searchDetail, lowest, highest);
                stopwatch.Stop();

                _sensorService.DisplayListBoxData(_sensorService.SensorA, listBoxA);
                HighlightListBoxItems(listBoxA, foundIndex);
                txtBoxBSIA.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
            } catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show(this, "No input was in the search value textbox for Sensor A!",
                "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        /// <summary>
        /// Handles the click event for iterative binary search on sensor B data.
        /// </summary>
        private void BtnBSIB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SortingHelper.SelectionSort(_sensorService.SensorB);
                int searchDetail = int.Parse(searchValB.Text);
                int lowest = 0;
                int highest = _sensorService.SensorB.Count;

                Stopwatch stopwatch = Stopwatch.StartNew();
                int foundIndex = SortingHelper.BinarySearchIterative(_sensorService.SensorB, searchDetail, lowest, highest);
                stopwatch.Stop();

                _sensorService.DisplayListBoxData(_sensorService.SensorB, listBoxB);
                HighlightListBoxItems(listBoxB, foundIndex);
                txtBoxBSIB.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
            } catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show(this, "No input was in the search value textbox for Sensor B!",
                "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        /// <summary>
        /// Handles the click event for recursive binary search on sensor A data.
        /// </summary>
        private void BtnBSRA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SortingHelper.InsertionSort(_sensorService.SensorA);
                int searchDetail = int.Parse(searchValA.Text);
                int lowest = 0;
                int highest = _sensorService.SensorA.Count;

                Stopwatch stopwatch = Stopwatch.StartNew();
                int foundIndex = SortingHelper.BinarySearchRecursive(_sensorService.SensorA, searchDetail, lowest, highest);
                stopwatch.Stop();

                _sensorService.DisplayListBoxData(_sensorService.SensorA, listBoxA);
                HighlightListBoxItems(listBoxA, foundIndex);
                txtBoxBSRA.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
            } catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show(this, "No input was in the search value textbox for Sensor A!",
                "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        /// <summary>
        /// Handles the click event for recursive binary search on sensor B data.
        /// </summary>
        private void BtnBSRB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SortingHelper.SelectionSort(_sensorService.SensorB);
                int searchDetail = int.Parse(searchValB.Text);
                int lowest = 0;
                int highest = _sensorService.SensorB.Count;

                Stopwatch stopwatch = Stopwatch.StartNew();
                int foundIndex = SortingHelper.BinarySearchRecursive(_sensorService.SensorB, searchDetail, lowest, highest);
                stopwatch.Stop();

                _sensorService.DisplayListBoxData(_sensorService.SensorB, listBoxB);
                HighlightListBoxItems(listBoxB, foundIndex);
                txtBoxBSRB.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
            } catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show(this, "No input was in the search value textbox for Sensor B!",
                "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        /// <summary>
        /// Handles the click event for selection sort on sensor A data.
        /// </summary>
        private void BtnSelectionSortA_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            SortingHelper.SelectionSort(_sensorService.SensorA);
            _sensorService.DisplayListBoxData(_sensorService.SensorA, listBoxA);
            stopwatch.Stop();
            txtBoxSelectionA.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
        }

        /// <summary>
        /// Handles the click event for insertion sort on sensor A data.
        /// </summary>
        private void BtnInserationSortA_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            SortingHelper.InsertionSort(_sensorService.SensorA);
            _sensorService.DisplayListBoxData(_sensorService.SensorA, listBoxA);
            stopwatch.Stop();
            txtBoxInserationA.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
        }

        /// <summary>
        /// Handles the click event for selection sort on sensor B data.
        /// </summary>
        private void BtnSelectionSortB_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            SortingHelper.SelectionSort(_sensorService.SensorB);
            _sensorService.DisplayListBoxData(_sensorService.SensorB, listBoxB);
            stopwatch.Stop();
            txtBoxSelectionB.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
        }

        /// <summary>
        /// Handles the click event for insertion sort on sensor B data.
        /// </summary>
        private void BtnInserationSortB_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            SortingHelper.InsertionSort(_sensorService.SensorB);
            _sensorService.DisplayListBoxData(_sensorService.SensorB, listBoxB);
            stopwatch.Stop();
            txtBoxInserationB.Text = $"{stopwatch.Elapsed.Milliseconds} MS";
        }

        /// <summary>
        /// Highlights three items in the specified ListBox starting at the given index.
        /// </summary>
        /// <param name="listBox">The ListBox control to highlight items in.</param>
        /// <param name="startIndex">The starting index for highlighting items.</param>
        private void HighlightListBoxItems(ListBox listBox, int startIndex)
        {
            if (startIndex < 0)
                return;

            listBox.UnselectAll();
            listBox.Focus();

            for (int i = 0; i < 3; i++)
            {
                if (startIndex + i < listBox.Items.Count)
                {
                    listBox.SelectedItems.Add(listBox.Items[startIndex + i]);
                    listBox.ScrollIntoView(listBox.Items[startIndex + i]);
                }
                else
                {
                    MessageBox.Show("ERROR: Index not found!");
                    break;
                }
            }
        }
    }
}
