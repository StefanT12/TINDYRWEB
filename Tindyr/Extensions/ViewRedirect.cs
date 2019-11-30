using Microsoft.AspNetCore.Mvc;
public static class ViewRedirect
{
    private static Controller _proxy => ControllerProxyController.GetProxy();
    public static RedirectToActionResult BackHome => _proxy.RedirectToAction("Index", "Home");
    
}