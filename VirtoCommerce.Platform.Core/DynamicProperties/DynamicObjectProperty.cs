using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtoCommerce.Platform.Core.DynamicProperties
{
    public class DynamicObjectProperty : DynamicProperty, ICloneable
    {
        public string ObjectId { get; set; }
        public ICollection<DynamicPropertyObjectValue> Values { get; set; }

        public override string ToString()
        {
            var retVal = base.ToString();
            if (Values != null)
            {
                retVal += string.Format("[{0}]", Values.Count());
            }
            return retVal;
        }

        public override object Clone()
        {
            var dynamicObjProperty = new DynamicObjectProperty();

            Copy(dynamicObjProperty);

            dynamicObjProperty.ObjectId = ObjectId;
            dynamicObjProperty.Values = Values
                ?.Select(x => (DynamicPropertyObjectValue)x.Clone())
                .ToList();

            return dynamicObjProperty;
        }
    }
}
