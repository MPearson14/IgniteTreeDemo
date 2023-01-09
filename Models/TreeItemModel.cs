namespace IgniteTreeDemo.Models
{
	public class TreeItemModel
	{
		public TreeItemModel(string identifier, IList<TreeItemModel>? childItems = null)
		{
			Identifier = identifier;
			ChildItems = childItems;
		}

		public TreeItemModel(string identifier, string text, string value, IList<TreeItemModel>? childItems = null)
		{
			Identifier = identifier;
			Text = text;
			Value = value;
			ChildItems = childItems;
		}

		public string Identifier { get; set; }
		public string Text { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;
		public IList<TreeItemModel>? ChildItems { get; set; }
	}
}
