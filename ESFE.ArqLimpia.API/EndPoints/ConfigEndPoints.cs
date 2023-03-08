namespace ESFE.ArqLimpia.API.EndPoints
{
    public static class ConfigEndPoints
    {
        public static void AddEndPoints(this WebApplication app)
        {
            app.AddUserEndPoints();
           // app.AddUsuarioEndPoints();
        }
    }
}
