using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warehouse.model
{

    internal class PalletWithContents : IHaveExpirationDate, IHaveWeight, IHaveVolume
    {
        public double Weight { get; private set; }
        public Pallet pallet { get; private set; }
        public DateTime expirationDate { get; private set; }
        public double Volume { get; private set; }

        public List<Storage> contains { get; private set; }


        public PalletWithContents(Pallet pallet)
        {
            this.pallet = pallet;
            contains = new List<Storage>();
        }

        public void addContains(Storage storage)
        {
            try
            {
                if (contentApprovalSizes(storage))
                {
                    contains.Add(storage);
                    if (storage is IHaveExpirationDate) setExpirationDate(storage as IHaveExpirationDate);
                    if (storage is IHaveWeight) setWeight(storage as IHaveWeight);
                    setVolume(storage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n--\nНе добавлен: { storage}");
                Console.WriteLine(ex.Message);
            }
        }


        private bool contentApprovalSizes(Storage storage)
        {

            if (pallet.Length < storage.Length && pallet.Length < storage.Width ||
                pallet.Width < storage.Width && pallet.Width < storage.Length)
            {
                throw new CannotAddException($" \nНеподходящий габарит \n--\n");
            }
            return true;
        }


        private void setExpirationDate(IHaveExpirationDate content)
        {
            if (this.contains.Count() == 1)
            {
                expirationDate = content.expirationDate;
            }
            else if (expirationDate.CompareTo(content.expirationDate) == 1)
            {
                expirationDate = content.expirationDate;
            }
        }

        private void setWeight(IHaveWeight content)
        {
            Weight = Weight + pallet.Weight + content.Weight;
        }

        private void setVolume(IHaveVolume content)
        {
            Volume = Volume + pallet.Volume + content.Volume;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n_________________________\n");
            sb.Append(pallet);
           
            sb.Append("\nContains: \n--\n");
            foreach (Storage item in contains)
            {
                sb.Append(item);
                sb.Append("\n--\n");
            }
            sb.Append("\n");
            sb.Append($"Actual expiration date: {this.expirationDate}");
            sb.Append("\n");
            sb.Append($"Sum Volume: {Volume}");
            sb.Append("\n");
            sb.Append($"Sum Weight: {Weight}");
            sb.Append("\n_________________________\n");

            return sb.ToString();
        }
    }
}

