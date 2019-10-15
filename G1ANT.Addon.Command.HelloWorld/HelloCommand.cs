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
        public class Arguments : CommandArguments
        {
            // Enter all arguments you need
            [Argument(Required = true, Tooltip = "...")]
            public TextStructure Text { get; set; }

            [Argument(Tooltip = "Result variable")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public HelloCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            // Do something: for example, display argument text on the screen
            MessageBox.Show(arguments.Text.Value);

            // Set result variable to the calculated text argument
            Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(arguments.Text.Value));

            // If you need, set another variable to the calculated text argument
            Scripter.Variables.SetVariableValue("other", new TextStructure(arguments.Text.Value));
        }
    }
}