using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace COMP1004_Lesson41
{
    public partial class CalculatorForm : Form
    {
        //3. create a reference to the previous form
        public SplashForm previousForm;

        //PRIVATE INSTANCE VARIABLES    
        private string _operand1;
        private string _operand2;
        private bool _isCalculatorClear;
        private string _calculatorFormLayout;

        //Constructors++++++++++++++++++++++

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();

            this._clearCalulator();
            this.CalculatorFormLayout = "Standard";
        }

        //PUBLIC PROPERTIES++++++++++++++++++

        public string CalculatorFormLayout
        {
            get
            {
                return this._calculatorFormLayout;
            }
            set
            {
                this._calculatorFormLayout = value;
                Debug.WriteLine("Calculator Form Changed");
            }
        }

        /// <summary>
        /// This methos clears the calcualtor app and resets the variables
        /// </summary>
        private void _clearCalulator()
        {
            this._operand1 = "";
            this._operand2 = "";
            this._isCalculatorClear = true;
            ResultTextBox.Text = "0";
        }

        /// <summary>
        /// Event Handler for all Calculator Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _calculatorButton_Click(object sender, EventArgs e)
        {
            Button CalculatorButton = sender as Button;

            switch (CalculatorButton.Tag.ToString())
            {
                case "Operand":
                    if (this._isCalculatorClear)
                    {
                        ResultTextBox.Text = CalculatorButton.Text;
                    }
                    else
                    {
                        ResultTextBox.Text += CalculatorButton.Text;
                        this._isCalculatorClear = false;
                    }
                    break;

                case "Opator":
                    break;

                case "Other":
                    break;
            }

        }

        private void CalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.previousForm.Close();

            }
            else
            {
                e.Cancel = true;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //step 1. create a new about form
            AboutForm aboutForm = new AboutForm();

            //step 2. show the about form with ShowDialog (a modal method to display the form)
            aboutForm.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create a dialog result container
            DialogResult result;
            //step 1. create a new form - Options form
            OptionsForm optionsForm = new OptionsForm();

            //Step 2. set a referance to the PreviousForm property of the Options Form to this form
            optionsForm.PreviousForm = this;
            optionsForm.CalculatorLayout = this.CalculatorFormLayout;

            //step 3. show the Options Form with ShowDialog (a modal method to display the form)
            result = optionsForm.ShowDialog();

            Debug.WriteLine(result.ToString());
        }
    }
}
