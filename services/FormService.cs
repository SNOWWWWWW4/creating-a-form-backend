using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creating_a_form_backend.Models;

namespace creating_a_form_backend.Services;

public class FormService
{
    public List<FormModel> formList = new();

    public IEnumerable<FormModel> GetFormData()
    {
        return formList;
    }

    public IEnumerable<FormModel> AddFormData(FormModel newUser)
    {
        formList.Add(newUser);
        return formList;
    }
}
