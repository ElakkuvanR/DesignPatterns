using CommonDAL;
using InterfaceCustomer;
using InterfaceDal;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FactoryCustomer;
using System;

namespace AdoDotnetDal
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        public TemplateADO(string _ConnectionString)
            : base(_ConnectionString)
        {

        }
        private void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }
        protected abstract void ExecuteCommand(AnyType obj);
        protected abstract List<AnyType> ExecuteCommand();

        private void Close()
        {
            objConn.Close();
        }

        // Design Pattern :- Template Pattern
        public void Execute(AnyType obj) // Fixed Sequences
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }

        public List<AnyType> Execute()
        {
            List<AnyType> objTypes = null;
            Open();
            objTypes = ExecuteCommand();
            Close();
            return objTypes;
        }
        public override void Save()
        {
            foreach (AnyType o in AnyTypes)
            {
                Execute(o);
            }
        }

        public override List<AnyType> Search()
        {
            return Execute();
        }
    }

    public class CustomerDAL : TemplateADO<ICustomer>, IDal<ICustomer>
    {
        public CustomerDAL(string _ConnectionString)
            : base(_ConnectionString)
        {

        }

        protected override List<ICustomer> ExecuteCommand()
        {
            objCommand.CommandText = "Select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            List<ICustomer> customerList = new List<ICustomer>();
            while (dr.Read())
            {
                ICustomer cust = Factory<ICustomer>.Create("Customer");
                cust.CustomerName = dr["CustomerName"].ToString();
                cust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                cust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                cust.PhoneNumber = dr["PhoneNumber"].ToString();
                cust.Address = dr["Address"].ToString();
                customerList.Add(cust);
            }
            return customerList;
        }

        protected override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "insert into tblCustomer(" +
                                     "CustomerName," +
                                     "BillAmount," +
                                     "BillDate," +
                                     "PhoneNumber," +
                                     "Address)" +
                                     " values('" + obj.CustomerName + "'," +
                                     obj.BillAmount + ",'" +
                                     obj.BillDate + "','" +
                                     obj.PhoneNumber + "','" +
                                     obj.Address + "')";
            objCommand.ExecuteNonQuery();
        }
    }
}
