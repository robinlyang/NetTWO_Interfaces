using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; //taps into Windows Operating System

namespace NetTWO_Interfaces
{
    interface payroll
    {
        void print_t4();
        double taxit(double x);
    }
    class emp : payroll, IDisposable, ICloneable, IComparable
    {
        public string name;
        public double salary;
        public object Clone() //easy way to copy a class
        {
            return this.MemberwiseClone();//this will copy ALL of the variables in the class
        }

        public int CompareTo(object obj)
        {
            //return -1 if first class is less than the second class
            //return 0 of class data is same
            //return 1 if second class is biggar than first class
            emp temp = (emp)obj;    //turn the second class into My data type
            if(this.name == temp.name && this.salary == temp.salary)
            {
                return 0;
            }
            if (this.name.CompareTo(temp.name) < 0 && this.salary < temp.salary)
            {
                return -1;
            }
            else
                return 1;
        }

        public void Dispose()
        {

        }

        public void print_t4()
        {
            Console.WriteLine("Put in some code");
        }

        public double taxit(double x)
        {
            return 0; //put in some code
        }
    }
    class Program
    {
        //dll import start
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetComputerName(StringBuilder s, ref uint size);
        //dll import end

        static void Main(string[] args)
        {
            StringBuilder name = new StringBuilder(128);
            UInt32 len = 128;
            int result = GetComputerName(name, ref len);
            Console.WriteLine(name);

            emp e = new emp();
            e.name = "bob";
            emp e2 = new emp();
            e2 = (emp)e.Clone();
            e.print_t4();
            //disposing of class memory
            //1. Make it null
            e = null; //does not remove the memory immediately
            //2.  Put in brackets
            {
                emp f = new emp(); //does not remove the memory immediately
            }
            //3. Do 1 or 2 and then issue Collect command
            System.GC.Collect();   //memory is gone
            //4. Use IDisposable interface to remove memory
            using (emp g = new emp())
            {
                //do coding here
            }//memory is removed here
            
            //call a DLL from .NET
            string person = Microsoft.VisualBasic.Interaction.InputBox("Enter your name");
            Console.WriteLine(person);
            //call a COM program
            Microsoft.Office.Interop.PowerPoint.ApplicationClass p = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
            //p.Help();


            Console.ReadLine();
        }
    }
}
