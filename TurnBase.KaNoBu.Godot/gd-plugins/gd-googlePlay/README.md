# Google Play Games

Android-адаптер Google Play Games Services и реализация репозитория достижений.

Добавьте `GodotPlayGameService.tscn` в дерево как служебный узел и передайте его NodePath компонентам достижений. Скрипт обращается к Android singleton через `Plugin.Call(...)`; доступны вход, игроки, достижения, события, таблицы лидеров и snapshots.

Компонент работает только при наличии настроенного Android plugin `GodotGooglePlayGameServices` и корректной export-конфигурации. В редакторе и на других платформах используйте `gd-achievements` с локальным репозиторием. Сцена использует шрифт из `gd-popups`.