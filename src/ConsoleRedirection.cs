using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Weavver.Testing
{
	public class WebBrowserStreamWriter : TextWriter
     {
          WebBrowser _output = null;
          public Color OutputColor = Color.Black;
//-------------------------------------------------------------------------------------------
          public WebBrowserStreamWriter(WebBrowser output)
          {
               _output = output;
          }
//-------------------------------------------------------------------------------------------
          public override void WriteLine(string value)
          {
               MethodInvoker action = delegate
               {
                    string output = value.ToString().Replace("\r\n", "<br />");

                    string color = ColorTranslator.ToHtml(OutputColor);

                    _output.Document.Write("<span style='font-size: 10pt; font-family: console;color:" + color + "'>" + output + "</span><br />");
                    _output.Document.InvokeScript("javascript:window.scrollTo(0,document.body.scrollHeight);");

               };
               _output.BeginInvoke(action);

               base.WriteLine(value);
          }
//-------------------------------------------------------------------------------------------
          public override Encoding Encoding
          {
               get { return System.Text.Encoding.UTF8; }
          }
//-------------------------------------------------------------------------------------------
	}
}
