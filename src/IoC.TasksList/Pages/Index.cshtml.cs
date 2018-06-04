﻿using IoC.TasksList.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace IoC.TasksList.Pages
{
    public class IndexModel : PageModel
    {
        private ITaskService _taskService;

        public IndexModel(IConfiguration configuration, ITaskService taskService)
        {

            _taskService = taskService;
        }

        public void OnGet()
        {
            int i = 1;
            ViewData.Add("iValue", _taskService.Plus(i, 10));

            ViewData.Add("items", _taskService.GetAll());
        }
    }
}
