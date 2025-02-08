# Malin Space Science Systems Satellite Data Processing Application


## Overview
This WPF application was developed as part of a Information Technology assignment at South Metropolitan TAFE. The project is a **fictional application** created for Malin Space Science Systems (MSSS) to process and analyze satellite sensor data. It simulates the loading of sensor data from a DLL (Galileo6) that generates random double values for two sensors (Sensor A and Sensor B). The application then processes this data using advanced sorting (Selection Sort and Insertion Sort) and binary searching (iterative and recursive) algorithms, measuring and displaying the processing times for each.

## Project Description
Malin Space Science Systems operates a satellite that records data from two sensors during its sun-synchronous orbit passes. The raw sensor data, following a Normal Distribution, is transmitted to a server for further analysis. The legacy system—a 32-bit command line application—is no longer compatible with modern hardware. This WPF application modernizes the process by:
- Loading sensor data from the Galileo6 DLL into two separate `LinkedList<double>` objects.
- Displaying the data in both a ListView (with separate columns for Sensor A and Sensor B) and individual ListBoxes.
- Allowing users to adjust data parameters via numeric inputs for mean (Mu) and standard deviation (Sigma).
- Implementing two sorting algorithms (Selection Sort and Insertion Sort) and two binary search algorithms (iterative and recursive).
- Displaying processing times for each algorithm to allow for performance comparison.

## Features
- **Sensor Data Simulation:**  
  Utilizes the Galileo6 DLL to generate random double values representing sensor data.
- **Data Structures:**  
  Two `LinkedList<double>` instances store sensor data for Sensor A and Sensor B.
- **Sorting Algorithms:**  
  - Selection Sort  
  - Insertion Sort
- **Searching Algorithms:**  
  - Iterative Binary Search  
  - Recursive Binary Search
- **User Interface:**  
  - **ListView:** Displays combined sensor data with two columns (Sensor A and Sensor B).  
  - **ListBoxes:** Display sensor data for individual sensors.  
  - **Numeric Inputs:** Control parameters (Mu and Sigma) for data generation.  
  - **Buttons:** Trigger data loading, sorting, and searching functionalities.  
  - **Processing Time Display:** TextBoxes display the elapsed time for each sorting and searching operation.

## Installation and Setup

### Prerequisites
- **Development Environment:** Visual Studio 2022
- **.NET Framework:** .NET 8
- **Dependencies:**  
  - **Galileo6 DLL:** Place this DLL in the solution's root directory and add it as a reference.  
  - **Xceed WPF Toolkit:** Install via the NuGet Package Manager.
 

## UI
![Program running](https://github.com/user-attachments/assets/bbd33a08-aa29-4915-ad51-a8b95b1c53fc)
