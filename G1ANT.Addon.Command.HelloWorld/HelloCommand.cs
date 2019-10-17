using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.Command.Hello
{
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
}