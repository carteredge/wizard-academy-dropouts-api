using Microsoft.AspNetCore.Mvc;

namespace WizardAcademyDropouts.Services;

public class AuthService
{
    public Task<HttpResponse> Login([FromQuery] UserCredentialDTO credentials)
    {
        
    }

    public Task<HttpResponse> Logout()
    {

    }

    public Task<HttpResponse> Register()
    {
    }

    public Task<HttpResponse> ChangePassword() // & forgot password
    {

    }
}