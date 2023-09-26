using System;
using Services;

namespace Core.Menu
{
    public interface IMenuUI : IService
    {
        void OnGameButtonClick(Action onButtonClick);
    }
}