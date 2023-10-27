using Spectre.Console;


/*
--------------------Read Me--------------------
Styles: https://spectreconsole.net/prompts/selection

Estructura del login

- Registro == Sign in

	Alumno:
		- Register 
		- Grupo () 
		- Nombre
		- Apellido Paterno
		- Materno
		- Contrasena
	Almacenista:
		- ID
		- Nombre
		- Paterno
		- Materno
		- Contrasena
	Profesor:
		- Nomina
		- Nombre
		- Paterno
		- Materno
		- Contrasena
		- 

- Iniciar sesion

    ID (Registro, Nomina, Nomina, Clave)
    Contraseña

- Recuperar contraseña

    ID
    Establezca una contraseña nueva
    Sobreescribir la contraseña

*/



public static class Program
{
    public static void Main(string[] args)
    {
            var log = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[teal]Super amazing bombastic login pro 4K [/]")
                .PageSize(10)
                .AddChoices(new[] {
                    "Sign in", "Sign up", "Forgot password", "Exit"
                }));
            switch (log)
            {
                case "Sign in":
                var SI_id = AnsiConsole.Ask<string>("[green]What's your ID?[/]");
                var SI_password = AnsiConsole.Ask<string>("[green]Enter password[/]");
                //you can use this variables to send those to a function and make a query
                break;
                case "Sign up":
                    var user = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[green]What's your user[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Student", "Almacenist", "Teacher",  "Exit"
                    }));
                    switch(user)
                    {
                        case "Student":
                            AnsiConsole.MarkupLine($"You selected: [chartreuse2_1]{user}[/]");
                            var St_id = AnsiConsole.Ask<string>("[darkblue]Write yout registry[/]");
                            var St_group = AnsiConsole.Ask<string>("[darkblue]What's your group[/]");
                            var St_name = AnsiConsole.Ask<string>("[darkblue]What's your name[/]");
                            var St_Psurname = AnsiConsole.Ask<string>("[darkblue]What's your paternal surname[/]");
                            var St_Msurname = AnsiConsole.Ask<string>("[darkblue]What's your maternal surname[/]");
                            var St_pwd1 = AnsiConsole.Ask<string>("[darkblue]What's your password[/]");
                            var St_pwd2 = AnsiConsole.Ask<string>("[darkblue]Repeat yout password[/]");//optional
                            //send this variables to a fuction
                        break; 
                        case "Almacenist":
                            AnsiConsole.MarkupLine($"You selected: [chartreuse2_1]{user}[/]");
                            var Al_id = AnsiConsole.Ask<string>("[darkblue]Write yout key[/]");
                            var Al_name = AnsiConsole.Ask<string>("[darkblue]What's your name[/]");
                            var Al_Psurname = AnsiConsole.Ask<string>("[darkblue]What's your paternal surname[/]");
                            var Al_Msurname = AnsiConsole.Ask<string>("[darkblue]What's your maternal surname[/]");
                            var Al_pwd1 = AnsiConsole.Ask<string>("[darkblue]What's your password[/]");
                            var Al_pwd2 = AnsiConsole.Ask<string>("[darkblue]Repeat yout password[/]");//optional
                            //same 
                        break;
                        case "Teacher":
                            AnsiConsole.MarkupLine($"You selected: [chartreuse2_1]{user}[/]");
                            var Tc_payroll = AnsiConsole.Ask<string>("[darkblue]Write yout payroll[/]");
                            var Tc_name = AnsiConsole.Ask<string>("[darkblue]What's your name[/]");
                            var Tc_Psurname = AnsiConsole.Ask<string>("[darkblue]What's your paternal surname[/]");
                            var Tc_Msurname = AnsiConsole.Ask<string>("[darkblue]What's your maternal surname[/]");
                            var Tc_pwd1 = AnsiConsole.Ask<string>("[darkblue]What's your password[/]");
                            var Tc_pwd2 = AnsiConsole.Ask<string>("[darkblue]Repeat yout password[/]");//optional
                            //same 
                        break;
                        case "Exit":
                            //it must be called again to the main menu, sign in /sign up /forgot pwd
                        break;
                    }
                break;
                case "Forgot password":
                    var FP_email = AnsiConsole.Ask<string>("[green]What's your e-mail acount?[/]");
                    //send this to a fuction
                break;
                case "Exit":
                    AnsiConsole.MarkupLine($"[red]Bye bye :)[/]");
                break;
            }
    }
}
