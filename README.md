# NLog.WindowsAzure.Configuration
The NLog Windows Azure Configuration Package allows utilizing configuration settings from Microsoft.WindowsAzure.Configuration to be used in NLog layouts.

## Usage ##
Install the [NLog.WindowsAzure.Configuration](https://www.nuget.org/packages/NLog.WindowsAzure.Configurationb/) package from NuGet. If you use NLog 4.x or higher, NLog will automatically load the extension assembly. Otherwise, put the following in your NLog configuration:

    <nlog>
        <extensions>
            <add assembly="NLog.WindowsAzure.Configuration" />
        </extensions>
    </nlog>

### Sample ###
    <target xsi:type="Trace" name="TraceOut" layout="${cloudconfig:Name=SampleConfigOption} ${message}" />
