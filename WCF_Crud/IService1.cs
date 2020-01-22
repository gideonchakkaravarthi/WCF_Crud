using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Crud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InsertEmpDetails(EmpDetails eDatils);
        [OperationContract]
        DataSet GetEmpDetails(EmpDetails eDatils);
        [OperationContract]
        DataSet FetchUpdatedRecords(EmpDetails eDatils);
        [OperationContract]
        string UpdateEmpDetails(EmpDetails eDatils);
        [OperationContract]
        bool DeleteEmpDetails(EmpDetails eDatils);
    }



    [DataContract]
    public class EmpDetails
    {
        int? eId;
        string eName = string.Empty;
        string eSalary = string.Empty;
        string eDeptId = string.Empty;
        string eDeptName = string.Empty;
        [DataMember]
        public int? Id
        {
            get
            {
                return eId;
            }
            set
            {
                eId = value;
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return eName;
            }
            set
            {
                eName = value;
            }
        }
        [DataMember]
        public string Salary
        {
            get
            {
                return eSalary;
            }
            set
            {
                eSalary = value;
            }
        }
        [DataMember]
        public string DeptId
        {
            get
            {
                return eDeptId;
            }
            set
            {
                eDeptId = value;
            }
        }
        [DataMember]
        public string DeptName
        {
            get
            {
                return eDeptName;
            }
            set
            {
                eDeptName = value;
            }
        }
    }
} 

