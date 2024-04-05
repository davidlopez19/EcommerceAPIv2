namespace EcommerceAPI.Dominio.Services.Encripcion
{
    public interface ICryptoService
    {
        string Encript(string value);
        string DesEncript(string value);
    }
}
