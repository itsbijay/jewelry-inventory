namespace Connections
{
	public interface INavigable
	{
		bool HasNext { get; }
		bool HasPrev { get; }
		FormMode MdiMode { get; set; }
	}
}
