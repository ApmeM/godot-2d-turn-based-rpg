# Minimap

Миникарта для отображения объектов игрового мира и их маркеров.

Добавьте `Minimap.tscn` в UI, задайте `CenterNodePath` и границы мира через `SetMapSizeToNode(Node2D, size)` или `SetMapSizeToNode(Rect2)`. Отслеживаемые узлы добавьте в группу `MinimapElement`.

Элемент группы должен быть Sprite либо реализовывать `IMinimapElement`. Свойство `VisibleOnBorder` разрешает показывать маркер у границы, когда объект вышел за пределы миникарты; `Sprite` задает его изображение.