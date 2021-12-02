using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdPOS
{
    public class MdPOS
    {

        public static string Render(string md, IDictionary<string, Func<string, string>> renders = null)
        {
            MdPOS pos = new MdPOS(renders);
            return pos.Render(md);
        }


        StringBuilder sb = new StringBuilder();
        IDictionary<string, Func<string, string>> renders;

        MdPOS(IDictionary<string, Func<string, string>> renders = null)
        {
            this.renders = renders ?? new Renders();
        }

        string TransformarLetras(string s)
        {
            string result = "";
            foreach (var c in s)
            {
                result += renders.ContainsKey("" + c) ? renders["" + c](null) : c.ToString();
            }
            return result;
        }

        string TransformarTexto(string s)
        {
            string[] sep = { "**" };
            var partes = s.Split(sep, StringSplitOptions.None);
            var textoConNegritas = "";
            var negrita = false;
            foreach (var parte in partes)
            {
                textoConNegritas += negrita ? renders["**"](TransformarLetras(parte)) : TransformarLetras(parte);
                negrita = !negrita;
            }
            return textoConNegritas;

        }

        string TransformarLinea(string s)
        {
            Func<string, string> render = (string x) => string.Format(renders["@reset-line"](null) + "{0}", x);
            var texto = s;
            foreach (var item in renders)
            {
                if (s.StartsWith(item.Key))
                {
                    render = item.Value;
                    texto = s.Substring(item.Key.Length);
                    break;
                }
            }
            return render(TransformarTexto(texto));
        }

        string Render(string s)
        {
            var lines = s.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = TransformarLinea(lines[i]);
            }
            return string.Join(renders.ContainsKey("\n") ? renders["\n"](null) : "\n", lines);
        }
    }
}
