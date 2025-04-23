Important: 
This is not a classic finite-state machine that can only be in one state at a time.
This implementation supports scenarios like: no active states — or any number of active states simultaneously.

Features:
- Simple and easy to use.
- Multiple states.
- Custom StateMachine implementation.
- Custom IState implementation.
- Works with Unity.
- Can be adaptive to Unity`s Job System.

## Использование:

### Инициализация State Machine:

Обычная инициализация:

```csharp
private StateMachine<Your_Context> _states;

void Init()
{
    var stateRegistry = new StateRegistry<Your_Context>();
    
    stateRegistry.AddState(new State_1());  
    stateRegistry.AddState(new State_2());  
    stateRegistry.AddState(new State_3());
    
    var stateActivator = new StateActivator<Your_Context>(stateRegistry.GetStatesBaseArray());
    _states = new StateMachine<Your_Context>(stateRegistry, stateActivator);
}
```

При помощи билдера:
```csharp
private StateMachine<Your_Context> _states;
void Init()
{
    _states = new StateMachineBuilder<Your_Context>()
        .AddState(new State_1())  
        .AddState(new State_2())  
        .AddState(new State_3())  
        .Build();
    
    //или добавление списком
    _states = new StateMachineBuilder<Your_Context>()
        .AddStates(new State_1(), new State_2(), new State_3())  
        .Build();
}
```
### Переходы в другие состояния

Переключение состояния - выключает все остальные состояния при переходе
Если целевое состояние уже активно - перехода не будет
```csharp
_states.SwitchToState<State_1>(Your_Context);
```

Такой способ не влияет на активность других состояний
bool - вкл/выкл
```csharp
_states.SetActivState<State_1>(true, Your_Context);
```

Выйти из всех активных состояний
```csharp
_states.DeactivateAllStates(Your_Context);
```

Сохраняет текущие активные состояния
```csharp
_states.SaveCurrentStatesToPrevious()
//после этого обычно
//_states.DeactivateAllStates(Your_Context);
```
Активирует все сохраненные состояния(список обнуляется)
```csharp
_states.SaveCurrentStatesToPrevious()
```

### Обновление состояний

Этот метод вызывает UpdateState КАЖДОГО активного состояния
```csharp
_states.UpdateStates(Your_Context)
```
