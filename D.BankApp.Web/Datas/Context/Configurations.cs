namespace D.BankApp.Web.Datas.Context;

public static class Configurations
{

    public static string ConnectionString
    {
        get
        {
             ConfigurationManager _manager = new ConfigurationManager();
             _manager.AddJsonFile("appsettings.json");
             return _manager.GetConnectionString("PostgreSQL");
        }
    }
    
    
    
    
}