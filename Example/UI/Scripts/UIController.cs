using StateMachineTools.Example.EVENTS;
using StateMachineTools.Example.LevelBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace StateMachineTools.Example.UI.Scripts
{
    public class UIController : MonoBehaviour
    {
        public LevelBuilder levelBuilder;
        private Button _reloadBtn;
        private Button _switchActiveBtn;
        private TextField _textBox;

        private void Start()
        {
            if (levelBuilder == null) Debug.LogError("LevelBuilder == null");

            var root = GetComponent<UIDocument>().rootVisualElement;

            _switchActiveBtn = root.Q<Button>("SwitchButton");
            _reloadBtn = root.Q<Button>("ReloadButton");
            _textBox = root.Q<TextField>("CountSpawn");

            _switchActiveBtn.RegisterCallback<ClickEvent>(ClickSwitch);
            _reloadBtn.RegisterCallback<ClickEvent>(ClickReload);
        }

        private void ClickSwitch(ClickEvent evt)
        {
            GameSwitch.SwitchActiveGameTo();
        }

        private void ClickReload(ClickEvent evt)
        {
            //convert _textBox.value to int
            if (_textBox.value == "") return;
            levelBuilder.countCopys = int.Parse(_textBox.value);
            GameSwitch.Reload();
        }
    }
}