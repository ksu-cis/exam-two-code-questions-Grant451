﻿//Modified by Grant Clothier
//4.10.2020
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public FruitFilling fruit;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit 
        { 
            get
            {
                return fruit;
            }
            set
            {
                fruit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fruit"));
            }
        }


        private bool withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream 
        {
            get { return withIceCream; }
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                withIceCream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WithIceCream"));//price is determined by this property
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));//special instructions is also tied to this property
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream)
                {
                    return 5.32;
                }
                else
                {
                    return 4.25;
                }
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        
    }
}
