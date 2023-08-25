using EcommerceAPI.Common.Classes.Contracts.Clientes;

namespace EcommerceAPI.Common.Classes.Contracts.Authenticate
{
    public class LoginResponseContract
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;

        public LoginResponseContract(ClientesContract cliente, string token)
        {
            this.IdCliente = cliente.id_cliente;
            this.Nombre = cliente.nombre;
            this.Email = cliente.correo;
            this.Token = token;
        }
    }
}
