using System;
namespace oop031222;
abstract class TableIR
{
    private static double[] tranches = { 0, 28000, 40000, 50000, 60000, 150000 };
    private static double[] tauxIR = { 0, 0.12, 0.24, 0.34, 0.38, 0.40 };
    public TableIR(double[] tranches, double[] tauxIR)
    {
        TableIR.tranches = tranches;
        TableIR.tauxIR = tauxIR;
    }
    public static double getIR(double salary)
    {
        if (salary >= tranches[0] && salary <= tranches[1]) return tauxIR[0];
        else if (salary >= tranches[1] && salary <= tranches[2]) return tauxIR[1];
        else if (salary >= tranches[2] && salary <= tranches[3]) return tauxIR[2];
        else if (salary >= tranches[3] && salary <= tranches[4]) return tauxIR[3];
        else if (salary >= tranches[4] && salary <= tranches[5]) return tauxIR[4];
        else return tauxIR[5];
    }
    public static void Display()
    {
        if (tranches.Length == tauxIR.Length)
        {
            for (int i = 0; i <= tranches.Length; i++)
            {
                if (i + 1 >= tranches.Length)
                {
                    Console.Write("\n>=\t{0}\t{1}%", tranches[i], tauxIR[i] * 100);
                    break;
                }
                else if (tranches[i] == 0)
                {
                    Console.Write("\n{0}\t{1}\t{2}%", tranches[i], tranches[i + 1], tauxIR[i] * 100);
                }    
                else Console.Write("\n{0}\t{1}\t{2}%", tranches[i] + 1, tranches[i + 1], tauxIR[i] * 100);
            }
        }
    }
}
interface IEmployee
{
    int Age();
    int Anciennete();
    int DateRetraite(int ageRetraite);
}
class WorkingAge : Exception
{
    public WorkingAge(string error) : base(error) { }
}
abstract class SalaryEmployee
{
    public abstract double salaryApayer();
}
interface IComparable<Employee>
{
    int CompareTo(Employee x, Employee y);
}
class Employee : SalaryEmployee, IEmployee, IComparable<Employee>
{
    private string registrationCode;
    private string name;
    private DateTime birthDay;
    private DateTime recruitmentDay;
    private double salaryBase;
    public Employee(string name, DateTime birthDay, DateTime recruitmentDay, double salaryBase)
    {
        this.name = name;
        this.birthDay = birthDay;
        this.recruitmentDay = recruitmentDay;
        this.salaryBase = salaryBase;
    }
    public string RegistrationCode { get { return registrationCode; } set { registrationCode = value; } }
    public string Name { get { return name; } set { name = value; } }
    public DateTime Birthday { get { return birthDay; } set { birthDay = value; } }
    public DateTime RecruitmentDay { get { return recruitmentDay; } set { recruitmentDay = value; } }
    public double SalaryBase { get { return salaryBase; } set { salaryBase = value; } }
    public override double salaryApayer()
    {
        return salaryBase;
    }
    int IEmployee.Age()
    {
        return DateTime.Now.Year - birthDay.Year;
    }
    int IEmployee.Anciennete()
    {
        return DateTime.Now.Year - recruitmentDay.Year;
    }
    int IEmployee.DateRetraite(int ageRetraite)
    {
        // default year quits work = 40
        return birthDay.Year + ageRetraite;
    }
    int IComparable<Employee>.CompareTo(Employee x, Employee y)
    {
        if (x.name == y.name) return 0;
        else return 1;
    }
    public string auto_incrementID(string fixedID)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        fixedID = "NV"; // defaultID
        HashSet<int> hashset = new HashSet<int>();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            hashset.Add(Convert.ToInt32(table.Rows[i][0].ToString().Remove(0, fixedID.Length)));
        }
        for (int i = 0; i < hashset.Count; i++)
        {
            if (!hashset.Contains(i + 1)) return i + 1 < 10 ? fixedID + "00" + ++i : i + 1 < 100 ?
            fixedID + "0" + ++i : fixedID + ++i;
        }
        return hashset.Count + 1 < 10 ? fixedID + "00" + (hashset.Count + 1) : hashset.Count + 1 < 100 ?
        fixedID + "0" + (hashset.Count + 1) : fixedID + (hashset.Count + 1);
    }
    public override string ToString()
    {
        return "\n" + auto_incrementID(registrationCode) + " - " + name + " - " + birthDay.Day + "/" + birthDay.Month + "/"
        + birthDay.Year + " - " + recruitmentDay.Day + "/" + recruitmentDay.Month + "/" + recruitmentDay.Year + " - " + salaryBase;
    }
    static public new bool Equals(string x, string y)
    {
        if (x == y)
        {
            return true;
        }
        else return false;
    }
    public void checkAge()
    {
        if (recruitmentDay.Year - birthDay.Year <= 16)
        {
            Console.Write("\nEmployee {0}", name);
            throw (new WorkingAge(" is underage (remove)."));
        }
        else Console.Write("\nEmployees {0} of working age.", name);
    }
}
class Formateur : Employee
{
    private int hereSup;
    private double remunerationHSup;
    public Formateur(string name,DateTime birthDay, DateTime recruitmentDay, double salaryBase, int hereSup) 
        : base (name, birthDay, recruitmentDay, salaryBase)
    {
        this.hereSup = hereSup;
    }
    public int HereSup { get { return hereSup; } set { hereSup = value; } }
    public double RecruitmentHSup { get { return remunerationHSup; } set { remunerationHSup = value; } }
    public double getRemuneration()
    {
        remunerationHSup = 70000;
        return remunerationHSup;
    }
    public override double salaryApayer()
    {
        return (SalaryBase + getRemuneration() * hereSup) * (1 - TableIR.getIR(SalaryBase));
    }
    public override string ToString()
    {
        base.ToString();
        return "\n" + auto_incrementID(RegistrationCode) + " - " + Name + " - " + Birthday.Day + "/" + Birthday.Month + "/" 
            + Birthday.Year + " - " + RecruitmentDay.Day + "/" + RecruitmentDay.Month + "/" + RecruitmentDay.Year + " - " 
            + SalaryBase + " - " + hereSup + "h - " + getRemuneration() + " - " + salaryApayer();
    }
}