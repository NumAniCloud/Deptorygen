﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 16.0.0.0
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Deprovgen.Generator
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class FactoryTemplate : FactoryTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("// <autogenerated />\r\n");
            
            #line 8 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var ns in Factory.GetRequiredNamespaces()) {  
            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 9 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 10 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  }  
            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 12 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.NameSpace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    ");
            
            #line 14 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.GetAccessibility()));
            
            #line default
            #line hidden
            this.Write(" partial class ");
            
            #line 14 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.TypeName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 14 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.InterfaceName));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 15 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  if(Factory.DoSupportGenericHost) { 
            
            #line default
            #line hidden
            this.Write("        , IDeprovgenFactory\r\n");
            
            #line 17 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    {\r\n");
            
            #line 19 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var dependency in Factory.Dependencies) { 
            
            #line default
            #line hidden
            this.Write("        private readonly ");
            
            #line 20 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dependency.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 20 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dependency.FieldName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 21 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  } 
            
            #line default
            #line hidden
            
            #line 22 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var capture in Factory.Captures) {  
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 23 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(capture.InterfaceName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 23 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(capture.PropertyName));
            
            #line default
            #line hidden
            this.Write(" { get; }\r\n");
            
            #line 24 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  }  
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 26 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var resolver in Factory.Resolvers.Where(x => !x.IsTransient)) {  
            
            #line default
            #line hidden
            this.Write("        private ");
            
            #line 27 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ServiceType.TypeName));
            
            #line default
            #line hidden
            this.Write("? ");
            
            #line 27 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.CacheVarName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 28 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 30 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.TypeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 30 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.GetConstructorParameterList()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n");
            
            #line 32 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var dependency in Factory.Dependencies) { 
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 33 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dependency.FieldName));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 33 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dependency.ParameterName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 34 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  } 
            
            #line default
            #line hidden
            
            #line 35 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var capture in Factory.Captures) { 
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 36 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(capture.PropertyName));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 36 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(capture.ParameterName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 37 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  }  
            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 39 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var resolver in Factory.Resolvers){ 
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 41 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ReturnType.Name));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 41 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.MethodName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 41 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.GetParameterList()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n");
            
            #line 43 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      if(resolver.IsTransient) { 
            
            #line default
            #line hidden
            this.Write("            return new ");
            
            #line 44 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ServiceType.TypeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 44 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ServiceType.GetConstructorArgList(resolver.Parameters, Factory)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 45 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      } else { 
            
            #line default
            #line hidden
            this.Write("            return ");
            
            #line 46 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.CacheVarName));
            
            #line default
            #line hidden
            this.Write(" ??= new ");
            
            #line 46 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ServiceType.TypeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 46 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ServiceType.GetConstructorArgList(resolver.Parameters, Factory)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 47 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      }  
            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 49 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  } 
            
            #line default
            #line hidden
            
            #line 50 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  foreach(var child in Factory.Children) { 
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 52 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.TypeName));
            
            #line default
            #line hidden
            this.Write(" Resolve");
            
            #line 52 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.TypeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 52 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.GetResolverParameterList(Factory)));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            return new ");
            
            #line 54 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.TypeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 54 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.GetResolverArgList(Factory)));
            
            #line default
            #line hidden
            this.Write(");\r\n        }\r\n");
            
            #line 56 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  }  
            
            #line default
            #line hidden
            
            #line 57 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  if(Factory.DoSupportGenericHost) {  
            
            #line default
            #line hidden
            this.Write("        public void ConfigureServices(IServiceCollection services)\r\n        {\r\n");
            
            #line 60 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      foreach(var resolver in Factory.Resolvers.Where(x => x.Parameters.Length == 0)) {  
            
            #line default
            #line hidden
            this.Write("            services.AddTransient<");
            
            #line 61 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.ReturnType.Name));
            
            #line default
            #line hidden
            this.Write(">(provider => ");
            
            #line 61 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resolver.MethodName));
            
            #line default
            #line hidden
            this.Write("());\r\n");
            
            #line 62 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      }  
            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 64 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  }  
            
            #line default
            #line hidden
            this.Write("    }\r\n\r\n");
            
            #line 67 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  if(Factory.Children.Any()) { 
            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 68 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.GetAccessibility()));
            
            #line default
            #line hidden
            this.Write(" static class ");
            
            #line 68 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.TypeName));
            
            #line default
            #line hidden
            this.Write("Extensions\r\n    {\r\n");
            
            #line 70 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      foreach(var child in Factory.Children) { 
            
            #line default
            #line hidden
            this.Write("        public static ");
            
            #line 71 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.TypeName));
            
            #line default
            #line hidden
            this.Write(" Resolve");
            
            #line 71 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.TypeName));
            
            #line default
            #line hidden
            this.Write("(this ");
            
            #line 71 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.InterfaceName));
            
            #line default
            #line hidden
            this.Write(" self, ");
            
            #line 71 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.GetResolverParameterList(Factory)));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            return self is ");
            
            #line 73 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.TypeName));
            
            #line default
            #line hidden
            this.Write(" concrete ? concrete.Resolve");
            
            #line 73 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.TypeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 73 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(child.GetResolverArgListForExtension(Factory)));
            
            #line default
            #line hidden
            this.Write(")\r\n                : throw new NotImplementedException(\"このメソッドは ");
            
            #line 74 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Factory.TypeName));
            
            #line default
            #line hidden
            this.Write(" クラスに対してのみ呼び出せます。\");\r\n        }\r\n");
            
            #line 76 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
      }  
            
            #line default
            #line hidden
            this.Write("    }\r\n");
            
            #line 78 "D:\Naohiro\Documents\Repos2\Tools\Deprovgen\Deprovgen\Deprovgen\Generator\FactoryTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class FactoryTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
