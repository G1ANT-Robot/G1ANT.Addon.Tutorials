# G1ANT.Addon.Command.Hello

G1ANT.Studio is an open platform, which enable you to create new features like Commands, Structures, Compilers, Triggers, Panels and Wizards. 
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

You have empty project now, and the file **Addon.cs** should be filled by you.

```C#
    [Addon(Name = "HelloWorld", Tooltip = "This is my example addon")]
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

## Implement Execute method

As the method body, let's display message "Hello World".

```C#
    [Command(Name = "hello", Tooltip = "Display hello message")]
    public class HelloCommand : Language.Command
    {

        public HelloCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        public class Arguments : CommandArguments
        {
        }

        public void Execute(Arguments arguments)
        {
            MessageBox.Show("Hello World!");
        }
    }
```

Close G1ANT.Robot.exe. Compile <Ctrl+B> this example in release environment and 
restart G1ANT.Robot.exe. 
You should see the new addon "HelloWorld" on the left. 
Select it and your command **hello** 
will be available in G1ANT.Studio intelisence and autocompletion. 

Let's use this command in the G1ANT's script:

```G1ANT
addon helloworld version 1.0.0.0
addon language version 4.100.19036.1330

hello
```

After execution you will see that message:

![Hello world](hello-world.jpg)

## Add some arguments for our command

Let's display first given argument. For example:

```G1ANT
addon helloworld version 1.0.0.0
addon language version 4.100.19036.1330

hello John
```

After robot execution we should see "Hello John!" message. Let's write some code. 
Arguments class should have one argument **Name** 
which is name of the user we would like to greet.
Take a look on the body of Execute method. When argument **Name** is empty, 
"Hello World!" will be displayed.


```C#
    [Command(Name = "hello", Tooltip = "Display hello message")]
    public class HelloCommand : Language.Command
    {
        public HelloCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Enter your name")]
            public TextStructure Name { get; set; }
        }

        public void Execute(Arguments arguments)
        {
            if (arguments.Name == null)
                MessageBox.Show("Hello World!");
            else
                MessageBox.Show($"Hello {arguments.Name.Value}!");
        }
    }
```

Close G1ANT.Robot.exe and build <ctrl+B> addon, restart G1ANT.Robot.exe 
and try to execute "hello Max" command. First argument is optional, 
but you can see it's name and tooltip by autocompletion mechanism.

![Autocompletion](autocompletion.jpg)

## Structures

You can use many structures from G1ANT.Language.dll or create your own 
(see G1ANT.Addon.Structure.Directory project G1ANT.Addon.Tutorials solution).

C# Structure | C# Type | G1ANT Name | Description
------------ | ------- | ---------- | -----------
[Structure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/Structure.md) | Object | | base class
[BooleanStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/BooleanStructure.md) | boolean | bool |
[ColorStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/ColorStructure.md) | Color | color |
[DataTableStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/DataTableStructure.md) | DataTable | table | 
[DateStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/DateTimeStructure.md) | DateTime | date | date part
[DateTimeStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/DateTimeStructure.md) | DateTime | datetime |
[DictionaryStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/DictionaryStructure.md) | Dictionary<string, object> | dictionary |
[ErrorStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/ErrorStructure.md) | Exception | error | 
[FloatStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/FloatStructure.md) | double | float |
[HtmlStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/HtmlStructure.md) | HtmlDocument | html | From HtmlAgilityPack | 
[IntegerStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/IntegerStructure.md) | int | integer |
[JsonStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/JsonStructure.md) | JObject | json | from Newtonsoft.Json |
[LabelStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/LabelStructure.md) | string | label | This structure stores names of labels, which are called by the `jump` command |
[ListStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/ListStructure.md) | List<object> | list |
[MessageStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/MessageStructure.md) | string | message |
[MoneyStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/MoneyStructure.md) | decimal | money |
[PathStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/PathStructure.md) | string | path |
[PointStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/PointStructure.md) | Point | point |
[ProcedureStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/ProcedureStructure.md) | string | procedure | This structure stores names of procedures
[RectangleStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/RectangleStructure.md) | Rectangle | rectangle |
[TextStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/TextStructure.md) | string | text |
[TimeSpanStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/TimespanStructure.md) | TimeSpan | timespan |
[TimeStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/TimeStructure.md) | DateTime | time | time part
[VariableStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/VariableStructure.md) | string | variable | This structure stores names of variables 
[VersionStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/VersionStructure.md) | Version | version |
[XmlStructure](https://manual.g1ant.com/G1ANT.Addons/G1ANT.Language/Structures/XmlStructure.md) | XmlDocument | xml |

## Result as Variable

Ok, but how command can give us result of any operation? 
Let's take current logged user from the system into variable.

```C#
    [Command(Name = "hello", Tooltip = "Display hello message")]
    public class HelloCommand : Language.Command
    {
        public HelloCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        public class Arguments : CommandArguments
        {
            [Argument(Required = false, Tooltip = "Enter your name")]
            public TextStructure Name { get; set; }

            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments)
        {
            if (arguments.Name == null)
                MessageBox.Show($"Hello World!");
            else
                MessageBox.Show($"Hello {arguments.Name.Value}!");

            Scripter.Variables.SetVariableValue(arguments.Result.Value, 
                new TextStructure(Environment.UserName));
        }
    }
