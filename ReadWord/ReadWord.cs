using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReadWord
{
    public class ReadWordLib
    {
        public static string readWordTable(string fileName, int rowIndex, int colIndex)
        {

            ApplicationClass cls = null;
            Document doc = null;

            Table table = null;
            object missing = Missing.Value;

            object path = fileName;
            cls = new ApplicationClass();

            try
            {
                doc = cls.Documents.Open
                    (ref path, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);
                table = doc.Tables[1];
                string text = table.Cell(rowIndex, colIndex).Range.Text.ToString();
                text = text.Substring(0, text.Length - 2);    //去除尾部的mark 
                return text;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            finally
            {
                if (doc != null)
                    doc.Close(ref missing, ref missing, ref missing);
                cls.Quit(ref missing, ref missing, ref missing);
            }
        }

        public static Dictionary<objXY, string> readWordTable(string fileName, List<objXY> t)
        {

            ApplicationClass cls = null;
            Document doc = null;

            Table table = null;
            object missing = Missing.Value;

            object path = fileName;
            cls = new ApplicationClass();

            Dictionary<objXY, string> tmpdic = new Dictionary<objXY, string>();
            try
            {
                doc = cls.Documents.Open
                    (ref path, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);
                table = doc.Tables[1];

                foreach (var item in t)
                {
                    string text = table.Cell(item.rowIndex, item.colIndex).Range.Text.ToString();
                    text = text.Substring(0, text.Length - 2);    //去除尾部的mark 
                    if (!tmpdic.ContainsKey(item))
                    {
                        tmpdic.Add(item, text);
                    }
                }
                
                return tmpdic;
            }
            catch (Exception ex)
            {
                throw ex;
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (doc != null)
                    doc.Close(ref missing, ref missing, ref missing);
                cls.Quit(ref missing, ref missing, ref missing);
            }
        }
    }
    public class objXY
    {

        public objXY(int r, int c)
        {
            rowIndex = r;
            colIndex = c;
        }

        public objXY()
        {
            // TODO: Complete member initialization
        }
        public int rowIndex { get; set; }
        public int colIndex { get; set; }
    }
}
