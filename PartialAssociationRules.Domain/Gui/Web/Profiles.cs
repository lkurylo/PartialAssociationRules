/* Copyright 2011 Łukasz Kuryło
 * Program wykonany w ramach pracy magisterskiej 'Częściowe reguły asocjacyjne'
 * Wykorzystanie oraz modyfikacja kodu bez zgody autora zabroniona.
 */

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Xml.Linq;

namespace PartialAssociationRules.Domain.Gui.Web
{
    public class PARProfile : ProfileBase
    {
        public void Reset()
        {

        }

        //private static new SettingsPropertyCollection properties;
        //private new SettingsPropertyCollection Properties
        //{
        //    get
        //    {
        //        if (properties == null)
        //        {
        //            properties = (SettingsPropertyCollection)this.GetPropertyValues("ObjectsQuantity");
        //        }

        //        return properties;
        //    }
        //}

        int gg;
        public int ObjectsQuantity
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("ObjectsQuantity"));// Properties["ObjectsQuantity"]);
            }
            set
            {
                // this["ObjectsQuantity"] 
                gg = value;
            }
        }

        public int AttributesQuantity
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("AttributesQuantity"));
            }
            set
            {
                gg = value;
            }
        }

        public decimal Alpha
        {
            get
            {
                return Convert.ToDecimal(this.GetPropertyValue("Alpha"));
            }
            set
            {
                this["Alpha"] = value;
            }
        }

        public decimal Gamma
        {
            get
            {
                return Convert.ToDecimal(this.GetPropertyValue("Gamma"));
            }
            set
            {
                this["Gamma"] = value;
            }
        }

        public decimal Support
        {
            get
            {
                return Convert.ToDecimal(this.GetPropertyValue("Support"));
            }
            set
            {
                this["Support"] = value;
            }
        }

        public decimal Confidence
        {
            get
            {
                return Convert.ToDecimal(this.GetPropertyValue("Confidence"));
            }
            set
            {
                this["Confidence"] = value;
            }
        }

        public int DefaultAlgorithm
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("DefaultAlgorithm"));
            }
            set
            {
                this["DefaultAlgorithm"] = value;
            }
        }

        public bool TrimDataSet
        {
            get
            {
                return Convert.ToBoolean(this.GetPropertyValue("TrimDataSet"));
            }
            set
            {
                this["TrimDataSet"] = value;
            }
        }

        public int DefaultGenerator
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("DefaultGenerator"));
            }
            set
            {
                this["DefaultGenerator"] = value;
            }
        }

        public string DefaultFilesCatalog
        {
            get
            {
                return Convert.ToString(this.GetPropertyValue("DefaultFilesCatalog"));
            }
            set
            {
                this["DefaultFilesCatalog"] = value;
            }
        }

        public int MinimalWeight
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("MinimalWeight"));
            }
            set
            {
                this["MinimalWeight"] = value;
            }
        }

        public int MaximalWeight
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("MaximalWeight"));
            }
            set
            {
                this["MaximalWeight"] = value;
            }
        }

        public int DefaultReport
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("DefaultReport"));
            }
            set
            {
                this["DefaultReport"] = value;
            }
        }

        public bool InsertInfSysInReport
        {
            get
            {
                return Convert.ToBoolean(this.GetPropertyValue("InsertInfSysInReport"));
            }
            set
            {
                this["InsertInfSysInReport"] = value;
            }
        }

        public int DefaultRegexIndex
        {
            get
            {
                return Convert.ToInt32(this.GetPropertyValue("DefaultRegexIndex"));
            }
            set
            {
                this["DefaultRegexIndex"] = value;
            }
        }

        public string RegexForNamesHeader
        {
            get
            {
                return Convert.ToString(this.GetPropertyValue("RegexForNamesHeader"));
            }
            set
            {
                this["RegexForNamesHeader"] = value;
            }
        }

        public bool PercentageOfSeparatedRows
        {
            get
            {
                return Convert.ToBoolean(this.GetPropertyValue("PercentageOfSeparatedRows"));
            }
            set
            {
                this["PercentageOfSeparatedRows"] = value;
            }
        }
    }

    public class PARProfilesProvider : ProfileProvider
    {
        #region not needed

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, System.DateTime userInactiveSinceDate)
        {
            throw new System.NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new System.NotImplementedException();
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new System.NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, System.DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, System.DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, System.DateTime userInactiveSinceDate)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        public override System.Configuration.SettingsPropertyValueCollection GetPropertyValues
            (System.Configuration.SettingsContext context, System.Configuration.SettingsPropertyCollection collection)
        {
            XDocument xdoc = XDocument.Load(new StreamReader(HttpRuntime.BinDirectory + "app.config"));

            var settings = xdoc.Element("configuration").Element("userSettings")
                .Element("PartialAssociationRules.Domain.ApplicationSettings").Descendants("setting");

            var result = new SettingsPropertyValueCollection();
            foreach (SettingsProperty singleProperty in collection)
            {
                var value = settings
                                    .Where(x => x.Attribute("name").Value == singleProperty.Name)
                                    .Select(x => x.Element("value").Value).First().Replace('.',',');
         
                result.Add(
                                new SettingsPropertyValue(singleProperty)
                                {
                                    PropertyValue = Convert.ChangeType(value, singleProperty.PropertyType)
                                });
            }

            return result;
        }

        public override void SetPropertyValues(System.Configuration.SettingsContext context,
            System.Configuration.SettingsPropertyValueCollection collection)
        {
           // throw new System.NotImplementedException();
        }
    }
}