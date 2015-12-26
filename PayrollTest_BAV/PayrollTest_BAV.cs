﻿using System;
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
            int empId = 0;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob", e.Name);
            Assert.AreEqual("Home", e.Address);
            Assert.AreEqual(empId, e.EmpId);
        }

        [TestMethod]
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

        [TestMethod]
        public void TestAddHourlyEmployee()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 132.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(132, sc.Rate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is HourlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void TestAddCommissionedEmployee()
        {
            int empId = 3;
            AddComissionedEmployee t = new AddComissionedEmployee(empId, "Bob", "Home", 100.00, 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            Assert.AreEqual(100.00, sc.CRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void TestDeleteEmployee()
        {
            int empid = 4;
            AddSalariedEmployee t = new AddSalariedEmployee(empid, "Bill", "home", 2000);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empid);
            dt.Execute();
            e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNull(e);
        }

        [TestMethod]
        public void TestTimeCardTransaction()
        {
            int empId = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "home", 2000);
            t.Execute();
            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2015, 10, 31), 8.0, empId);
            tct.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            TimeCard tc = hc.GetTimeCard(new DateTime(2015,10,31)); 
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }

        [TestMethod]
        public void TestChangeNameTransaction()
        {
            int empId = 6;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "home", 2000);
            t.Execute();
            ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        [TestMethod]
        public void TestChangeAddressTransaction()
        {
            int empId = 7;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "home", 2000);
            t.Execute();
            ChangeAddressTransaction cat = new ChangeAddressTransaction(empId, "Office"); 
            cat.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Office", e.Address);
        }

        [TestMethod]
        public void TestChangeHourlyTransaction()
        {
            int empId = 8;
            AddComissionedEmployee t = new AddComissionedEmployee(empId, "Bill", "home", 100, 400);
            t.Execute();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empId, 200);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(200, hc.Rate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is HourlySchedule);
        }

        [TestMethod]
        public void TestCommissionedClassification()
        {
            int empId = 9;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "home", 1000);
            t.Execute();
            ChangeCommissionedTransaction cct = new ChangeCommissionedTransaction(empId, 200, 100);
            cct.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;
            Assert.AreEqual(10, cc.CRate);
            Assert.AreEqual(20.44, cc.Salary);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }

        [TestMethod]
        public void TestDirectDepositMethod()
        {
            int empId = 10;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "home", 1000);
            t.Execute();
            ChangeDirectTransaction cdt = new ChangeDirectTransaction(empId, "Bank A", "123456789");
            cdt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is DirectDepositMethod);
            DirectDepositMethod ddm = pm as DirectDepositMethod;
            Assert.AreEqual("Bank A", ddm.Bank);
            Assert.AreEqual("123456789", ddm.Account);
        }

        [TestMethod]
        public void ChangeMailMethod()
        {
            int empid = 11;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "home", 25);
            t.Execute();
            ChangeMailTransaction cmt = new ChangeMailTransaction(empid, "zbcdefg@hig.klm");
            cmt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is MailMethod);
            MailMethod mm = pm as MailMethod;
            Assert.AreEqual("zbcdefg@hig.klm", mm.MailAddress);
        }

        [TestMethod]
        public void ChangeHoldMethod()
        {
            int empid = 12;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "home", 25);
            t.Execute();
            ChangeHoldTransaction cht = new ChangeHoldTransaction(empid);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void ChangeUnionMember()
        {
            int empid = 13;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Masha", "Forest", 256.1);
            t.Execute();
            int memberId = 7743;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empid, memberId, 99.42);
            cmt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            Affilation affiliation = e.Affilation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffilation);
            UnionAffilation uf = affiliation as UnionAffilation;
            Assert.AreEqual(99.42, uf.Charge, .001);
            Employee member = PayrollDatabase.GetUnionMember(memberId);
            Assert.IsNotNull(member);
            Assert.AreEqual(e, member);
        }
    }
}
