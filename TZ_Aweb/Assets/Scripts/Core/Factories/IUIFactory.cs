using Core.Menu;
using Services;

namespace Core.Factories
{
    public interface IUIFactory : IService
    {
        MenuUI CreateMenuUI();
    }
}