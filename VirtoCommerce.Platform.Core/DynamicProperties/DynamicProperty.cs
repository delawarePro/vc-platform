using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.DynamicProperties
{
    public class DynamicProperty : AuditableEntity, ICloneable
    {
        public string Name { get; set; }
        /// <summary>
        /// dynamic property description
        /// </summary>
        public string Description { get; set; }
        public string ObjectType { get; set; }
        /// <summary>
        /// Defines whether a property supports multiple values.
        /// </summary>
        public bool IsArray { get; set; }
        /// <summary>
        /// Dictionary has a predefined set of values. User can select one or more of them and cannot enter arbitrary values.
        /// </summary>
        public bool IsDictionary { get; set; }
        /// <summary>
        /// For multilingual properties user can enter different values for each of registered languages.
        /// </summary>
        public bool IsMultilingual { get; set; }
        public bool IsRequired { get; set; }
        public int? DisplayOrder { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DynamicPropertyValueType ValueType { get; set; }

        /// <summary>
        /// Property names for different languages.
        /// </summary>
        public DynamicPropertyName[] DisplayNames { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name ?? "n/a");
        }

        public virtual object Clone()
        {
            var dynamicProperty = new DynamicProperty();

            Copy(dynamicProperty);

            return dynamicProperty;
        }

        public void Copy(DynamicProperty property)
        {
            property.Id = Id;
            property.CreatedDate = CreatedDate;
            property.ModifiedDate = ModifiedDate;
            property.CreatedBy = CreatedBy;
            property.ModifiedBy = ModifiedBy;
            property.Name = Name;
            property.Description = Description;
            property.ObjectType = ObjectType;
            property.IsArray = IsArray;
            property.IsDictionary = IsDictionary;
            property.IsMultilingual = IsMultilingual;
            property.IsRequired = IsRequired;
            property.DisplayOrder = DisplayOrder;
            property.ValueType = ValueType;
            property.DisplayNames = DisplayNames == null ? null : DisplayNames.Select(n => n.Clone()).ToArray();
        }
    }
}
