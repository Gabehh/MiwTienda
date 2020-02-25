using DataLayer.Model;
using DataLayer.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;


namespace BusinessLayer
{
    public class AccountBL
    {
        public IdentityResult CreateAccount(Cliente persona)
        {
            IdentityResult result;
            try
            {
                ClienteRepository clienteRepository = new ClienteRepository();
                if (!clienteRepository.CheckEmail(persona.Email))
                {
                    clienteRepository.Create(persona);
                    result = persona.Id != 0 ? IdentityResult.Success : new IdentityResult("No se ha creado el usuario");
                }
                else
                {
                    result = new IdentityResult("El email ya existe en otra cuenta de usuario");
                }
            }
            catch(Exception ex)
            {
                result = new IdentityResult(ex.Message);

            }
            return result;
        }
        
        public Cliente GetCliente (string email, string password)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            return clienteRepository.Single(u => u.Email == email && u.Password == password);
        }
    }
}
