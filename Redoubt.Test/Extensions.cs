using System.IO;
using System.Reflection;

namespace Redoubt.Test
{
    public static class Extensions
    {
        public static string ExtJumpUp(this Assembly value, int levels)
        {
            var tmp = value.Location;
            for (var i = 0; i < levels; i++)
                tmp = Path.GetDirectoryName(tmp);
            return tmp;
        }
    }
}
