using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assessment_2_Contractors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecruitmentSystem recruitment = new RecruitmentSystem(20);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_GetContractors_Click(object sender, RoutedEventArgs e)
        {
            foreach (Contractor contractor in recruitment.GetContractors())
            {
                ListBox_Contractors.Items.Add(contractor);
            }
        }
    }
}
