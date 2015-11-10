using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_BAV;

namespace PayrollTest_BAV
{
    [TestClass]
    public class PayrollTest_BAV
    {
        [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob",e.Name);
            Assert.AreEqual("Home", e.Address);
            Assert.AreEqual(empId, e.EmpId);
        }

        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MontlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}
