using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lton
{
    public class LtonSerializer
    {
        public string Serialize(object obj)
        {
            var formatter = new Formatter();
            var builder = new StringBuilder();
            foreach (var property in obj.GetType().GetProperties())
            {
                builder.Append(formatter.FormatProperty(property, obj));
            }
            return builder.ToString();
        }
    }
}
