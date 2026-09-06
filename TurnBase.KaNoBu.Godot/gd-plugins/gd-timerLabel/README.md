# TimerLabel

Label для временного сообщения.

Добавьте `TimerLabel.tscn` в UI и вызовите `ShowMessage(text, timeout)`. Текст отображается заданное количество секунд, затем очищается обработчиком Timer.

```csharp
GetNode<TimerLabel>("Message").ShowMessage("Level complete", 2f);
```