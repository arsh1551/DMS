﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Emails.Templates
{
    public partial class Registration : RegistrationBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n<html>\r\n<body>\r\n\t-ms-border-radius:5px; background:#fff; padding:30px; margin:1" +
                    "00px auto\">\r\n    <section style=\"background:#fff; padding:10px 0px; border-botto" +
                    "m:#086ea1\"><img src=\"");

#line 13 "D:\Frameworks\New folder\HealthFramework\ServiceLayer\Emails\Templates\Registration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(HostDomain));

#line default
#line hidden
            this.Write("app/img/logo.png\" alt=\"logo\" title=\"logo\" width=\"200\" />\r\n    </section>\r\n    <h2" +
                    " style=\"font-size:15px; font-family:Arial, Helvetica, sans-serif !important; col" +
                    "or:#086ea1;\">\r\n    \tDear ");

#line 16 "D:\Frameworks\New folder\HealthFramework\ServiceLayer\Emails\Templates\Registration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FullName));

#line default
#line hidden
            this.Write(@",
    </h2>
    <h1 style=""font-size:16px; font-family:Arial, Helvetica, sans-serif !important; color:#086ea1;""> A very warm welcome to Smartdata.  </h1>
    <p style=""color:#3d3d3d; font-size:14px; font-family:Arial, Helvetica, sans-serif; "">Your login credentials are below, so be sure to save this e-mail somewhere safe. </p>
    <p style=""color:#3d3d3d; font-size:14px; padding:0px 0px; font-family:Arial, Helvetica, sans-serif; margin:0px;""><b style=""color:#5c5c5c; font-style:italic;"">UserName/Email:</b> ");

#line 20 "D:\Frameworks\New folder\HealthFramework\ServiceLayer\Emails\Templates\Registration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Email));

#line default
#line hidden
            this.Write(@"</p>
    <p style=""color:#3d3d3d; font-size:14px; padding:0px 0px 10px 0; font-family:Arial, Helvetica, sans-serif;  margin:0px;""><b style=""color:#5c5c5c; font-style:italic;"">Password:</b> <em>Only you know that! (Hint: It’s the password you created...) </em> </p>
<p style=""color:#3d3d3d; font-size:14px; font-family:Arial, Helvetica, sans-serif; "">Forgot your password? No problem. Click <a href=""");

#line 22 "D:\Frameworks\New folder\HealthFramework\ServiceLayer\Emails\Templates\Registration.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(HostDomain));

#line default
#line hidden
            this.Write(@"app/index.html#/forgotpassword"">here</a> to reset it.  </p>
    <p style=""color:#3d3d3d; font-size:14px; padding:10px 0px; font-family:Arial, Helvetica, sans-serif; "">Need help getting started?</p>
<h1 style=""font-size:16px; font-family:Arial, Helvetica, sans-serif !important; color:#086ea1;""> <a href=""http://support.Smartdata.com/hc/en-us"">Knowledge Base</a> </h1>
<p style=""color:#3d3d3d; font-size:14px; padding:10px 0px; font-family:Arial, Helvetica, sans-serif; ""> Got a question? The Smartdata Knowledge Base has an answer. Our Knowledge Base is your one-stop shop for helpful articles and how-to guides, as well as technical product documentation. </p> 
<h1 style=""font-size:16px; font-family:Arial, Helvetica, sans-serif !important; color:#086ea1;""> <a href=""http://support.Smartdata.com/hc/en-us"">Video Tutorials</a> </h1>
<p style=""color:#3d3d3d; font-size:14px; padding:10px 0px; font-family:Arial, Helvetica, sans-serif; ""> Watch our easy-to-follow video tutorials for tips on how to create and manage your Smartdata account. </p> 
    <h3 style=""color:#30aee3; font-family:Arial, Helvetica, sans-serif; font-size:15px; margin:12px 0 0 0;"">Regards</h3>
    <h2 style=""color:#5c5c5c; font-size:15px; font-family:Arial, Helvetica, sans-serif !important; margin:5px 0px 20px 0;"">Team Smartdata</h2>
</section>
</body>
</html>");
            return this.GenerationEnvironment.ToString();
        }

#line 1 "D:\Frameworks\New folder\HealthFramework\ServiceLayer\Emails\Templates\Registration.tt"

        private string _HostDomainField;

        /// <summary>
        /// Access the HostDomain parameter of the template.
        /// </summary>
        private string HostDomain
        {
            get
            {
                return this._HostDomainField;
            }
        }

        private string _FullNameField;

        /// <summary>
        /// Access the FullName parameter of the template.
        /// </summary>
        private string FullName
        {
            get
            {
                return this._FullNameField;
            }
        }

        private string _EmailField;

        /// <summary>
        /// Access the Email parameter of the template.
        /// </summary>
        private string Email
        {
            get
            {
                return this._EmailField;
            }
        }


        /// <summary>
        /// Initialize the template
        /// </summary>
        public virtual void Initialize()
        {
            if ((this.Errors.HasErrors == false))
            {
                bool HostDomainValueAcquired = false;
                if (this.Session.ContainsKey("HostDomain"))
                {
                    this._HostDomainField = ((string)(this.Session["HostDomain"]));
                    HostDomainValueAcquired = true;
                }
                if ((HostDomainValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("HostDomain");
                    if ((data != null))
                    {
                        this._HostDomainField = ((string)(data));
                    }
                }
                bool FullNameValueAcquired = false;
                if (this.Session.ContainsKey("FullName"))
                {
                    this._FullNameField = ((string)(this.Session["FullName"]));
                    FullNameValueAcquired = true;
                }
                if ((FullNameValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("FullName");
                    if ((data != null))
                    {
                        this._FullNameField = ((string)(data));
                    }
                }
                bool EmailValueAcquired = false;
                if (this.Session.ContainsKey("Email"))
                {
                    this._EmailField = ((string)(this.Session["Email"]));
                    EmailValueAcquired = true;
                }
                if ((EmailValueAcquired == false))
                {
                    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Email");
                    if ((data != null))
                    {
                        this._EmailField = ((string)(data));
                    }
                }


            }
        }



#line default
#line hidden
    }

#line default
#line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class RegistrationBase
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
            private System.IFormatProvider formatProviderField = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField = value;
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
