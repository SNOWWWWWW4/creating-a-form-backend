using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creating_a_form_backend.Models;

namespace creating_a_form_backend.Services;

public class FormService
{
    private readonly List<FormModel> formList = new List<FormModel>();

    public IEnumerable<FormModel> GetFormData() => formList;

    public void AddFormData(FormModel newUser){
        formList.Add(newUser);
        // return formList;
    }
}
