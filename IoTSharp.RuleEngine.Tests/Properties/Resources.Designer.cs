﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IoTSharp.RuleEngine.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IoTSharp.RuleEngine.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 {
        ///    &quot;Head&quot;: {
        ///        &quot;NetNo&quot;: &quot;01&quot;,
        ///        &quot;PlazaNo&quot;: &quot;24&quot;,
        ///        &quot;LaneID&quot;: &quot;X01&quot;,
        ///        &quot;DDHM&quot;: &quot;20200407120523&quot;,
        ///        &quot;LaneType&quot;: 1,
        ///        &quot;MsgLen&quot;: &quot;&quot;,
        ///        &quot;MsgType&quot;: &quot;XW&quot;,
        ///        &quot;MsgVersion&quot;: &quot;&quot;,
        ///        &quot;Reserved&quot;: &quot;&quot;
        ///    },
        ///    &quot;SubHead&quot;: {
        ///        &quot;LaneMode&quot;: 1,
        ///        &quot;CETC&quot;: 0,
        ///        &quot;StaffID&quot;: &quot;999999&quot;,
        ///        &quot;StaffName&quot;: &quot;测试工号1&quot;,
        ///        &quot;JobNo&quot;: &quot;19&quot;,
        ///        &quot;SquadID&quot;: 0,
        ///        &quot;ShiftNo&quot;: 0
        ///    },
        ///    &quot;MsgT_Exit_Waste&quot;: {
        ///        &quot;ID&quot;: &quot;G000765005 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string MsgT_Exit_Waste {
            get {
                return ResourceManager.GetString("MsgT_Exit_Waste", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {
        ///    &quot;Head&quot;: {
        ///        &quot;NetNo&quot;: &quot;01&quot;,
        ///        &quot;PlazaNo&quot;: &quot;24&quot;,
        ///        &quot;LaneID&quot;: &quot;X01&quot;,
        ///        &quot;DDHM&quot;: &quot;20200407110000&quot;,
        ///        &quot;LaneType&quot;: 1,
        ///        &quot;MsgLen&quot;: &quot;&quot;,
        ///        &quot;MsgType&quot;: &quot;HT&quot;,
        ///        &quot;MsgVersion&quot;: &quot;&quot;,
        ///        &quot;Reserved&quot;: &quot;&quot;
        ///    },
        ///    &quot;SubHead&quot;: {
        ///        &quot;LaneMode&quot;: 0,
        ///        &quot;CETC&quot;: 0,
        ///        &quot;StaffID&quot;: &quot;&quot;,
        ///        &quot;StaffName&quot;: &quot;&quot;,
        ///        &quot;JobNo&quot;: &quot;&quot;,
        ///        &quot;SquadID&quot;: 0,
        ///        &quot;ShiftNo&quot;: 0
        ///    },
        ///    &quot;MsgT_Hourtraffic&quot;: {
        ///        &quot;ID&quot;: &quot;G000765005009020100402 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string MsgT_Hourtraffic {
            get {
                return ResourceManager.GetString("MsgT_Hourtraffic", resourceCulture);
            }
        }
    }
}
