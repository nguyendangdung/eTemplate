using Autofac;
using eTemplate.Bizs.Bizs;
using eTemplate.Bizs.Services;

namespace eTemplate.Bizs
{
	public static class AutofacConfig
	{
		public static IContainer Container;
		public static ContainerBuilder Builder = new ContainerBuilder();
		public static void RegisterAutofac()
		{
			Builder.RegisterType<ScreenBiz>().AsSelf();
			Builder.RegisterType<WorkFlowBiz>().AsSelf();
			Builder.RegisterType<HardCodeSystemConfigSerivce>().As<ISystemConfigSerivce>();
			Container = Builder.Build();
		}
	}
}