using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
namespace sa.gov.libgph.Services
{
    public class PropertyExceptionHandler
    {
        private IPublishedElement[] Elements = { };
        public string Target { get; set; } = "";


        // Get Image URL
        /// <summary>
        /// Get the Image URL Or return # Grantee no exception thrown
        /// </summary>
        /// <param name="Element">The Element that has the Image</param>
        /// <param name="Property">The Image Property name</param>
        /// <returns>return The Image URL as string</returns>
        public bool GetBooleanValue(IPublishedElement Element, string Property)
        {
            bool Value = false;
            try
            {
              
                //Check if the element has the property or not
                if (Element.HasValue(Property))
                {
                    Value = Element.Value<Boolean>(Property);
                }

            }
            catch (Exception) { }

            return Value;
        }
        // Get Image URL
        /// <summary>
        /// Get the Image URL Or return # Grantee no exception thrown
        /// </summary>
        /// <param name="Element">The Element that has the Image</param>
        /// <param name="Property">The Image Property name</param>
        /// <returns>return The Image URL as string</returns>
        public string GetImageURL(IPublishedElement Element, string Property)
        {
            string Value = "#";
            try
            {
                //Check if the element has the property or not
                if (Element.HasValue(Property))
                {
                    Value = Element.Value<MediaWithCrops>(Property).Url();
                }

            }
            catch (Exception) { }

            return Value;
        }

        // Get Link URL
        /// <summary>
        /// Get the Link URL Or return # Grantee no exception thrown
        /// </summary>
        /// <param name="Element">The Element that has the Link</param>
        /// <param name="Property">The Link Property name</param>
        /// <returns>return The Link URL as string</returns>
        public string GetLink(IPublishedElement Element, string Property, string Value = "#")
        {

            try
            {
                //Check if the element has the property or not
                if (Element.HasValue(Property))
                {

                    Value = Element.Value<Link>(Property).Url;
                    Target = Element.Value<Link>(Property).Target;
                }

            }
            catch (Exception) { }

            return Value;
        }

        // Get Text Value
        /// <summary>
        /// Get the Value of the string Or return empty string Grantee no exception thrown
        /// </summary>
        /// <param name="Element">The Element that has the Text</param>
        /// <param name="Property">The Text Property name</param>
        /// <returns>return The Text or Empty string</returns>
        public string GetTextValue(IPublishedElement Element, string Property)
        {
            string Value = "";
            try
            {
                //Check if the element has the property or not
                if (Element.HasValue(Property))
                {
                    Value = Element.Value<string>(Property);
                }
            }
            catch (Exception) { }

            return Value;
        }

        // Get Date Value
        /// <summary>
        /// Get the Value of the string Or return empty string Grantee no exception thrown
        /// </summary>
        /// <param name="Element">The Element that has the Text</param>
        /// <param name="Property">The Text Property name</param>
        /// <returns>return The Text or Empty string</returns>
        public DateTime GetDateValue(IPublishedElement Element, string Property)
        {

            //string Value = "";
            DateTime Value = new DateTime();
            try
            {

                //Check if the element has the property or not
                if (Element.HasValue(Property))
                {
                    Value = Element.Value<DateTime>(Property);
                }
            }
            catch (Exception) { }

            return Value;
        }

        // Get Elements Array
        /// <summary>
        /// Get Array of the IPublishedElement Or return empty one Grantee no exception thrown
        /// </summary>
        /// <param name="Element">The Element that has the Array</param>
        /// <param name="Property">The List/Array Property name</param>
        /// <returns>return The Array of IPublishedElement</returns>
        public IPublishedElement[] GetElementsArray(IPublishedElement Element, string Property)
        {
            try
            {
                if (Element.HasValue(Property))
                {

                    Elements = Element.Value<IEnumerable<IPublishedElement>>(Property).ToArray();

                }
            }
            catch (Exception) { }

            return Elements;
        }

    }
}