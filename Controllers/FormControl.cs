using creating_a_form_backend.Models;
using creating_a_form_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace creating_a_form_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FormController : ControllerBase
{
    private readonly FormService _formService;

    public FormController(FormService formService)
    {
        _formService = formService;
    }

    public List<FormModel> formList = new();

    [HttpGet]
    [Route("GetFormData")]
    public List<FormModel> GetFormData()
    {
        return _formService.GetFormData();
    }
}
