
namespace Com.ZimVie.Wcs.Framework
{
    /// <summary>
    /// Value object for returning boolean only
    /// </summary>
    public class BooleanValueObject : ValueObject
    {
        /// <summary>
        /// get and set the boolean value to return boolean
        /// default value is false
        /// </summary>
        public bool BooleanValue { get; set; } = false;
    }
}
