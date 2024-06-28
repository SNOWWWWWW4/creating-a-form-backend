using creating_a_form_backend.Models;
using creating_a_form_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace creating_a_form_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class Form_FormController : ControllerBase
{
    private readonly Form_FormService _formService;

    public Form_FormController(Form_FormService formService)
    {
        _formService = formService;
    }

    [HttpGet]
    [Route("GetForms")]
    public IEnumerable<Form_FormModels> GetForms()
    {
        return _formService.GetForms();
    }

    [HttpPost]
    [Route("AddFormData")]
    public bool AddFormData(Form_FormModels newData)
    {
        return _formService.AddFormData(newData);
    }
}