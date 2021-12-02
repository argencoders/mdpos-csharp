using mdPOS;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    class Program {


        static public string mdFactura(object x)
        {
            var md = new MdStringBuilder();


            md.WriteLine("@start");
            md.WriteLine("@ruler2");


            md.WriteLine("#3c MINISERVICE"); // =
            //tamano grande
            md.WriteLine("#4c BAKALICO"); // =

            //tamano normal
            md.WriteLine("");
            md.WriteLine("#2 Razón Social: **SALUSTROS MANUEL**"); // 
            md.WriteLine("");
            //pos.WriteLine("#2 Marcos Paz 302 á é í ó ú ñ Ñ ");
            md.WriteLine("#2 Marcos Paz 302");
            md.WriteLine("#2 San Miguel de Tucumán");
            md.WriteLine("#2 Tel: 381-4841170");
            md.WriteLine("");
            md.WriteLine("#2 CUIT: 20-23588385-7");
            md.WriteLine("#2 IIBB: 20-23588385-7");
            md.WriteLine("#2 Inicio de Actividades: 11/2013");
            md.WriteLine("");
            md.WriteLine("#2 IVA RESPONSABLE INSCRIPTO");
            md.WriteLine("");

            var tabla = "#2 {0,-5}{1,-30}{2,13:C}";
            var pie = "#2 {0,-5}{1,-30}**{2,13:C}**";
            md.WriteLine("---");  // printer.separador()
            md.WriteLine(tabla, "Cod.", "Descripción", "Unitario");
            md.WriteLine("---");  // printer.separador()
            md.WriteLine(tabla, "123", "Coca", 341.5);
            md.WriteLine(tabla, "456", "Pepsi", 208.25);
            md.WriteLine("---");  // printer.separador()
            md.WriteLine(pie, "", "Total", 401);

            md.WriteLine("#1c " + DateTime.Now.ToString());
            md.WriteLine("---\n@code39 {0}\n---", "MATIAS01234");

            md.Write("+++");

            return md.ToString();

        }


        static void ImprimirFactura(object factura, string config) {

            string md;

            switch (config)
            {
                case "html":
                    md = mdFactura(factura);
                    Console.Write(MdPOS.Render(md, new HtmlRenders()));
                    break;
                default:

                    md = mdFactura(factura);

                    string puerto = "COM4";
                    int baudRate = 19200;
                    Parity parity = Parity.None;
                    int dataBits = 8;
                    StopBits stopbits = StopBits.One;

                    SerialPort printer = new SerialPort(puerto, baudRate, parity, dataBits, stopbits);
                    printer.Open();
                    printer.WriteLine(MdPOS.Render(md, new Renders()));
                    printer.Close();
                    break;
            }

            Console.ReadKey();

        }


        static void Main(string[] args)
        {

            ImprimirFactura((object) null, "html");
            Console.ReadKey();


        }
    }
}
