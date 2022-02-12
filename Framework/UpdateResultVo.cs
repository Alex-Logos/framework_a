
namespace Com.ZimVie.Wcs.Framework
{
    public class UpdateResultVo : ValueObject
    {
        /// <summary>
        /// get and set the executed result using executenonquery from db
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// get and set the key value after insert using execute scalar value 
        /// </summary>
        public int KeyId { get; set; }
    }
}