```

As you see on an example above, we've defined new argument **Result** as `VariableStructure`. 
It means our command expects name of variable, where `Environment.UserName` will be stored. 
Default name of these variable is **result**.

The last line of the `Execute` method contains code which is responsible for variable setup.
After build <Ctrl+B> you can execute script below, and as a result you will receive dialog message 
with your username.

```G1ANT
hello
dialog ♥result
```

![Result](result.jpg)

Remember, that we've created command with two parameters, so it is possible to use it in different ways, like this:

```G1ANT
hello result ♥username
dialog ♥username
```

or this:

```G1ANT
hello result ♥username name John
dialog ♥username
```

or this:

```G1ANT
hello John result ♥username
dialog ♥username
```

## Access to the Scripter

As you see, during command execution we have access to `Scripter` context, 
so it is possible for example to take all variables by 'Scripter.Variables` property.

The most important properties and methods below:

name | description
---- | -----------
`Dictionary<string, byte[]> Resources` | all files embeded with script
`Stack<[StackItem]> Stack` | Execution stack for block commands like procedure, see [StackItem class](#stackitem-class)
`virtual int CurrentLine` |
`string[] ScriptLines` | All script lines
`string Text` | All script lines, separated by `\r\n`
`virtual string CurrentLineText` | Current script line
`AbstractMacroResolver MacroResolver` | See [AbstractMacroResolver](#abstractmacroresolver-class)
`AbstractCommandManager Commands` | See [AbstractCommandManager](#abstractcommandmanager-class)
`AbstractLanguageParser Parser` | See [AbstractLanguageParser](#abstractlanguageparser-class)
`AbstractStructureManager Structures` | See [AbstractStructureManager](#abstractstructuremanager-class)
`AbstractVariableManager Variables` | See [AbstractVariableManager](#abstractvariablemanager-class)
`AbstractLogger Log` | See [AbstractLogger](#abstractlogger-class)
`abstract List<Addon> Addons` | All addons used by the script, see [Addon](#addon-class)
`abstract void AddAddon(Addon addon, bool updateScript = true)` | See [Addon](#addon-class)
`abstract void RemoveAddon(Addon addon, bool updateScript = true)` | See [Addon](#addon-class)
`string ProcessPath` | Full path to the script file
`bool Stopped` | Is the script stopped? or we can stop the script
`abstract void RunLine(string line)` | Execute line of script code
`abstract StackItem CreateStackItem(BlockItem block)` | See [BlockItem class](#blockitem-class)
`abstract void Delay(int miliseconds = 1000)` |
`abstract TimeSpan ExecutingTime` |
`abstract StackItem CreateStackItem(BlockItem block)` | See [BlockItem class](#blockitem-class)

<!-- TODO: write description for all these elements above -->
<!-- TODO: We shoul write more about classes we used here -->

## StackItem class

```C#
    public class StackItem
    {
        public BlockItem Block { get; }
        public int CallingLineNumber { get; }

        public AbstractVariableManager Variables { get; set; }

        public LabelStructure ErrorJump { get; set; }

        public ProcedureStructure ErrorCall { get; set; }

        public VariableStructure ErrorResult { get; set; }

        public string ErrorMessage { get; set; }

        public StackItem(BlockItem block, int line, AbstractVariableManager variableManager)
        {
            Block = block;
            CallingLineNumber = line;
            Variables = variableManager;
        }
    }
```

## AbstractMacroResolver class

```C#
    public abstract class AbstractMacroResolver : MarshalByRefObject
    {
        protected AbstractMacroResolver()
        {
        }

        public abstract void Clear();

        public abstract object EvalExpression(string text, AbstractScripter scripter, bool convertToStructure = false);
    }
```

## AbstractCommandManager class

```C#
    public abstract class AbstractCommandManager : IEnumerable
    {
        public AbstractScripter Scripter { get; set; } = null;

        protected AbstractCommandManager(AbstractScripter scripter)
        {
            Scripter = scripter;
        }

        public abstract Command FindCommand(string name);
        public abstract Command FindCommand(Type classType);

        public virtual string[] AvailableCommands { get; } = null;

        public abstract Structure GetPropertyFromCmdArgument(CommandArguments arguments, string propertyName, Type type);

        public abstract IEnumerator GetEnumerator();

        public abstract IEnumerable<Command> GetAllCommands();

        public abstract void Delay(int miliseconds = 1000);
    }
```

## AbstractLanguageParser class

```C#
    public abstract class AbstractLanguageParser
    {
        public AbstractLanguageParser(AbstractScripter scripter)
        {
            Scripter = scripter;
        }

        public AbstractScripter Scripter { get; set; } = null;

        public abstract ParserResult ParseLine(string line);

        public abstract Structure ParseValue(string value, Type expectedType = null);

        public abstract void ExtractVariableParts(string str, ref int pos, ref string variableName, ref string variableIndex,
            bool tryToCompile = false);

        public abstract string ReplaceVariables(string code, ref Dictionary<string, object> variables);
    }
```

## AbstractStructureManager class

```C#
    public abstract class AbstractStructureManager
    {
        public AbstractStructureManager(AbstractScripter scripter)
        {
            Scripter = scripter;
        }

        public AbstractScripter Scripter { get; } = null;

        public abstract Structure CreateStructure(object obj, string format = "", Type expectedType = null);

        public abstract Structure CreateStructure(object obj, string typeName, string format);

        public abstract Structure CreateStructure(ArgumentValue obj, string format = "");

        public abstract Type GetValueTypeByStructName(string structName);

        public abstract IEnumerable<Structure> GetAllStructures();
    }
```

## AbstractVariableManager class

```C#
    public abstract class AbstractVariableManager : IEnumerable
    {
        public AbstractScripter Scripter { get; } = null;

        protected AbstractVariableManager(AbstractScripter scripter)
        {
            Scripter = scripter;
        }

        public Variable GetVariable(string name)
        {
            return this[name];
        }

        public abstract T GetVariableValue<T>(string name, T defaultVal = default(T), bool setDefault = false);

        public abstract void SetVariableValue(string name, Structure value);

        public abstract void SetVariableValue(string name, string index, Structure value);

        public abstract void ParseAndSetVariable(string name, string value);

        public abstract IEnumerator GetEnumerator();

        public abstract IList<Variable> GetAllVariables();

        public abstract IList<Variable> GetAttributedVariables();

        public abstract IList<Variable> GetScripterVariables();

        public abstract Variable this[string key]
        { get; }

        public abstract bool ContainsKey(string name);

        public abstract int Count { get; }
    }
```

## AbstractLogger class

```C#
    public abstract class AbstractLogger
    {
        public enum Level
        {
            Trace,
            Debug,
            Info,
            Warn,
            Error,
            Fatal
        }

        protected AbstractLogger(AbstractScripter scripter)
        {
            Scripter = scripter;
        }

        public abstract void LogMessage(Level level, string message);

        public abstract void Log(Level level, string message);

        public AbstractScripter Scripter { get; protected set; }
    }
```

## BlockItem class

```C#
    public class BlockItem
    {
        public string CommandName { get; }
        public ArgumentsBase DefaultArguments { get; }
        public int StartLine { get; }
        public int EndLine { get; set; } = -1;
        public string Definition { get; }

        public BlockItem(string name, ArgumentsBase defaultArguments, int startLine, string def)
        {
            CommandName = name;
            DefaultArguments = defaultArguments;
            this.StartLine = startLine;
            Definition = def;
        }
    }
```

## Addon class

```C#
    /// <summary>Any library of commands, structures, wizards and/r triggers
    /// - must contain exactly one class that derives from Addon class, 
    /// - must be marked with AddonAttribute, 
    /// - must contain virtual methods Check(), Initialize()and Finalise().
    /// </summary>
    /// <example>
    ///   <para>[Addon(name = "example")]</para>
    ///   <para>public class ExampleAddon : Addon</para>
    /// </example>
    public class Addon : IDisposable
    {
        /// <summary>Assembly that contains current Addon.</summary>
        public Assembly Assembly => Assembly.GetAssembly(GetType());

        /// <summary>List of all currently loadded Addons.</summary>
        public static Dictionary<string, Addon> Loaded { get; } = new Dictionary<string, Addon>();

        private bool initialized = false;

        /// <summary>Load an Addon from given assembly name.</summary>
        public static Addon Load(string name)
        {
            //check for name in loaded assemblies
            var assembly = AssemblyManager.Find(name);

            if (assembly != null)
            {
                return Load(assembly);
            }

            //check for name in other sources
            assembly = AssemblyManager.Load(name);

            if (assembly != null)
            {
                return Load(assembly);
            }

            return null;
        }

        /// <summary>Load Addon from Assembly.</summary>
        public static Addon Load(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            Addon addon = Create(assembly);

            if (addon != null)
            {
                var name = addon.Attributes.Name.ToLower();

                //check in cache
                if (Loaded.ContainsKey(name))
                    return Loaded[name];

                addon.Initialize();
                Loaded.Add(name, addon);
            }

            return addon;
        }

        /// <summary>Create instance of class Addon from specified Assembly.</summary>
        /// <param name="assembly">Assembly containing a class that is derived from Addon class and is marked with AddonAttribute.</param>
        /// <returns>Instance of Addon class.</returns>
        public static Addon Create(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (Attribute.IsDefined(type, typeof(AddonAttribute)))
                {
                    if (type.IsSubclassOf(typeof(Addon)))
                    {
                        try
                        {
                            return (Addon)Activator.CreateInstance(type);
                        }
                        catch (TargetInvocationException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            throw new MissingMethodException("Class derived from Addon has to implement parameterless public constructor", ex);
                        }
                    }

                    throw new MissingFieldException($"{type.Name} class with [Addon] attribute should be derived from Addon class");
                }
            }

            return null;
        }

        /// <summary>List of commands defined in the current Addon.</summary>
        public List<Command> Commands { get; } = new List<Command>();

        /// <summary>List of triggers defined in the current Addon.</summary>
        public List<Trigger> Triggers { get; } = new List<Trigger>();

        /// <summary>List of sructures defined in the current Addon.</summary>
        public List<Structure> Structures { get; } = new List<Structure>();

        /// <summary>List of all variables defined in the current Addon.</summary>
        public List<Variable> SpecialVariables { get; } = new List<Variable>();

        /// <summary>List of dlls assigned to current Addon. These are strong or short names.</summary>
        public List<string> Dlls { get; } = new List<string>();

        /// <summary>List of all panels defined in the Addon.</summary>
        public List<RobotPanel> Panels { get; } = new List<RobotPanel>();

        /// <summary>List of all wizards defined in the Addon.</summary>
        public List<Wizard> Wizards { get; } = new List<Wizard>();

        /// <summary>List of all compilators defined in the Addon.</summary>
        public List<AbstractSnippetsEvaluator> Compilers { get; } = new List<AbstractSnippetsEvaluator>();

        /// <summary>
        /// Load metadata of Addon contents, this means a lists of Commands, Structures, Triggers, Panels, Wizards, Compilers, SpecialVariables.
        /// Can be overriden in derived class to load additional data with additional attributes.
        /// </summary>
        public virtual void LoadMetadata()
        {
            foreach (Type type in Assembly.GetTypes())
            {
                try
                {
                    if (Attribute.IsDefined(type, typeof(CommandAttribute)))
                        Commands.Add((Command)Activator.CreateInstance(type, new object[] { null }));
                    else if (Attribute.IsDefined(type, typeof(TriggerAttribute)))
                        Triggers.Add((Trigger)Activator.CreateInstance(type));
                    else if (Attribute.IsDefined(type, typeof(StructureAttribute)))
                        Structures.Add((Structure)Activator.CreateInstance(type, new object[] { null, null, null }));
                    else if (Attribute.IsDefined(type, typeof(VariableAttribute)))
                        SpecialVariables.Add((Variable)Activator.CreateInstance(type, (AbstractScripter)null));
                    else if (Attribute.IsDefined(type, typeof(PanelAttribute)))
                        Panels.Add((RobotPanel)Activator.CreateInstance(type));
                    else if (Attribute.IsDefined(type, typeof(WizardAttribute)))
                        Wizards.Add((Wizard)Activator.CreateInstance(type));
                    else if (Attribute.IsDefined(type, typeof(CompilerAttribute)))
                        Compilers.Add((AbstractSnippetsEvaluator)Activator.CreateInstance(type));
                }
                catch (TargetInvocationException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw new MissingMethodException($"Class {type.FullName} has to implement parameterless public constructor", ex);
                }
            }
        }

        /// <summary>Load all dll files that are required by current Addon.</summary>
        public virtual void LoadDlls()
        {
            Dlls.Clear();
            foreach (var item in GetType().GetCustomAttributes())
            {
                if (item is AddonDllAttribute attribute)
                {
                    if (Assembly.IsDynamic == false)
                    {
                        if (Assembly.GetManifestResourceNames().
                            Contains<string>(attribute.Name))
                        {
                            byte[] bytes = Assembly.GetResourceBytes(attribute.Name);
                            try
                            {
                                Assembly.Load(bytes);
                                Dlls.Add(attribute.Name);
                            }
                            catch
                            {
                                throw new DllNotFoundException($"Unable to load dll {attribute.Name} from resource. Make sure that it is in the right folder");
                            }
                        }
                        else
                            throw new DllNotFoundException($"Dll {attribute.Name} not found. Make sure that it is in the right folder");
                    }
                }
            }
        }

        /// <summary>Verify that the Addon is written correctly. Throws an exception in case an error is found.</summary>
        public virtual void Check()
        {
            if (Copyright == null)
                throw new ApplicationException($"Addon '{GetType().FullName}' should be described by CopyrightAttribute.");
            if (!Licenses.Where(x => !string.IsNullOrEmpty(x.UrlReference) || !string.IsNullOrEmpty(x.ResourceName)).Any())
                throw new ApplicationException($"Addon '{GetType().FullName}' should be described by at least one LicenseAttribute.");
            if (string.IsNullOrWhiteSpace(Attributes.Name))
                throw new ArgumentNullException(nameof(Attributes.Name));
            if (string.IsNullOrWhiteSpace(Attributes.Tooltip))
                throw new ArgumentNullException(nameof(Attributes.Tooltip));
            foreach (Command command in Commands)
                command.Check();
            foreach (Trigger trigger in Triggers)
                trigger.Check();
            foreach (Structure structure in Structures)
                structure.Check();
            foreach (Variable variable in SpecialVariables)
                variable.Check();
            foreach (RobotPanel panel in Panels)
                panel.Check();
            foreach (Wizard wizard in Wizards)
                wizard.Check();
        }

        /// <summary>Called during initialisation of Addon during first load into Robot instance.</summary>
        public virtual void Initialize()
        {
            if (initialized)
                return;
            initialized = true;

            LoadDlls();
            LoadMetadata();
            Check();
        }

        private AddonAttribute _attributes = null;

        /// <summary>Addon attribute assigned to current structure, containing i.e. name, tooltip...</summary>
        public AddonAttribute Attributes => _attributes ?? (_attributes = GetAttributes());

        private AddonAttribute GetAttributes()
        {
            var attributes = GetType().GetCustomAttributes(typeof(AddonAttribute), true);
            return attributes.Length > 0 ? (AddonAttribute)attributes[0] :
                throw new ApplicationException($"Addon '{GetType().FullName}' should be described by AddonAttribute.");
        }

        private string GetLicenseContent(LicenseAttribute license)
        {
            byte[] licenseContent = this.Assembly.GetManifestResourceBytes(license.ResourceName);
            return Encoding.UTF8.GetString(licenseContent);
        }

        private List<LicenseAttribute> licenses = null;

        public List<LicenseAttribute> Licenses
        {
            get
            {
                if (licenses == null)
                    licenses = GetType().GetCustomAttributes<LicenseAttribute>(true).ToList();
                return licenses;
            }
        }

        private CopyrightAttribute copyright = null;

        public CopyrightAttribute Copyright
        {
            get
            {
                if (copyright == null)
                    copyright = GetType().GetCustomAttributes<CopyrightAttribute>(true).FirstOrDefault();

                return copyright;
            }
        }

        private List<CommandGroupAttribute> _commandGroups = null;

        /// <summary>List of attribute CommandGroupAttribute assigned to commands, containing i.e. name, tooltip...</summary>
        public List<CommandGroupAttribute> CommandGroups => _commandGroups ?? (_commandGroups = GetCommandGroups());

        private List<CommandGroupAttribute> GetCommandGroups()
        {
            List<CommandGroupAttribute> result = new List<CommandGroupAttribute>();
            var attributes = GetType().GetCustomAttributes(typeof(CommandGroupAttribute), true);
            foreach (Command command in Commands)
            {
                if (string.IsNullOrWhiteSpace(command.GroupName) == false)
                {
                    var foundAttribute = attributes.Cast<CommandGroupAttribute>().Where(x => x.Name.ToLower() == command.GroupName.ToLower()).FirstOrDefault();
                    var attr = new CommandGroupAttribute()
                    {
                        Name = command.GroupName.ToLower()
                    };
                    if (foundAttribute != null)
                    {
                        attr.Tooltip = foundAttribute?.Tooltip;
                        attr.IconName = foundAttribute?.IconName;
                    }
                    result.Add(attr);
                }
            }
            return result;
        }

        public Bitmap GetCommandGroupIcon(CommandGroupAttribute attribute)
        {
            return GetType().Assembly.GetResxImageResource(attribute.IconName) ??
                typeof(Addon).Assembly.GetResxImageResource(attribute.IconName) ??
                new Bitmap(1, 1);
        }

        public Version Version
        {
            get
            {
                return GetType().Assembly.GetName().Version;
            }
        }

        protected Version emptyVersion = new Version();

        public virtual bool IsMigrationNeeded(string script, Version previousVersion, AbstractScripter scripter)
        {
            return previousVersion == emptyVersion;
        }

        protected virtual string MigrateScript(string script, Version previousVersion, AbstractScripter scripter)
        {
            return script;
        }

        public string DoMigration(string script, Version previousVersion, AbstractScripter scripter)
        {
            script = MigrateScript(script, previousVersion, scripter);
            if (IsMigrationNeeded(script, previousVersion, scripter))
            {
                // add entry for current addon
                AddonCommand.InsertAddonToScript(ref script, this, scripter);
            }

            return script;
        }

        /// <summary>Method executed when work with Addon is finished. Used i.e. to remove temporary files.</summary>
        public virtual void Dispose()
        {

        }


        private string SerializeList(IEnumerable<string> elementXmlList, string parentName)
        {
            var result = new StringBuilder();
            result.AppendLine($"<{parentName}>");
            foreach (var elementXml in elementXmlList)
            {
                result.AppendLine(elementXml);
            }
            result.AppendLine($"</{parentName}>");

            return result.ToString();
        }

        public string ToXml()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<G1ANT.Addon>");
            sb.AppendLine("<Addon>");

            sb.AppendLine("<AddonDetails>");

            sb.AppendLine($"<Name>{SecurityElement.Escape(Attributes.Name)}</Name>");
            sb.AppendLine($"<Tooltip>{SecurityElement.Escape(Attributes.Tooltip)}</Tooltip>");

            var executingAssembly = Assembly.GetExecutingAssembly();
            var fileName = Path.GetFileName(executingAssembly.Location);
            var version = executingAssembly.GetName().Version.ToString();

            sb.AppendLine($"<FileName>{SecurityElement.Escape(fileName)}</FileName>");
            sb.AppendLine($"<Version>{SecurityElement.Escape(version)}</Version>");
            if (Copyright != null)
            {
                sb.AppendLine($"<Copyright>{SecurityElement.Escape(Copyright.Copyright)}</Copyright>");
                sb.AppendLine($"<Email>{SecurityElement.Escape(Copyright.Email)}</Email>");
                sb.AppendLine($"<Website>{SecurityElement.Escape(Copyright.Website)}</Website>");
            }

            if (Licenses.Count != 0)
            {
                sb.AppendLine($"<LicenseType>{SecurityElement.Escape(Licenses.First().Type)}</LicenseType>");
                sb.AppendLine($"<LicenseResource>{SecurityElement.Escape(Licenses.First().ResourceName)}</LicenseResource>");
                sb.AppendLine($"<LicenseUrl>{SecurityElement.Escape(Licenses.First().UrlReference)}</LicenseUrl>");
            }
            sb.AppendLine("</AddonDetails>");

            sb.Append(SerializeList(Commands.Select(c => c.ToXml()), "Commands"));
            sb.Append(SerializeList(Triggers.Select(t => t.ToXml()), "Triggers"));
            sb.Append(SerializeList(Structures.Select(s => s.ToXml()), "Structures"));
            sb.Append(SerializeList(SpecialVariables.Select(sv => sv.ToXml()), "SpecialVariables"));
            sb.Append(SerializeList(Panels.Select(p => p.ToXml()), "Panels"));
            sb.Append(SerializeList(Wizards.Select(w => w.ToXml()), "Wizards"));
            sb.Append(SerializeList(Compilers.Select(c => c.ToXml()), "Compilers"));

            sb.AppendLine("</Addon>");
            sb.AppendLine("</G1ANT.Addon>");

            return XDocument.Parse(sb.ToString())
                .ToString();
        }
    }
}```