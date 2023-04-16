using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6App1
{
    public record DirectoryItem(DirectoryItem.ItemTypes Type, string Name, DateTime DateLastChange)
    {
        public enum ItemTypes
        {
            Directory,
            File
        }

        public ItemTypes Type { get; set; } = Type;
        public string Name { get; set; } = Name;
        public DateTime DateLastChange { get; set; } = DateLastChange;
    }
}