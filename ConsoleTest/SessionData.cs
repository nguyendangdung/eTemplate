namespace ConsoleTest
{
	public class SessionData
	{
		public int SessionDataId { get; set; }
		public int SessionId { get; set; }
		public virtual Session Session { get; set; }

		public int ScreenId { get; set; }
		public virtual Screen Screen { get; set; }

		public int Order { get; set; }
		public string Data { get; set; }
	}
}