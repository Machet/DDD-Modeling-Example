using System;

namespace DDDCinema.Promotions
{
	public class Editor
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		protected Editor() { }

		public Editor(Guid id, string name)
		{
			Id = id;
			Name = name;
		}

		public override bool Equals(object obj)
		{
			var second = obj as Editor;
			return second != null && second.Id == Id;
		}
	}
}