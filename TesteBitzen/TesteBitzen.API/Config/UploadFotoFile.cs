using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBitzen.API.Config
{
    public static class UploadFotoFile
    {
        public static string Foto { get; set; }
        public static string Erro { get; set; }

        private static bool CheckFoto(IFormFile arquivo)
        {
            string[] extensoes = new string[3]{ ".png", ".jpg", ".jpeg" };

            var extensao = string.Concat(".", arquivo.FileName.Split(".")[arquivo.FileName.Split(".").Length - 1]);
            return extensoes.Contains(extensao);
        }

        public static void SalvarFoto(IFormFile arquivo)
        {
            if (CheckFoto(arquivo))
            {
                string nomeArquivo;
                try
                {
                    var extensao = string.Concat(".", arquivo.FileName.Split(".")[arquivo.FileName.Split(".").Length - 1]);
                    nomeArquivo = string.Concat(DateTime.Now.Ticks, extensao);

                    var diretorio = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\fotos");

                    if (!Directory.Exists(diretorio))
                    {
                        Directory.CreateDirectory(diretorio);
                    }

                    var caminho = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\fotos", nomeArquivo);

                    using (var stream = new FileStream(caminho, FileMode.Create))
                    {
                        arquivo.CopyTo(stream);
                    }

                    Foto = nomeArquivo;
                }
                catch (Exception ex)
                {
                    Erro = ex.Message;
                }
            } 
            else
            {
                Erro = "Arquivo com exetensão incorreta";
            }
        }
    }
}
