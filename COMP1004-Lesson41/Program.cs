using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_Lesson41
{
    static class Program
    {
        //declare public static form - Application global
        public static SplashForm MySplashForm;

        //declared public static form - calculator form
        public static CalculatorForm MyCalculatorForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //initalize the splash form
            Program.MySplashForm = new SplashForm();
            Program.MyCalculatorForm = new CalculatorForm();

            Application.Run(Program.MySplashForm);


        }
    }
}
