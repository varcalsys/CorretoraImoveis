using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Util.Common
{
    public class Helper
    {
        public static List<Foto> LoadFiles(HttpPostedFileBase[] files, string url)
        {

            var fotos = new List<Foto>();

            foreach (HttpPostedFileBase file in files)
            {
                var foto = new Foto();
                byte[] arraybytes = null;
                foto.Nome = DateTime.Now.ToString("yyyy-MM-dd") + DateTime.Now.Millisecond + ".jpg";
                long numeroBytes = file.InputStream.Length;
                BinaryReader br = new BinaryReader(file.InputStream);
                arraybytes = br.ReadBytes((int)numeroBytes);
                var ms = new MemoryStream(arraybytes);
                Image image = Image.FromStream(ms);

                var bmp = new Bitmap(image, new Size(800, 480));
                foto.UrlFoto = Path.Combine(url + "images/imoveis/", Path.GetFileName(foto.Nome));
                bmp.Save(foto.UrlFoto, ImageFormat.Jpeg);

                var thumb = new Bitmap(image, new Size(400, 240));
                foto.UrlThumb = Path.Combine(url + "images/imoveis/thumb", Path.GetFileName(foto.Nome));
                thumb.Save(foto.UrlThumb, ImageFormat.Jpeg);

                fotos.Add(foto);
            }

            return fotos;
        }

        public static void DeleteFiles(IList<Foto> fotos)
        {
            if (fotos.Any())
                foreach (var foto in fotos)
                {
                    File.Delete(foto.UrlFoto);
                    File.Delete(foto.UrlThumb);
                }           
        }
    }
}
