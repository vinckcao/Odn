using NLog;
using Odn.Logging;
using Odn.Modules;
using Odn.Reflection;

namespace Odn.Dependency.Installers
{
    internal class OdnCoreInstaller : IOdnInstaller
    {
        public void Install(IIocContainer container)
        {
            container.RegisterWithInstance<ILogger>(LogManager.GetLogger(OdnLoggerNames.FrameworkLoggerName), DependencyLifeStyle.Singleton);
            container.Register<ITypeFinder, TypeFinder, TypeFinder>(DependencyLifeStyle.Singleton);
            container.Register<IOdnModuleManager, OdnModuleManager, OdnModuleManager>(DependencyLifeStyle.Singleton);
            container.Register<IModuleFinder, DefaultModuleFinder, DefaultModuleFinder>(DependencyLifeStyle.Singleton);
        }
    }

    public interface IOdnInstaller
    {
        void Install(IIocContainer container);
    }
}
