# FloatingText

Менеджер плавающих надписей: значение появляется рядом с Control, перемещается, увеличивается и затухает.

Добавьте `FloatingTextManager.tscn` в сцену и вызывайте `ShowValue(...)` или `ShowValueAsync(...)`. Методы принимают Control, PackedScene или готовую строку. Для отложенного показа используйте `ShowValueDelayed(...)` и асинхронную версию.

Параметры `Direction`, `Duration`, `Spread`, `Highlite` и `defaultControl` управляют движением и оформлением. Компонент зависит от Tween и расширений `gd-utils`.