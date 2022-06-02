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

        public int AmountToShrinkGrowCm { get; private set; }
        public int HeightMaximum { get; private set; }

        public Tree(int amountToShrinkGrowCm, int heightMaximum)
        {
            if (amountToShrinkGrowCm > heightMaximum)
            {
                throw new Exception("amount to shrink/grow cannot be higher than the maximum");
            }
            AmountToShrinkGrowCm = amountToShrinkGrowCm;
            HeightMaximum = heightMaximum * 100;
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
            this.heightCurrent = this.heightCurrent - this.AmountToShrinkGrowCm;
        }

        public void Grow()
        {
            if (this.heightCurrent < 55 * 100)
            {
                this.heightCurrent = this.heightCurrent + this.AmountToShrinkGrowCm;
            }
        }
    }
}
