using System;

namespace DDDCinema.Promotions
{
	public class Editor
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		public Editor(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}