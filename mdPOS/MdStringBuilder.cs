using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdPOS
{
    public class MdStringBuilder
    {

        StringBuilder sb = new StringBuilder();

        public void Write(string format, params object[] data)
        {
            sb.AppendFormat(format, data);
        }

        public void WriteLine(string format, params object[] data)
        {
            Write(format + "\n", data);
        }


        public override string ToString()
        {
            return sb.ToString();
        }

    }
}
