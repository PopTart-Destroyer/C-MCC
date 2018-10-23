using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingBubbleSort {
    public partial class Form1 : Form {
        
        //global array
        List<int> bubbleArray = new List<int>();

        public Form1() {
            InitializeComponent();
        }

        private void addNumberButton_Click(object sender, EventArgs e) {
            try {

                var qry = from element in inputTextBox.Text.Split(',')
                          select int.Parse(element);

                //loop through pop bubble array
                foreach (var item in qry) {
                    bubbleArray.Add(item);
                }

            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void viewButton_Click(object sender, EventArgs e) {
            displayListBox.Items.Add("Original input (Unsorted): ");

            foreach (var item in bubbleArray) {
                displayListBox.Items.Add(item);
            }


        }

        private void exitButton_Click(object sender, EventArgs e) {
            //exit program
            Close();
        }

        private void sortButton_Click(object sender, EventArgs e) {
            //sort bubbleArray
            int[] a = bubbleArray.ToArray();
            int temp = 0;

            
            displayListBox.Items.Add("Sorted input: ");

            //write
            for (int i = 0; i < a.Length - 1; i++) {
                //sort
                for (int j = 0; j < a.Length - 1 - i; j++) {
                    if (a[j] > a[j + 1]) {
                        temp = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = temp;
                    }
                }
            }

            for (int k = 0; k < a.Length - 1; k++) {
                displayListBox.Items.Add(a[k]);
            }

        }

        private void clearButton_Click(object sender, EventArgs e) {
            inputTextBox.Text = string.Empty;
            displayListBox.Items.Clear();
        }
    }
}
