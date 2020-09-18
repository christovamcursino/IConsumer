using IConsumer.App.Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.App.Application.Interfaces
{
    public interface IAppService
    {
        bool SignIn(string username, string password);
        bool SignUp(UserPasswordDto userPassword);
    }
}
