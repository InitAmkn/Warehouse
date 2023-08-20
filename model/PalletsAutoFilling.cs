using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal class PalletsAutoFilling<T> where T : Storage
    {
        List<T> contains;
        List<Pallet> pallets;

        List<PalletWithContents> filledPallets;

        public PalletsAutoFilling(List<T> contains, List<Pallet> pallets)
        {
            this.contains = contains;
            this.pallets = pallets;
            filledPallets = new List<PalletWithContents>();
            fillThePallets();
        }

        public List<PalletWithContents> getFilledPallets()
        {
            return filledPallets;
        }
        private void fillThePallets()
        {

            foreach (var item in pallets)
            {
                PalletWithContents palletWithContents = new PalletWithContents(item);
                filledPallets.Add(palletWithContents);
            }

            List<T> cantTakenContains = new List<T>();
            while (contains.Count() >0)
            {
                foreach (var item in filledPallets)
                {
                    if (item.addContains(contains[contains.Count-1]))
                    {
                        break;
                    }
                } 
                contains.Remove(contains[contains.Count - 1]);
            }
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n############################\n");
            foreach (var item in filledPallets)
            {
                sb.Append(item);
            }
            sb.Append("\n############################\n");

            return sb.ToString();
        }

    }
}
