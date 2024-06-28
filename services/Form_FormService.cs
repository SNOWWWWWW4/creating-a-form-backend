using creating_a_form_backend.Models;
using creating_a_form_backend.Services.Context;

namespace creating_a_form_backend.Services;

public class Form_FormService
{
    private readonly DataContext _context;

    public Form_FormService(DataContext context)
    {
        _context = context;
    }

    public bool AddFormData(Form_FormModels formData)
    {
        _context.Add(formData);
        return _context.SaveChanges() != 0;
    }

    public IEnumerable<Form_FormModels> GetForms()
    {
        return _context.Form_FormInfo;
    }
}
