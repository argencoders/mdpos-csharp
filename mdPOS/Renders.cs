using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdPOS
{
    public class Renders : Dictionary<string, Func<string, string>>
    {
        const char ESC = '\x1b';
        const char FS = '\x1c';
        const char GS = '\x1d';

        public Renders()
        {
            this["@default-charset"] = s => ESC + "R\x00";
            this["@latin"] = s => ESC + "R\x0C";

            this["@start"] = s => ESC + "@";

            this["@small"] = s => ESC + "!" + '\x01';
            this["@normal"] = s => ESC + "!" + '\x00';
            this["@big"] = s => ESC + "!" + '\x31';
            this["@huge"] = s => ESC + "!" + '\x30';

            this["@left"] = s => ESC + "a" + '\x00';
            this["@center"] = s => ESC + "a" + '\x01';
            this["@right"] = s => ESC + "a" + '\x02';

            this["@reset-line"] = s => this["@left"](null) + this["@normal"](null) + ESC + "E" + (char)1;


            this["#1 "] = s => string.Format(this["@small"](null) + this["@left"](null) + "{0}", s);
            this["#2 "] = s => string.Format(this["@normal"](null) + this["@left"](null) + "{0}", s);
            this["#3 "] = s => string.Format(this["@big"](null) + this["@left"](null) + "{0}", s);
            this["#4 "] = s => string.Format(this["@huge"](null) + this["@left"](null) + "{0}", s);

            this["#1c "] = s => string.Format(this["@small"](null) + this["@center"](null) + "{0}", s);
            this["#2c "] = s => string.Format(this["@normal"](null) + this["@center"](null) + "{0}", s);
            this["#3c "] = s => string.Format(this["@big"](null) + this["@center"](null) + "{0}", s);
            this["#4c "] = s => string.Format(this["@huge"](null) + this["@center"](null) + "{0}", s);

            this["#1r "] = s => string.Format(this["@small"](null) + this["@right"](null) + "{0}", s);
            this["#2r "] = s => string.Format(this["@normal"](null) + this["@right"](null) + "{0}", s);
            this["#3r "] = s => string.Format(this["@big"](null) + this["@right"](null) + "{0}", s);
            this["#4r "] = s => string.Format(this["@huge"](null) + this["@right"](null) + "{0}", s);

            this["---"] = s => this["@reset-line"](null) + "------------------------------------------------";
            this["@ruler2"] = s => string.Format(this["@normal"](null) + this["@left"](null) + "123456789012345678901234567890123456789012345678", s);

            this["+++"] = s => GS + "V\x41\0";

            this["á"] = s => this["@latin"](null) + "\x40" + this["@default-charset"](null);
            this["é"] = s => this["@latin"](null) + "\x5e" + this["@default-charset"](null);
            this["í"] = s => this["@latin"](null) + "\x7b" + this["@default-charset"](null);
            this["ó"] = s => this["@latin"](null) + "\x7d" + this["@default-charset"](null);
            this["ú"] = s => this["@latin"](null) + "\x7e" + this["@default-charset"](null);
            this["ñ"] = s => this["@latin"](null) + "\x7c" + this["@default-charset"](null);
            this["Ñ"] = s => this["@latin"](null) + "\x5c" + this["@default-charset"](null);

            this["**"] = s => string.Format(ESC + "E" + (char)1 + "{0}" + ESC + "E" + (char)0, s);

            this["@code39 "] = s => string.Format("\x1d\x6b\x04{0}\x00", s);

        }
    }
}
