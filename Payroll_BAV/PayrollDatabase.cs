using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Payroll_BAV
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();
        private static Hashtable UnionMembers = new Hashtable();

        public static void AddEmployee(int id, Employee employee) { employees[id] = employee; }
        public static void AddUnionMember(int id, Employee e) { UnionMembers[id] = e; }
        public static void DeleteEmployee(int id) { employees.Remove(id); }
        public static void DeleteUnionMember(int id) { UnionMembers.Remove(id); }
        public static Employee GetEmployee(int id) { return employees[id] as Employee; }
        public static Employee GetUnionMember(int id) { return UnionMembers[id] as Employee; }
        public static ArrayList GetAllEmployeeIds()
        {
            ArrayList allEmplIds = new ArrayList();
            allEmplIds.AddRange(employees.Keys);
            return allEmplIds;
        }
    }
}
