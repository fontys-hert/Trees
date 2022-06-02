using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Ui
{
    public class Tree
    {
        private int heightCurrent = 55 * 100;

        public string Name { get; private set; }
        public int AmountToShrinkGrowCm { get; private set; }
        public int HeightMaximum { get; private set; }

        public Tree(string name, int amountToShrinkGrowCm, int heightMaximum)
        {
            Name = name;
            if (amountToShrinkGrowCm > heightMaximum)
            {
                throw new Exception("amount to shrink/grow cannot be higher than the maximum");
            }
            AmountToShrinkGrowCm = amountToShrinkGrowCm;
            HeightMaximum = heightMaximum * 100;
        }

        public Tree(string name, int amountToShrinkGrowCm, int heightMaximum, int height) 
            : this(name, amountToShrinkGrowCm, heightMaximum)
        {
            heightCurrent = height;
        }

        public int HeightCurrent
        {
            get
            {
                return heightCurrent;
            }
        }

        public void Shrink()
        {
            heightCurrent = heightCurrent - AmountToShrinkGrowCm;
        }

        public void Grow()
        {
            if (heightCurrent < 55 * 100)
            {
                heightCurrent = heightCurrent + AmountToShrinkGrowCm;
            }
        }
    }
}
