using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;

        public ProductsController(IProductViewModelService productViewModelService)
        {
            _productViewModelService = productViewModelService;
        }

        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View(_productViewModelService.GetFormData());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);
                    return RedirectToAction(nameof(Index));
                }

                return View(_productViewModelService.LoadOptions(viewModel));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível salvar o produto. Verifique os dados informados e tente novamente.");
                return View(_productViewModelService.LoadOptions(viewModel));
            }
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _productViewModelService.GetFormData(id);
            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.Id = id;
                    _productViewModelService.Update(viewModel);
                    return RedirectToAction(nameof(Index));
                }

                return View(_productViewModelService.LoadOptions(viewModel));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível atualizar o produto. Verifique os dados informados e tente novamente.");
                return View(_productViewModelService.LoadOptions(viewModel));
            }
        }

        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            if (viewModel == null)
                return NotFound();

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
                    _productViewModelService.Delete(id);
                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível excluir o produto. Tente novamente.");
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
