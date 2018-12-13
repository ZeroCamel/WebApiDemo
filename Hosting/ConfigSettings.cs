using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 根据app.config 配置定义相应的节和配置元素类型
/// </summary>
namespace Hosting
{
    /// <summary>
    /// 自定义节点继承该类
    /// </summary>
    public class PreLoadedAssembliesSettings : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public AssemblyElementCollection AssemblyNames
        {
            get { return (AssemblyElementCollection)this[""]; }
        }

        public static PreLoadedAssembliesSettings GetSection()
        {
            return ConfigurationManager.GetSection("preLoadedAssemblies") as PreLoadedAssembliesSettings;
        }
    }

    /// <summary>
    /// 一个子元素集合的配置元素
    /// 集合型配置元素
    /// </summary>
    public class AssemblyElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AssemblyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            AssemblyElement serviceTypeElement = (AssemblyElement)element;
            return serviceTypeElement.AssemblyName;
        }
    }

    /// <summary>
    /// 配置文件内的一个元素
    /// 单一型配置元素
    /// </summary>
    public class AssemblyElement : ConfigurationElement
    {
        [ConfigurationProperty("assemblyName", IsRequired = true)]
        public string AssemblyName
        {
            get { return (string)this["assemblyName"]; }
            set { this["assemblyName"] = value; }
        }
    }
}
