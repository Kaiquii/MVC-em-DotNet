using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientViewModelService _clientViewModelService;
        public ClientsController(IClientViewModelService clientViewModelService)
        {
            _clientViewModelService = clientViewModelService;
        }

        public ActionResult Index()
        {
            var list = _clientViewModelService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var viewModel = _clientViewModelService.Get(id);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível salvar o cliente. Verifique os dados informados e tente novamente.");
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _clientViewModelService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.Id = id;
                    _clientViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível atualizar o cliente. Verifique os dados informados e tente novamente.");
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var viewModel = _clientViewModelService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _clientViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível excluir o cliente. Tente novamente.");
                var viewModel = _clientViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
