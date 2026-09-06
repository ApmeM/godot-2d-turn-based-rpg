# Popups

Базовые popup-окна для UI, подтверждение выбора и окно квеста.

`CustomPopup.tscn` предоставляет `Title`, `CloseOnClickOutside`, `CloseOnClickButton`, `Close()` и сигнал `PopupClosed`. `CustomConfirmPopup.tscn` добавляет `Content`, `AllowYes` и сигналы `YesClicked`, `NoClicked`, `ChoiceMade`.

`QuestPopup.tscn` принимает `QuestPopupData` с описанием, требованиями и наградами. Вызов `ShowQuestPopup(BagInventoryPopup)` проверяет и списывает предметы только при успешном выполнении квеста. Для текста используется `gd-typewriterLabel`, для предметов — `gd-inventory`, а оформление берет ресурсы из этой папки и `gd-theme`.