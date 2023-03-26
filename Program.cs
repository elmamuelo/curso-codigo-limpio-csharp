
namespace ToDo;

internal class Program
{
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if ((Menu)menuSelected == Menu.Add)
            {
                ShowMenuAdd();
            }
            else if ((Menu)menuSelected == Menu.Remove)
            {
                ShowMenuRemove();
            }
            else if ((Menu)menuSelected == Menu.List)
            {
                ShowMenuTasklist();
            }
        } while ((Menu)menuSelected != Menu.Exit);
    }
    /// <summary>
    /// Show the options for task: (1. Nueva tarea  2. Remover tarea 3. Tareas pendientes 4. Salir)
    /// </summary>
    /// <returns>Selected by user</returns>
    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        string line = Console.ReadLine();
        return Convert.ToInt32(line);
    }

    public static void ShowTaskList()
    {
        if (!(TaskList?.Count > 0))
        {
            Console.WriteLine("No hay tareas por realizar");
        }
        else
        {
            Console.WriteLine("----------------------------------------");
            int indexTask = 0;
            TaskList.ForEach(task => Console.WriteLine($"{++indexTask} - {task}"));
            Console.WriteLine("----------------------------------------");
        }
    }

    public static void ShowMenuRemove()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
         
            ShowTaskList();

            // Removes one position because de array starts in 0
            int indexToRemove = Convert.ToInt32(Console.ReadLine()) - 1;

            if(indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
            {
                Console.WriteLine("La tarea seleccionada no es valida");
                ShowMenuRemove();
            }
            else
            {
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada");
                }
            }

            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ha ocurrido un error");
        }
    }

   

    public static void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string task = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(task))
            {
                Console.WriteLine("No se permiten nombres vacios");
                ShowMenuAdd();
            }
            else {
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ha ocurrido un error");
        }
    }

    public static void ShowMenuTasklist()
    {
        ShowTaskList();            
    }
}

public enum Menu
{
    Add =1,
    Remove = 2,
    List = 3, 
    Exit = 4
}
