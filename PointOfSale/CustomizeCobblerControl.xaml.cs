//Modified by Grant Clothier
//4.10.2020
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamTwoCodeQuestions.Data;

namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
            //buttons:
            BtnCherry.Click += OnChangeFlavor;
            BtnPeach.Click += OnChangeFlavor;
            BtnBlueberry.Click += OnChangeFlavor;

        }

        void OnChangeFlavor(object sender, RoutedEventArgs e)
        {

            //Cobbler
            //Cobbler cobbler = (Cobbler)DataContextProperty;

            /*
            Peach,
            Cherry,
            Blueberry
            */

            //if the datacontext is already set to cobbler, I think this should work
            if (DataContext is Cobbler cob)
            {
                if (sender is Button button)
                {
                    switch (button.Tag)
                    {
                        case "Cherry":
                            cob.fruit = FruitFilling.Cherry;
                            break;
                        case "Blueberry":
                            cob.fruit = FruitFilling.Blueberry;
                            break;
                        case "Peach":
                            cob.fruit = FruitFilling.Peach;
                            break;
                    }
                    FlavorOutput.Text = cob.fruit.ToString();
                }
            }

        }
    }
}
