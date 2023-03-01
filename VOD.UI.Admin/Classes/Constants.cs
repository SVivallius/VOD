using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net.NetworkInformation;

namespace VOD.UI.Admin.Classes;

public static class Routes
{
    static public string Films = "Films";
    static public string Directors = "Directors";
    static public string Genres = "Genres";
}

static class PageType
{
    static string Index = "Index";
    static string Create = "Create";
    static string Edit = "Edit";
    static string Delete = "Delete";
}
