using Microsoft.WindowsAzure;
using NLog.Config;
using NLog.LayoutRenderers;
using System.Text;

namespace NLog.WindowsAzure.Configuration
{
    [LayoutRenderer("cloudconfig")]
    public class CloudConfigLayoutRenderer : LayoutRenderer
    {
        ///<summary>
        /// The AppSetting name.
        ///</summary>
        [RequiredParameter]
        [DefaultParameter]
        public string Name { get; set; }

        ///<summary>
        /// The default value to render if the AppSetting value is null.
        ///</summary>
        public string Default { get; set; }      


        /// <summary>
        /// Renders the specified application setting or default value and appends it to the specified <see cref="StringBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
        /// <param name="logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if (Name == null)
            {
                return;
            }
            
            string value = CloudConfigurationManager.GetSetting(Name);
            if (value == null && Default != null)
            {
                value = Default;
            }

            if (string.IsNullOrEmpty(value) == false)
            {
                builder.Append(value);
            }
        }        
    }
}
