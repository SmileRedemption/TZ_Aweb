using Core.AssetManagement;
using Core.Menu;
using Logic.Movement;

namespace Core.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;

        public UIFactory(IAssetProvider assetProvider) => 
            _assets = assetProvider;

        public MenuUI CreateMenuUI() => 
            _assets.Instantiate<MenuUI>(AssetPath.UIPath);
    }
}