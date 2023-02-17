namespace oop031222;
class Tester
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        Employee[] listNV = new Employee[]
        {
            new Employee("Nguyen Van A", new DateTime(1991,05,02), new DateTime(2020,03,14), 50000),
            new Employee("Nguyen Van B", new DateTime(2007,01,30), new DateTime(2020,03,14), 22000),
            new Employee("Nguyen Van C", new DateTime(1989,11,10), new DateTime(2019,04,28), 74000)
        };
        employees.AddRange(listNV);

        List<Formateur> formateurs = new List<Formateur>();
        Formateur[] listGV = new Formateur[]
        {
            new Formateur("Vo Xuan Tuan", new DateTime(2003,05,01), new DateTime(2022,12,05), 78000, 12)
        };
        formateurs.AddRange(listGV);

        // Menu
        Console.Write("\nProgram Employee Management And Tax IR:");
        Console.Write("\n1.Table IR");
        Console.Write("\n2.List employees");
        Console.Write("\n3.List formateurs");
        Console.Write("\n4.Equals()");
        Console.Write("\n5.Check if the age is 16");
        Console.Write("\n6.Output 3 interfaces");
        Console.Write("\n7.IComparable<Employee>");
        Console.Write("\n0.Exit program");
        int option;
        do
        {
            Console.Write("\nPlease enter options: ");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 0: return;
                case 1:
                    Console.Write("************TABLE IR************");
                    TableIR.Display();
                    break;
                case 2:
                    Console.Write("\n********List Employee*********\n");
                    foreach (dynamic venus in employees)
                    {
                        Console.WriteLine(venus);
                    }
                    break;
                case 3:
                    Console.Write("\n********List Formateurs*********\n");
                    foreach (dynamic venus in formateurs)
                    {
                        Console.WriteLine(venus.ToString());
                    }
                    break;
                case 4:
                    Console.Write("\nCompare 2 employees by registration code:");
                    Employee.Equals(listNV[0].RegistrationCode, listNV[2].RegistrationCode);
                    if (true)
                    {
                        Console.Write("\nEmployee {0} has the same registration number as employee {1}."
                            , listNV[0].Name, listNV[2].Name);
                    }
                    else Console.Write("\nEmployee {0} does not have the same registration number as employee {1}."
                        , listNV[0].Name, listNV[2].Name);
                    break;
                case 5:
                    Console.Write("\nCheck employee age:\n");
                    for (int i = 0; i < listNV.Length; i++)
                    {
                        try
                        {
                            listNV[i].checkAge();
                        }
                        catch (WorkingAge e)
                        {
                            Console.Write(e.Message);
                            employees.Remove(listNV[i]);
                        }
                    }
                    break;
                case 6:
                    Console.Write("\nProfile {0}:", listNV[0].Name);
                    Console.Write("\nAge of employee: {0}", (listNV[0] as IEmployee).Age());
                    Console.Write("\nWorking seniority: {0} year.", (listNV[0] as IEmployee).Anciennete());
                    Console.Write("\nYear off work: {0}", (listNV[0] as IEmployee).DateRetraite(40));
                    break;
                case 7:
                    Console.Write("\nIComparable<Employee> Compare 2 employee {0} and {1} by name:"
                        , listNV[0].Name, listNV[1].Name);
                    IComparable<Employee> a = (IComparable<Employee>)listNV[0];
                    if (a.CompareTo(listNV[0], listNV[1]) == 0)
                    {
                        Console.Write("\nTwo equal employees");
                    }  
                    else
                    {
                        Console.Write("\nTwo different employees");
                    }    
                    break;
                default: 
                    Console.Write("\nYou entered the wrong format. Please re-enter!!!");
                    break;
            }
        }
        while (option != 0);
    }
}