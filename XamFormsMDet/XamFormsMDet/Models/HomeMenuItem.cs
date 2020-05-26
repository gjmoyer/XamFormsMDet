using System;
using System.Collections.Generic;
using System.Text;

namespace XamFormsMDet.Models
{
    public enum MenuItemType
    {
        Browse,
        Scandit,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
