# SoftCircuits MenuStatus Component

[![NuGet version (SoftCircuits.MenuStatus)](https://img.shields.io/nuget/v/SoftCircuits.MenuStatus.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.MenuStatus/)

```
Install-Package SoftCircuits.MenuStatus
```

## Overview

For some reason, WinForms never had an event for when a menu item is selected. There is an event for when menu items are clicked. But not as the user highlights them. At first, you might think you could work around this using `WndProc` to intercept the `WM_MENUSELECT` message. But this message is never sent. Apparently, WinForms don't use standard Windows menus. And they don't send standard Windows menu messages.

MenuStatus addresses this shortcoming. It is a simple component for WinForms that provides an event for whenever the current menu selection changes. It works whether menu items are selected using the mouse or keyboard.

## Usage

The component is simple to use. Just add it to a form by dragging it onto that form.

You will need to manually attach your menu by calling the `AttachMenuStrip()` method, passing your main `MenuStrip` control. You can do this in your form's `Load` event handler, or in your form's constructor after calling `InitializeComponent()`.

```cs
menuStatus1.AttachMenuStrip(menuStrip1);
```

To have your code detect when the selected menu item changes, add a handler for the `SelectedMenuItemChanged` event.

```cs
private void menuStatus1_SelectedMenuItemChanged(object sender, MenuStatusControl.SelectedMenuItemChangedArgs e)
{
    // null means no menu item is selected
    ToolStripItem? selectedMenuItem = e.SelectedMenuItem
}
```

## Displayling a Description for Highlighted Menu Items

If you want to display a description (for example, in the status bar) for each menu item as they are highlighted, the first question is: where will you store that description?

You could store it in the menu items' `Tag` property. For our example, we will store it in the menu items' `ToolTipText` property. This is slightly more straight forward because `ToolTipText` is already of type `string`, while `Tag` is of type `object`. So now our handler looks like this.

```cs
private void menuStatus1_SelectedMenuItemChanged(object sender, MenuStatusControl.SelectedMenuItemChangedArgs e)
{
    lblStatus.Text = e.SelectedMenuItem?.ToolTipText;
}
```

## Disabling Menu Tool Tips

The code above works. However, because we used the `ToolTipText` property, menu tool tips now pop up as we hover over menu items. Chances are, you don't want to display both a description in the status bar and also a description in a tool tip.

This is easily remedied by setting the `DisableMenuToolTips` property to `true`. This must be done *before* you call `AttachMenuStrip()`. You can also set this property in the designer. (You could also go through and manually set the `ShowItemToolTips` property of all `ToolStrip` controls and the `AutoToolTip` property of all the `ToolStripItem` controls. We don't recommend that.)

Now, those tool tips no longer appear.
