using System.Collections.Generic;
using eTemplate.SharedComponents.EntityInfos;

namespace eTemplate.Bizs.Services
{
	public interface IActionMethodService
	{
		IEnumerable<ActionMethodInfo> GetActionMethodInfos();
	}
}
