using System;
using System.Collections.Generic;
using System.Linq;
using _Project.System.StateMachine.Interfaces;

namespace _Project.System.StateMachine.StateMachine.ActiveStateManager
{
    public static class StateBitManager<T>
    {
        private static readonly Dictionary<Type, ulong> _typeToBit = new();
        private static ulong _nextBit = 1; // Начинаем с 1 (0 не используется)

        // Автоматически назначает бит новому типу состояния
        public static ulong GetBitForType(Type stateType)
        {
            if (!_typeToBit.TryGetValue(stateType, out ulong bit))
            {
                if (_nextBit == 0) 
                    throw new InvalidOperationException("No more bits available!");

                bit = _nextBit;
                _typeToBit[stateType] = bit;
                _nextBit <<= 1; // Сдвигаем бит влево для следующего типа
            }
            return bit;
        }
    }
    public class StateActivator<T> : IStateActivator<T>
    {
        private ulong _activeStatesBits; // Битовая маска активных состояний
        private readonly Dictionary<Type, IState<T>> _states; // Ссылка на ваш исходный словарь
        
        public StateActivator(Dictionary<Type, IState<T>> states)
        {
            _states = states;
        }

        public void ActivateState(IState<T> state, T context)
        {
            var bit = StateBitManager<T>.GetBitForType(state.GetType());
            if ((_activeStatesBits & bit) == 0)
            {
                state.EnterState(context);
                _activeStatesBits |= bit; // Устанавливаем бит
            }
        }

        public void DeactivateState(IState<T> state, T context)
        {
            var bit = StateBitManager<T>.GetBitForType(state.GetType());
            if ((_activeStatesBits & bit) != 0)
            {
                state.ExitState(context);
                _activeStatesBits &= ~bit; // Сбрасываем бит
            }
        }
        
        public void DeactivateAllStates(T context)
        {
            foreach (var type in _states.Keys)
            {
                var bit = StateBitManager<T>.GetBitForType(type);
                if ((_activeStatesBits & bit) != 0)
                {
                    _states[type].ExitState(context);
                }
            }
            _activeStatesBits = 0; // Сброс всех битов за O(1)
        }
        public void ChangeStatusState(IState<T> state, bool setActive, T context)
        {
            if (setActive)
            {
                ActivateState(state, context);
            }
            else
            {
                DeactivateState(state, context);
            }
        }
        public void SwitchToState(IState<T> state, T context)
        {
            if (IsStateActive(state))
            {
                // Debug.Log ("State already active");
                return; // Если состояние уже активно, ничего не делаем
            }
            DeactivateAllStates(context);
            ActivateState(state, context);
        }
        public bool IsStateActive(IState<T> state)
        {
            var bit = StateBitManager<T>.GetBitForType(state.GetType());
            return (_activeStatesBits & bit) != 0; // Проверяем, активен ли бит
        }
        public bool IsStateActive(Type stateType)
        {
            var bit = StateBitManager<T>.GetBitForType(stateType);
            return (_activeStatesBits & bit) != 0; // Проверяем, активен ли бит
        }
        public void Update(T context)
        {
            // activeStates.C
            foreach (var state in _states)
            {
                if (!IsStateActive(state.Key))
                {
                    continue;
                }
                state.Value.UpdateState(context);
            }
        }
    }
}