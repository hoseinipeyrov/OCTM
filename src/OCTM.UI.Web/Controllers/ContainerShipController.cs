using System;
using OCTM.Application.Interfaces;
using OCTM.Application.ViewModels;
using OCTM.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OCTM.UI.Web.Controllers
{
    //[Authorize]
    public class ContainerShipController : BaseController
    {
        private readonly IContainerShipAppService _containerShipAppService;

        public ContainerShipController(IContainerShipAppService containerShipAppService, 
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _containerShipAppService = containerShipAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("containerShip-management/list-all")]
        public IActionResult Index()
        {
            return View(_containerShipAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("containerShip-management/containerShip-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerShipViewModel = _containerShipAppService.GetById(id.Value);

            if (containerShipViewModel == null)
            {
                return NotFound();
            }

            return View(containerShipViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteContainerShipData")]
        [Route("containerShip-management/create-new")]
        public string Create()
        {
            ContainerShipViewModel containerShipViewModel = new ContainerShipViewModel
            {
                Name = "adryan darya",
                Capacity = 20,
                Color = "red"
            };
            _containerShipAppService.Create(containerShipViewModel);
          return  IsValidOperation() ? "true" : "false";
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteContainerShipData")]
        [Route("containerShip-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContainerShipViewModel containerShipViewModel)
        {
            if (!ModelState.IsValid) return View(containerShipViewModel);
            _containerShipAppService.Create(containerShipViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "ContainerShip Registered!";

            return View(containerShipViewModel);
        }
        
        [HttpGet]
        [Authorize(Policy = "CanWriteContainerShipData")]
        [Route("containerShip-management/edit-containerShip/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerShipViewModel = _containerShipAppService.GetById(id.Value);

            if (containerShipViewModel == null)
            {
                return NotFound();
            }

            return View(containerShipViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteContainerShipData")]
        [Route("containerShip-management/edit-containerShip/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContainerShipViewModel containerShipViewModel)
        {
            if (!ModelState.IsValid) return View(containerShipViewModel);

            _containerShipAppService.Update(containerShipViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "ContainerShip Updated!";

            return View(containerShipViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveContainerShipData")]
        [Route("containerShip-management/remove-containerShip/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerShipViewModel = _containerShipAppService.GetById(id.Value);

            if (containerShipViewModel == null)
            {
                return NotFound();
            }

            return View(containerShipViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveContainerShipData")]
        [Route("containerShip-management/remove-containerShip/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _containerShipAppService.Remove(id);

            if (!IsValidOperation()) return View(_containerShipAppService.GetById(id));

            ViewBag.Sucesso = "ContainerShip Removed!";
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [Route("containerShip-management/containerShip-history/{id:guid}")]
        public JsonResult History(Guid id)
        {
            var containerShipHistoryData = _containerShipAppService.GetAllHistory(id);
            return Json(containerShipHistoryData);
        }
    }
}
