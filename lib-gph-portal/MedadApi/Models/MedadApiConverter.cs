using Newtonsoft.Json.Linq;
using sa.gov.libgph.MedadApi.Models.Response;

namespace sa.gov.libgph.MedadApi.Models
{
    public class MedadApiConverter
    {
        public MarcDetails GetMarkDetails(JArray jArray)
        {
            var details = new MarcDetails();
            for (int i = 0; i < jArray.Count; i++)
            {
                if (jArray[i].First.Path.Contains("001"))
                {
                    details.TuningNumber = jArray[i].ToObject<__001>()._001;
                }
                if (jArray[i].First.Path.Contains("003"))
                {
                    details.SettingNumberSpecifier = jArray[i].ToObject<__003>()._003;
                }
                if (jArray[i].First.Path.Contains("005"))
                {
                    details.DateMark = jArray[i].ToObject<__005>()._005;
                }
                if (jArray[i].First.Path.Contains("008"))
                {
                    details.ConstField = jArray[i].ToObject<__008>()._008;
                }
                if (jArray[i].First.Path.Contains("082"))
                {
                    var tag082 = jArray[i].ToObject<__082>();
                    var jArray0082 = JArray.FromObject(tag082.tag082Object.subfields);

                    for (int i1 = 0; i1 < jArray0082.Count; i1++)
                    {
                        if (jArray0082[i1].First.Path.Contains("a"))
                        {
                            details.DyweeNumber += jArray0082[i1].First.First.ToString();
                        }
                        else if (jArray0082[i1].First.Path.Contains("b"))
                        {
                            details.DyweeNumber += jArray0082[i1].First.First.ToString();
                        }
                        else if (jArray0082[i1].First.Path.Contains("2"))
                        {
                            details.DyweeNumber += jArray0082[i1].First.First.ToString();

                        }
                        else if (jArray0082[i1].First.Path.Contains("q"))
                        {
                            details.DyweeNumber += jArray0082[i1].First.First.ToString();

                        }
                    }
                    details.DyweeNumber += "<br>";
                }

                if (jArray[i].First.Path.Contains("245"))
                {

                    var tag245 = jArray[i].ToObject<__245>();
                    var jArray0245 = JArray.FromObject(tag245.tag245Object.subfields);

                    for (int i1 = 0; i1 < jArray0245.Count; i1++)
                    {
                        if (jArray0245[i1].First.Path.Contains("a"))
                        {
                            details.Author += jArray0245[i1].First.First.ToString() + " ";
                        }

                        else if (jArray0245[i1].First.Path.Contains("c"))
                        {
                            details.Author += jArray0245[i1].First.First.ToString() + " ";

                        }

                    }
                    details.Author += "<br>";
                }
                if (jArray[i].First.Path.Contains("260"))
                {

                    //بيانات النشر:
                    var tag260 = jArray[i].ToObject<__260>();
                    var jArray0260 = JArray.FromObject(tag260.tag260Object.subfields);


                    for (int i1 = 0; i1 < jArray0260.Count; i1++)
                    {
                        if (jArray0260[i1].First.Path.Contains("a"))
                        {
                            details.Publisher += jArray0260[i1].First.First.ToString() + " ";
                        }
                        else if (jArray0260[i1].First.Path.Contains("b"))
                        {
                            details.Publisher += jArray0260[i1].First.First.ToString() + " ";
                        }
                        else if (jArray0260[i1].First.Path.Contains("c"))
                        {
                            details.Publisher += jArray0260[i1].First.First.ToString() + " ";

                        }
                        else if (jArray0260[i1].First.Path.Contains("m"))
                        {
                            details.Publisher += jArray0260[i1].First.First.ToString() + " ";

                        }
                        else if (jArray0260[i1].First.Path.Contains("f"))
                        {
                            details.Publisher += jArray0260[i1].First.First.ToString() + " ";
                        }
                    }
                    details.Publisher += "<br>";
                }
                if (jArray[i].First.Path.Contains("035"))
                {

                    //بيانات النشر:
                    var tag035 = jArray[i].ToObject<__035>();
                    var jArray0035 = JArray.FromObject(tag035.tag035Object.subfields);


                    for (int i1 = 0; i1 < jArray0035.Count; i1++)
                    {
                        if (jArray0035[i1].First.Path.Contains("a"))
                        {
                            details.LocalNumber += jArray0035[i1].First.First.ToString() + " ";
                        }

                    }
                    details.LocalNumber += "<br>";
                }


                if (jArray[i].First.Path.Contains("300"))
                {

                    var tag300 = jArray[i].ToObject<__300>();
                    var jArray0300 = JArray.FromObject(tag300.tag300Object.subfields);

                    for (int i1 = 0; i1 < jArray0300.Count; i1++)
                    {
                        if (jArray0300[i1].First.Path.Contains("a"))
                        {
                            details.OrdinaryDescription += jArray0300[i1].First.First.ToString() + " ";
                        }

                        else if (jArray0300[i1].First.Path.Contains("c"))
                        {
                            details.OrdinaryDescription += jArray0300[i1].First.First.ToString() + " ";

                        }

                    }
                    details.OrdinaryDescription += "<br>";
                }
                if (jArray[i].First.Path.Contains("650"))
                {

                    var tag650 = jArray[i].ToObject<__650>();
                    var jArray0650 = JArray.FromObject(tag650.tag650Object.subfields);

                    for (int i1 = 0; i1 < jArray0650.Count; i1++)
                    {
                        if (jArray0650[i1].First.Path.Contains("a"))
                        {
                            details.ObjectiveConcept += jArray0650[i1].First.First.ToString() + " ";
                        }

                        else if (jArray0650[i1].First.Path.Contains("x"))
                        {
                            details.ObjectiveConcept += jArray0650[i1].First.First.ToString() + " ";

                        }

                    }
                    details.ObjectiveConcept += "<br>";
                }
            }


            return details;
        }
    }
}