using StateMachine.Example.EVENTS;
using StateMachine.Example.LevelBuilderSystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace StateMachine.Example.UI.Scripts
{
    public class UIController_SM_EX : MonoBehaviour
    {
        [FormerlySerializedAs("levelBuilder")] public LevelBuilder_SM_EX levelBuilderSmEx;
        private Button _reloadBtn;
        private Button _switchActiveBtn;
        private TextField _textBox;

        private void Start()
        {
            if (levelBuilderSmEx == null) Debug.LogError("LevelBuilder == null");

            var root = GetComponent<UIDocument>().rootVisualElement;

            _switchActiveBtn = root.Q<Button>("SwitchButton");
            _reloadBtn = root.Q<Button>("ReloadButton");
            _textBox = root.Q<TextField>("CountSpawn");

            _switchActiveBtn.RegisterCallback<ClickEvent>(ClickSwitch);
            _reloadBtn.RegisterCallback<ClickEvent>(ClickReload);
        }

        private void ClickSwitch(ClickEvent evt)
        {
            GameSwitch_SM_EX.SwitchActiveGameTo();
        }

        private void ClickReload(ClickEvent evt)
        {
            //convert _textBox.value to int
            if (_textBox.value == "") return;
            levelBuilderSmEx.countCopys = int.Parse(_textBox.value);
            GameSwitch_SM_EX.Reload();
        }
    }
}