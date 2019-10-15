# G1ANT.Addon.Command.Hello

G1ANT.Studio is a open platform, which enable you to create new features like Commands, Structures, Compilers, Triggers, Panels and Wizards. 
In this tutorial I will show you how to create new Command in G1ANT.Studio.

First of all, you should install [G1ANT.Addon.Sdk](https://github.com/G1ANT-Robot/G1ANT.Sdk/raw/master/G1ANT.Sdk.vsix) in your Visual Studio Environment. When you are ready, let's go to the next step.

## What we need

We want the new command Hello, which 

* will display 'Hello World' dialog box on the screen if there is no parameters, 
* or 'Hello text' if there is entered any text as command parameter

As result, the command will answer date time of display operation.

## Create project

1. File -> New Project <Ctrl+Shift+N>
2. Choose **G1ANT.Robot.Addon Template** as project type and click **Next**
3. As **Project name** enter **G1ANT.Addon.HelloWorld**
4. Choose **.NET Framework 4.6.1** and click **Create**
5. When you will receive empty project, right click on the **References** -> **Manage NuGet packages**
6. If there is a message 'Some NuGet packages are missing from this solution. Click restore from your online package sources', click **Restore**
7. That's all. Your first empty addon is ready. Just click **Build** <Ctrl+B> to check.

> Note: When you build project in **Release** environment, 
> the addon will be copied into destionation **Documents/G1ANT.Robot/Add-On** directory, 
> so you should remember to close **G1ANT.Robot** program before that action.

## Prepare header

You have empty project now, and the file Addon.cs should be filled by you.

```C#
    [Addon(Name = "Hello", Tooltip = "This is my example addon")]
    [Copyright(Author = "John Smith", Copyright = "John Smith", Email = "johnsmith@gmail.com", Website = "www.johnsmith.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
```

All these information will display in the G1ANT.Studio as metadata assigned to **G1ANT.Addon.Command.Hello.dll**. 
**License.txt** will be also embeded into your addon.

When you will be ready, just close G1ANT.Robot (if open) and **Build** <Ctrl+B> your addon in **Release** environment. 
After that, execute G1ANT.Robot and check it out **Addons** panel from the menu **View**. Find **hello** and double click on that. 
You should see all header information, but the addon is empty right now. 
There is no features like Commands, Structures, Compilers, Triggers, Panels and Wizards. 

## Add Hello command

Right click on the project name **G1ANT.Addon.Command.Hello** in Visual Studio, and click **Add** -> **New Item**. Find **G1ANT.Robot** on the left, and select **G1ANT.Robot Command**, because we will create new command ```hello```. Enter **HelloCommand.cs** as class name and click **Add**. You will see **HelloCommand.cs** editor in Visual Studio.

First of all, fill the header:

```C#
    [Command(Name = "hello", Tooltip = "display hello message")]
    public class HelloCommand : Language.Command
    {
```

For now, **Name** and **Tooltip** parameters are enough, but in the future you can use also:

1. **AcceptUnlistedArguments** - it means, that your command can take additional parameters which are not specified in your **Arguments** class. You have access to these arguments by property ```Dictionary<string, object> UnlistedArguments``` from the **Arguments** class.
2. **CustomLineParse** - this command should not use standard G1ANT parsing mechanism to take arguments and executing. Use method Execute(string line) instead of ```Execute(Arguments arguments)```.
3. **IconName** - which icon should be displayed with that command. The icon should be stored as resource.
4. **NeedsDelay** - is this necessary to use delay with that command, like **keyboard** and **mouse**?

