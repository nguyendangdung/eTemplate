using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsoleTest;
using eTemplate.Models.Sessions;

namespace eTemplate.Controllers
{
    public class SessionsController : Controller
    {
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="id">ScreenId</param>
	    /// <param name="screenId"></param>
	    /// <returns></returns>
	    public ActionResult Details(int id, int? screenId)
	    {
		    using (var context = new Context())
		    {
			    // Search unfinish Session by Id
			    var session = context.Sessions
					.Include(s => s.SessionDatas.Select(t => t.Screen))
				    .FirstOrDefault(s => s.SessionId == id && !s.Finished);
				
				if (session == null || !session.SessionDatas.Any())
				{
				    return RedirectToAction("Index", "Home");
				}

			    var sessionDatas = session.SessionDatas.OrderBy(s => s.Order).ToList();
			    SessionData theCurrentSessionData;
			    SessionData theNextSessionData = null;
			    SessionData thePreviousSessionData = null;
				if (screenId == null)
				{
					// The first SessionData
					theCurrentSessionData = sessionDatas[0];
					theNextSessionData = TryGetElement(sessionDatas, 1);
				}
				else
				{
					theCurrentSessionData = sessionDatas.FirstOrDefault(s => s.ScreenId == screenId);
					if (theCurrentSessionData == null)
					{
						// The first SessionData
						theCurrentSessionData = sessionDatas[0];
						theNextSessionData = TryGetElement(sessionDatas, 1);
					}
					else
					{
						var currentIndex = sessionDatas.IndexOf(theCurrentSessionData);
						theNextSessionData = TryGetElement(sessionDatas, currentIndex + 1);
						thePreviousSessionData = TryGetElement(sessionDatas, currentIndex - 1);
					}
				}

			    var vm = new SessionDetails()
			    {
				    CurrentSessionData = new SessionDataListItem()
				    {
					    Screen = new ScreenListItem()
					    {
						    Name = theCurrentSessionData.Screen.Name,
						    Description = theCurrentSessionData.Screen.Description,
							ScreenId = theCurrentSessionData.Screen.ScreenId,
							ActionMethod = theCurrentSessionData.Screen.ActionMethod
						}
				    },
					NextSessionData = theNextSessionData == null ? null : new SessionDataListItem()
					{
						Screen = new ScreenListItem()
						{
							Name = theNextSessionData.Screen.Name,
							Description = theNextSessionData.Screen.Description,
							ScreenId = theNextSessionData.Screen.ScreenId,
							ActionMethod = theNextSessionData.Screen.ActionMethod
						}
					},
				    PreviousSessionData = thePreviousSessionData == null ? null : new SessionDataListItem()
				    {
					    Screen = new ScreenListItem()
					    {
						    Name = thePreviousSessionData.Screen.Name,
						    Description = thePreviousSessionData.Screen.Description,
						    ScreenId = thePreviousSessionData.Screen.ScreenId,
						    ActionMethod = thePreviousSessionData.Screen.ActionMethod
					    }
				    },
					SessionId = session.SessionId
				};
			    return View(vm);
		    }
	    }

	    public ActionResult PreviewAndPrint(int id)
	    {
		    return View();
	    }

	    public static T TryGetElement<T>(List<T> array, int index)
	    {
		    if (index < 0 || index >= array.Count)
		    {
			    return default(T);
			}
			return array[index];
		}
	}
}