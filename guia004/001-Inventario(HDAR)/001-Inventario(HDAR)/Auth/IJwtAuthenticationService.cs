namespace _001_Inventario_HDAR_.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
