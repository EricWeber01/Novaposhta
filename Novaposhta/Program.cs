using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novaposhta
{
    public class ceis
    {
        public NumericUpDown nu { get; set; }
        public MaskedTextBox txo { get; set; }
        public MaskedTextBox txd { get; set; }
        public ceis(NumericUpDown _nu, MaskedTextBox _txo, MaskedTextBox _txd) { nu = _nu; txo = _txo; txd = _txd; }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
