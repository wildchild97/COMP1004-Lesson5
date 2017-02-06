using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        //Constructors++++++++++++++++++++++

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();

            this._clearCalulator();
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
    }
}
