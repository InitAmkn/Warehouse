using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warehouse.model
{

    internal class PalletWithBoxes : IHaveExpirationDate, IHaveWeight, IHaveVolume
    {
        public double Weight { get; private set; }
        public Pallet pallet { get; private set; }
        public DateTime expirationDate { get; private set; }
        public double Volume { get; private set; }

        public List<BoxWithContents> boxes { get; private set; }

        public PalletWithBoxes(Pallet pallet, List<BoxWithContents> boxes)
        {
            try
            {
                this.pallet = pallet;
                this.boxes = setBoxesWithContents(boxes);
                setExpirationDate();
                setWeight();
                setVolume();
            }
            catch (NoBoxesFoundException e) { Console.WriteLine(e.Message); }
        }

        private List<BoxWithContents> setBoxesWithContents(List<BoxWithContents> boxes)
        {

            List<BoxWithContents> approvedBoxes = new List<BoxWithContents>();
            foreach (BoxWithContents item in boxes)
            {
                bool doesThisBoxFit = true;

                if (pallet.Length < item.Length && pallet.Length < item.Width ||
                    pallet.Width < item.Width && pallet.Width < item.Length)
                {
                    doesThisBoxFit = false;
                }
                if (doesThisBoxFit) { approvedBoxes.Add(item); }
            }
            return approvedBoxes;
        }


        private void setExpirationDate()
        {
            if (boxes.Count() <= 0)
            {
                throw new NoBoxesFoundException("На паллете нет коробок");
            }

            DateTime minDays = boxes[0].expirationDate;
            foreach (BoxWithContents box in boxes)
            {
                if (minDays.CompareTo(box.expirationDate) == 1)
                {
                    minDays = box.expirationDate;
                }
            }
            expirationDate = minDays;
        }

        private void setWeight()
        {
            if (boxes.Count() <= 0)
            {
                Weight = pallet.Weight;
                throw new NoBoxesFoundException("На паллете нет коробок");
            }
            Weight = boxes.Sum(x => x.Weight) + pallet.Weight;
        }

        private void setVolume()
        {
            if (boxes.Count() <= 0)
            {
                Volume = pallet.Volume;
                throw new NoBoxesFoundException("На паллете нет коробок");
            }
            Volume = boxes.Sum(x => x.Volume) + pallet.Volume;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(pallet);
            sb.Append($"Expiration date: {this.expirationDate}");
            sb.Append(":\nEnter: \n\n");
            foreach (BoxWithContents item in boxes)
            {
                sb.Append(item);
                sb.Append("\n\n");
            }
            return sb.ToString();
        }
    }
}

