using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using G1ANT.Robot.Api.Orchestrator.Models;
using G1ANT.Robot.Api.Orchestrator.Connector;

namespace G1ANT.Robot.Api.Orchestrator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(DefaultModel model)
        {
            return View();
        }

        public IActionResult SubscribeAll(DefaultModel model)
        {
            foreach (var robot in Data.Data.Robots)
                if (robot.Active)
                    try
                    {
                        if (Request.IsHttps)
                            robot.Subscribe("https://" + Request.Host.Value);
                        else
                            robot.Subscribe("http://" + Request.Host.Value);
                    }
                    catch (Exception ex)
                    {
                        return View("Index", new DefaultModel() 
                        { 
                            Information = $"Unable to subscribe events from the robot {robot.SerialNumber}. {ex.Message}", 
                            InformationClass = "red-text" 
                        });
                    }
                return View("Index", new DefaultModel() { Information = "All robots subscribed to get data", InformationClass = "green-text" });
        }

        public IActionResult BreakProcess(DefaultModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.SerialNumber))
            {
                return View("Index", new DefaultModel() { Information = "Process has been broken", InformationClass = "green-text"});
            }
            else
                return View("Index");
        }

        public IActionResult Log(DefaultModel model)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddonList(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch(Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult AddonPut(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult ProcessesList(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult ProcessesGet(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult ProcessesBreak(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult ProcessesRun(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult ProcessesPut(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult TriggersSettingsSet(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult TriggersSettingsGet(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult TriggersEnable(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult TriggersDisable(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult SubscriptionsList(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult SubscriptionsStart(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }

        public IActionResult SubscriptionsStop(RobotQueryModel model)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(model.Query))
                    model.Result = new ApiClient(model.SerialNumber, model.Robot?.Token).Execute(model.Query, model.Method, model.Body, model.Parameters);
            }
            catch (Exception ex)
            {
                model.Result = $"ERROR: {ex.Message}";
            }
            return View(model);
        }
    }
}