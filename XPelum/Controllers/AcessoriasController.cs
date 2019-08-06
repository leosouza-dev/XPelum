using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using XPelum.Data;
using XPelum.Models;
using XPelum.Repository;
using XPelum.ViewModel;

namespace XPelum.Controllers
{
    public class AcessoriasController : Controller
    {
        private readonly AcessoriaRepository _repository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AcessoriasController(AcessoriaRepository repository,
                                    IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Acessorias
        public IActionResult Index()
        {
            return View(_repository.ListarTodas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAcessoriaViewModel acessoriaVM)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if(acessoriaVM.Imagem != null)
                {
                    string pasta = Path.Combine(_hostingEnvironment.WebRootPath, "img"); //determina o diretório para salvar as imagens
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + acessoriaVM.Imagem.FileName; //criando um unico nome de imagem com GUID
                    string diretorioDaImagem = Path.Combine(pasta, uniqueFileName); //combinando diretório da pasta com nome da imagem
                    acessoriaVM.Imagem.CopyTo(new FileStream(diretorioDaImagem, FileMode.Create));
                }

                var acessoria = new Acessoria(acessoriaVM, uniqueFileName);

                _repository.Salvar(acessoria);
                return RedirectToAction(nameof(Index));
            }
            return View(acessoriaVM);
        }

    }
}
