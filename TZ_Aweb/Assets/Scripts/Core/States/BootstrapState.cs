using Core.AssetManagement;
using Core.Factories;
using Core.Loading;
using Core.Menu;
using Logic.Core.Player;
using Services;
using Services.Inputs;


namespace Core.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;
        private readonly LoadingCurtain _curtain;
        private readonly IUIFactory _uiFactory;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ServiceLocator serviceLocator, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _serviceLocator = serviceLocator;
            _curtain = loadingCurtain;
            
            BindServices();
            _uiFactory = _serviceLocator.GetService<IUIFactory>();
        }

        private void BindServices()
        {
            BindSceneLoader();
            BindInputService();
            BindAssetProvider();
            BindPlayerFactory();
            BindPlayerService();
            BindUIFactory();
        }

        public void Enter() => 
            _curtain.Show(() => _sceneLoader.Load(SceneName.MenuScene, EnterMenu));

        public void Exit() => 
            _curtain.Hide();

        private void BindSceneLoader() => 
            _serviceLocator.RegisterService<ISceneLoader>(_sceneLoader);

        private void EnterMenu()
        {
            var menuUI = _uiFactory.CreateMenuUI();
            menuUI.StartFadeIn();
            
            BindMenuUI(menuUI);
            
            _gameStateMachine.Enter<MenuState, string>(SceneName.MenuScene);
        }

        private void BindMenuUI(MenuUI menuUI) => 
            _serviceLocator.RegisterService<IMenuUI>(menuUI);

        private void BindInputService() => 
            _serviceLocator.RegisterService<IInputSource>(
                new MobileInput());

        private void BindAssetProvider() => 
            _serviceLocator.RegisterService<IAssetProvider>(
                new AssetProvider());

        private void BindPlayerFactory() =>
            _serviceLocator.RegisterService<IPlayerFactory>(
                new PlayerFactory(_serviceLocator.GetService<IAssetProvider>()));

        private void BindPlayerService() => 
            _serviceLocator.RegisterService<IPlayerCollider>(
                new PlayerColliderCollider());

        private void BindUIFactory()
        {
            _serviceLocator.RegisterService<IUIFactory>(
                new UIFactory(_serviceLocator.GetService<IAssetProvider>()));
        }
    }
}