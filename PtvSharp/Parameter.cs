namespace PtvSharp;

internal class Parameter
{
	public readonly string Name;
	public readonly object Value;

	private Parameter(string name, object value)
	{
		Name = name;
		Value = value;
	}

	public static Parameter Create(string name, object value)
	{
		return new Parameter(name, value);
	}
}