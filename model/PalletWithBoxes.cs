using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{

    internal class PalletWithBoxes : IHaveExpirationDate, IHaveWeight
    {
        public double weight { get; private set; }
        public Pallet pallet { get; set; }
        public DateTime expirationDate { get; private set; }

        public List<BoxWithContents> boxes { get;}

        public PalletWithBoxes(Pallet pallet, List<BoxWithContents> boxes)
        {
            this.pallet = pallet;
            this.boxes = boxes;

        }

        private void setExpirationDate()
        {
            int minDay = 0;
            foreach (BoxWithContents box in boxes)
            {
                int shelfLife = DateTime.Now.Day - box.expirationDate.Day;
                if (shelfLife > minDay) {
                    minDay =  box.expirationDate.Day - DateTime.Now.Day;
                }
            }
            this.expirationDate = DateTime.Now.AddDays(minDay);
        }
    }
}

