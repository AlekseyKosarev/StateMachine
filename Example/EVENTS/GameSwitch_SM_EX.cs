using System;

namespace StateMachine.Example.EVENTS
{
    public static class GameSwitch_SM_EX
    {
        //Singleton

        private static bool _inGame;

        private static bool _isLoaded;
        public static event Action OnPause;
        public static event Action OnGame;
        public static event Action OnLoad;
        public static event Action OnExit;

        public static void SwitchToPause()
        {
            if (_isLoaded == false) return;
            OnPause?.Invoke();
            _inGame = !_inGame;
        }

        public static void SwitchToGame()
        {
            if (_isLoaded == false) return;
            OnGame?.Invoke();
            _inGame = !_inGame;
        }

        public static void SwitchActiveGameTo() //пауза влияет именно на игровые объекты, которые уже существуют
        {
            if (_isLoaded == false) return;

            var newState = !_inGame;
            // _inGame = newState;
            if (newState)
                SwitchToPause();
            else
                SwitchToGame();
        }

        //в инициализации игровые объекты создаются, если _ISINIT то игра запущена грубо говоря
        public static void Load() //инициализация, загрузка, создание объектов. 
        {
            if (!_isLoaded)
            {
                OnLoad?.Invoke();
                _isLoaded = true; // по хорошему нужны каллбэки. и вообще все по другому, какой то инишиалайзер
                SwitchToPause();
            }
        }

        public static void Exit()
        {
            if (_isLoaded)
            {
                SwitchToPause();
                OnExit?.Invoke();
                _isLoaded = false;
            }
        }

        public static void Reload()
        {
            Exit();
            Load();
        }
    }
}