using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdPOS
{

    public class HtmlRenders : Dictionary<string, Func<string, string>>
    {
        public HtmlRenders()
        {

            this["@default-charset"] = s => "";
            this["@latin"] = s => "";

            this["@start"] = s => "<!DOCTYPE html><html lang=\"es\">\n" +
                                    "<head><title>TICKET</title>\n" +
                                    "<meta charset=\"utf-8\"/>\n" +
                                    "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" +
                                    "<style>\n" +
                                      "body { font-family: 'Roboto Mono', monospace; font-size: 3mm; line-height: 0.6; background-color:grey; }\n" +
                                    ".ticket { background-color:white; width: fit-content; padding: 0.25cm; margin-left:auto; margin-right:auto; border-top: 1px dashed grey; border-bottom: 1px dashed grey;}\n" +
                                    ".Center { text-align: center }\n" +
                                    ".Left { text-align: left }\n" +
                                    ".Right { text-align: right }\n" +
                                    ".Big    { font-size: 150% }\n" +
                                    ".Normal { font-size: 100% }\n" +
                                    ".Tiny { font-size: 75% }\n" +
                                    ".Huge { font-size: 200% }\n" +
                                    "@media only screen and (min-width: 768px) {\n" +
                                    ".ticket {\n" +
                                            "zoom:1.5\n" +
                                            "}\n" +
                                    "}\n" +
                                    "</style>\n" +
                                    "</head>\n" +
                                    "<body>\n" +
                                    "<div class=\"ticket\">\n" +
                                    "<pre>\n";


            this["@reset-line"] = s => "";


            this["#1 "] = s => string.Format("<div class=\"Tiny Left\">{0}</div>", s);
            this["#2 "] = s => string.Format("<div class=\"Normal Left\">{0}</div>", s);  //normal
            this["#3 "] = s => string.Format("<div class=\"Big Left\">{0}</div>", s);  //grande
            this["#4 "] = s => string.Format("<div class=\"Huge Left\">{0}</div>", s);  //muy grande";

            this["#1c "] = s => string.Format("<div class=\"Tiny Center\">{0}</div>", s);
            this["#2c "] = s => string.Format("<div class=\"Normal Center\">{0}</div>", s);  //normal
            this["#3c "] = s => string.Format("<div class=\"Big Center\">{0}</div>", s);  //grande
            this["#4c "] = s => string.Format("<div class=\"Huge Center\">{0}</div>", s);  //muy grande";

            this["#1r "] = s => string.Format("<div class=\"Tiny Right\">{0}</div>", s);
            this["#2r "] = s => string.Format("<div class=\"Normal Right\">{0}</div>", s);  //normal
            this["#3r "] = s => string.Format("<div class=\"Big Right\">{0}</div>", s);  //grande
            this["#4r "] = s => string.Format("<div class=\"Huge Right\">{0}</div>", s);  //muy grande";

            this["---"] = s => "<hr/>";
            this["@ruler2"] = s => "";

            this["+++"] = s => "</pre></div></body></html>";

            this["**"] = s => string.Format("<strong>{0}</strong>", s);

            this["@code39 "] = s => "";

        }
    }

}
