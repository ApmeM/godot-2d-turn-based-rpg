# TypewriterLabel

Label с постепенным выводом текста, паузой и пропуском анимации.

Установите `Text`, задайте `Speed` и вызовите `Start()`. Управление состоянием доступно через `IsTyping`; методы `Pause()`, `Resume()` и `ForceFinish()` управляют текущим выводом. После завершения испускается сигнал `TypingFinished`.

```csharp
var label = GetNode<TypewriterLabel>("Text");
label.Text = "A new quest awaits.";
label.Start();
```

Клик, Space и Escape ускоряют или завершают печать. Компонент используется, в частности, в квестовом popup.