using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

using APITester.Models.Extensions;
using APITester.Models.Enums;
namespace APITester.Models
{
    public class SQLCommandConfigurationSection : ConfigurationSection
    {
        public SQLCommandConfigurationSection() { }
        [ConfigurationProperty("Name",
     IsRequired = true,
     IsKey = true)]
        [StringValidator(InvalidCharacters =
     "~!@#$%^&*()[]{}/;'\"|\\",
     MinLength = 0, MaxLength = 60)]
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }

        [ConfigurationProperty("SQLCommadGroups",
            IsDefaultCollection = false)]
        public SQLCommadGroupsConfigurationCollection SQLCommandGroups
        {
            get => (SQLCommadGroupsConfigurationCollection)base ["SQLCommadGroups"];
        }
    }

    public class SQLCommadGroupsConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SQLCommadGroupConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SQLCommadGroupConfigurationElement)element).Name;
        }

        [ConfigurationProperty("Filters",
            IsDefaultCollection = false)]
        public FilterConfigurationElementCollection Filters
        {
            get => (FilterConfigurationElementCollection)this["Filters"];
            set => this["Filters"] = value;
        }
    }

    public class SQLCommadGroupConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("Name",
             IsRequired = true,
             IsKey = true)]
        [StringValidator(InvalidCharacters =
             "~!@#$%^&*()[]{}/;'\"|\\",
             MinLength = 0, MaxLength = 60)]
        public string Name
        {
            get => (string)this["Name"];
            set => this["Name"] = value;
        }

        [ConfigurationProperty("SQLCommands",
            IsDefaultCollection = false)]
        public SQLCommandConfigurationElementCollection SQLCommands
        {
            get => (SQLCommandConfigurationElementCollection)this["SQLCommands"];
        }

        [ConfigurationProperty("Filters",
            IsDefaultCollection = false)]
        public FilterConfigurationElementCollection Filters
        {
            get => (FilterConfigurationElementCollection)this["Filters"];
            set => this["Filters"] = value;
        }
    }

    public class SQLCommandConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return  new SQLCommandConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SQLCommandConfigurationElement)element).Name;
        }
    }

    public class SQLCommandConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("Name",
             IsRequired = true,
             IsKey = true)]
        [StringValidator(InvalidCharacters =
             "~!@#$%^&*()[]{}/;'\"|\\",
             MinLength = 0, MaxLength = 60)]
        public string Name
        {
            get =>  (string)this["Name"];
            set =>  this["Name"] = value;
        }

        [ConfigurationProperty("SQLSource",
             IsRequired = true,
             IsKey = false)]
        public string Source
        {
            get => (string)this["SQLSource"];
            set => this["SQLSource"] = value;
        }

        [ConfigurationProperty("SQLSourceType",
             IsRequired = true,
             IsKey = false)]
        public SQLSourceType SourceType
        {
            get => (SQLSourceType)this["SQLSourceType"];
            set => this["SQLSourceType"] = value;
        }

        [ConfigurationProperty("SQLCommandType",
             IsRequired = true,
             IsKey = false)]
        public SQLCommandType CommandType
        {
            get => (SQLCommandType)this["SQLCommandType"];
            set => this["SQLCommandType"] = value;
        }

        [ConfigurationProperty("Filters",
            IsDefaultCollection = false)]
        public FilterConfigurationElementCollection Filters
        {
            get => (FilterConfigurationElementCollection)this["Filters"];
            set => this["Filters"] = value;
        }
    }

    public class FilterConfigurationElementCollection : ConfigurationElementCollection
    {
        public FilterConfigurationElementCollection() { }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FilterConfigurationElement();
        }

        public new ConfigurationElement CreateNewElement(string elementName)
        {
            return new FilterConfigurationElement(elementName);
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((FilterConfigurationElement)element).Name;
        }

        public new string AddElementName
        {
            get { return base.AddElementName; }
            set { base.AddElementName = value; }
        }

        public new string ClearElementName
        {
            get { return base.ClearElementName; }
            set { base.ClearElementName = value; }

        }

        public new string RemoveElementName
        {
            get { return base.RemoveElementName; }
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public FilterConfigurationElement this[int index]
        {
            get
            {
                return (FilterConfigurationElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public FilterConfigurationElement this[string Name]
        {
            get
            {
                return (FilterConfigurationElement)BaseGet(Name);
            }
        }

        public int IndexOf(FilterConfigurationElement sPMappingElement)
        {
            return BaseIndexOf(sPMappingElement as FilterConfigurationElement);
        }

        public void Add(FilterConfigurationElement sPMappingElement)
        {
            BaseAdd(sPMappingElement as FilterConfigurationElement);
        }

        protected override void
            BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(FilterConfigurationElement sPMappingElement)
        {
            if (BaseIndexOf(sPMappingElement as FilterConfigurationElement) >= 0)
                BaseRemove(sPMappingElement.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }

    public class FilterConfigurationElement : ConfigurationElement
    {
        public FilterConfigurationElement() { }

        public FilterConfigurationElement(string name)
        {
            Name = name;
        }

        [ConfigurationProperty("Name",
            IsKey = true,
            IsRequired = true)]
        [StringValidator(InvalidCharacters =
            " ~!@#$%^&*()[]{}/;'\"|\\",
            MaxLength = 60)]
        public string Name
        {
            get { return this["Name"] as string; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Field",
            IsRequired = true)]
        public string Field
        {
            get { return this["Field"] as string; }
            set { this["Field"] = value; }
        }

        [ConfigurationProperty("Restriction",
            IsRequired = true)]
        public RestrictionConfigurationElement Restriction
        {
            get { return this["Restriction"] as RestrictionConfigurationElement; }
            set { this["Restriction"] = value; }
        }

        [ConfigurationProperty("LogicalAnd",
            IsRequired = false,
            DefaultValue = true)]
        public bool LogicalAnd
        {
            get { return (bool)this["LogicalAnd"]; }
            set { this["LogicalAnd"] = value; }
        }
    }

    public class RestrictionConfigurationElement : ConfigurationElement
    {
        public RestrictionConfigurationElement() { }

        public RestrictionConfigurationElement(string name)
        {
            Name = name;
        }

        [ConfigurationProperty("Name",
            IsKey = true,
            IsRequired = true)]
        [StringValidator(InvalidCharacters =
            " ~!@#$%^&*()[]{}/;'\"|\\",
            MaxLength = 60)]
        public string Name
        {
            get { return this["Name"] as string; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Operator",
            IsRequired = true)]
        public FilterOperator Operator
        {
            get { return (FilterOperator)this["Operator"]; }
            set { this["Operator"] = value; }
        }

        [ConfigurationProperty("Values",
            IsRequired = false)]
        public string ValueString
        {
            get { return this["Values"] as string; }
            set { this["Values"] = value; }
        }

        [ConfigurationProperty("DataType",
            DefaultValue = "System.String",
            IsRequired = false)]
        public string DataType
        {
            get { return this["DataType"] as string; }
            set { this["DataType"] = value; }
        }

        public object[] Values
        {
            get
            {
                MethodInfo method =typeof(string).GetMethod("CSV2List");
                MethodInfo genericMethod = method.MakeGenericMethod(_DataType);
                return (object[])genericMethod.Invoke(ValueString, null);
            }
            set
            {
                ValueString = value.ArrayToCSV(',');
            }
        }

        public object Value
        {
            get => Values.Length > 0 ? Values[0] : default;
        }

        public Type _DataType
        {
            get
            {
                return Type.GetType(DataType);
            }
            set
            {
                DataType = value.FullName;
            }
        }
    }

}
