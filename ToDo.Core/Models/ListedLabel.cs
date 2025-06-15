using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models
{
    public class ListedLabel
    {
        public ListedLabel(Label label) : this(label.Id, label.Title, label.Description, label.ColorHex) { }
        public ListedLabel(string id, string title, string? description, string colorHex)
        {
            Id = id;
            Title = title;
            Description = description;
            ColorHex = colorHex;
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ColorHex { get; set; }
    }
}
