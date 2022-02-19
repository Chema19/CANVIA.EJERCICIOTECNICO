using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Helpers;
using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CANVIA.EJERCICIOTECNICO.RETOCANVIERO.ViewModels.Login
{
    public class LoginViewModel
    {
        public string Login(LoginModel model)
        {
            if (model.user == "admin" && model.password == "admin") 
            { 
                return TokenGenerator.GenerateTokenJwt(model.user);
            }
            return null;
        }
    }
}