using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
	public Utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string ContinuousString(string old_string, int from, int to)
    {
        string new_string;

        if (old_string.Length > 30)
            new_string = old_string.Substring(0, to - from - 3) + "...";
        else
            new_string = old_string;

        return new_string;
    }

    public static List<string> GetCategories()
    {
        WebshopDataContext dc = new WebshopDataContext();
        IEnumerable<Category> ct = (from ev in dc.Categories
                       select ev).DefaultIfEmpty();

        List<string> categories = new List<string>();

        foreach (Category ev in ct)
        {
            categories.Add(ev.CategoryName.Trim());
        }

        return categories;
    }
}
