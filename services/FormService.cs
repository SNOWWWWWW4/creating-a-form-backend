using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creating_a_form_backend.Models;

namespace creating_a_form_backend.Services;

public class FormService
{
    public List<FormModel> formList = new();
    // public FormService()
    // {
    //     formList.Add({"bruh", "bruhr"});
    // }

    public List<FormModel> GetFormData()
    {
        return formList;
    }
}
