using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class ControllerProxyController : Controller
{
    private static Controller _ctrlInstance;

    public static Controller GetProxy()
    {
        if (_ctrlInstance == null)
        {
            _ctrlInstance = new ControllerProxyController();
        }
        return _ctrlInstance;
    }
   
}