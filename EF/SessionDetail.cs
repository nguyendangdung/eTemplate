namespace EF
{
	public class SessionDetail
	{
		public int SessionDetailId { get; set; }
		public int SessionId { get; set; }
		public virtual Session Session { get; set; }
		public virtual Instruction Instruction { get; set; }
		public int InstructionId { get; set; }
		public string Data { get; set; }
	}
}