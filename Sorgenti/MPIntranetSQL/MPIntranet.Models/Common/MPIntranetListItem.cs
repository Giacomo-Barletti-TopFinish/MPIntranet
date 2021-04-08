using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Common
{
    public class MPIntranetListItem : IEquatable<MPIntranetListItem>
    {
        public MPIntranetListItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public MPIntranetListItem()
        {
            Text = string.Empty;
            Value = string.Empty;
        }

        public string Text { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public bool Equals(MPIntranetListItem other)
        {
            if (other == null)
                return false;

            if (this.Value.Trim() == other.Value.Trim())
                return true;
            else
                return false;
        }

    }

    public class MPIntranetListItemComparer : IEqualityComparer<MPIntranetListItem>
    {
        public bool Equals(MPIntranetListItem x, MPIntranetListItem y)
        {
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Value == y.Value;
        }

        public int GetHashCode(MPIntranetListItem product)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(product, null)) return 0;

            //Get hash code for the Numf field if it is not null. 
            int hashNumf = product.Value == null ? 0 : product.Value.GetHashCode();

            return hashNumf;
        }
    }
}
