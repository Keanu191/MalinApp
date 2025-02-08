using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Galileo6;

namespace MalinApp.Services
{
    /// <summary>
    /// Provides services for loading and displaying sensor data.
    /// </summary>
    public class SensorDataService
    {
        /// <summary>
        /// Gets the linked list holding sensor A data.
        /// </summary>
        public LinkedList<double> SensorA { get; private set; } = new LinkedList<double>();

        /// <summary>
        /// Gets the linked list holding sensor B data.
        /// </summary>
        public LinkedList<double> SensorB { get; private set; } = new LinkedList<double>();

        /// <summary>
        /// Loads sensor data into SensorA and SensorB.
        /// </summary>
        /// <param name="mu">The mean value (as string) to be parsed to double.</param>
        /// <param name="sigma">The standard deviation (as string) to be parsed to double.</param>
        public void LoadData(string mu, string sigma)
        {
            SensorA.Clear();
            SensorB.Clear();

            ReadData reader = new ReadData();
            const int total = 400;
            double parsedMu = double.Parse(mu);
            double parsedSigma = double.Parse(sigma);

            for (int i = 0; i < total; i++)
            {
                SensorA.AddLast(reader.SensorA(parsedMu, parsedSigma));
                SensorB.AddLast(reader.SensorB(parsedMu, parsedSigma));
            }
        }

        /// <summary>
        /// Displays sensor data in a ListView by combining data from SensorA and SensorB.
        /// </summary>
        /// <param name="listView">The ListView control where data is displayed.</param>
        public void ShowAllSensorData(ListView listView)
        {
            listView.Items.Clear();

            var nodeA = SensorA.First;
            var nodeB = SensorB.First;
            while (nodeA != null && nodeB != null)
            {
                listView.Items.Add(new { SensorA = nodeA.Value, SensorB = nodeB.Value });
                nodeA = nodeA.Next;
                nodeB = nodeB.Next;
            }
        }

        /// <summary>
        /// Displays the content of a linked list in the specified ListBox.
        /// </summary>
        /// <param name="data">The linked list of sensor data.</param>
        /// <param name="listBox">The ListBox control to display the data.</param>
        public void DisplayListBoxData(LinkedList<double> data, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var item in data)
            {
                listBox.Items.Add(item);
            }
        }

        /// <summary>
        /// Returns the number of nodes in the provided linked list.
        /// </summary>
        /// <param name="data">The linked list of sensor data.</param>
        /// <returns>The count of nodes.</returns>
        public int NumberOfNodes(LinkedList<double> data)
        {
            return data.Count;
        }
    }
}
