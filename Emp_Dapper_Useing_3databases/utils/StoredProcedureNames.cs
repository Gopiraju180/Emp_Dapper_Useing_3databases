namespace Emp_Dapper_Useing_3databases.utils
{
    public static class StoredProcedureNames
    {
        #region Department storedProcedures
        public static readonly string AddDepartment = "Usp_AddDepartment";
        public static readonly string UpdateDepartment = "Usp_UpdateDepartment";
        public static readonly string DeleteDepartment = "Usp_DeleteDepartment";
        public static readonly string GetDepartment = "Usp_GetDepartment";
        public static readonly string GetDepartmentByDeptId = "Usp_GetDepartmentById";
        #endregion

        #region Employee StoredProcedure
        public static readonly string AddEmployee = "Usp_AddEmployeeReturn";
        public static readonly string UpdateEmployee = "Usp_UpdateEmployee";
        public static readonly string DeleteEmployee = "Usp_DeleteEmployee";
        public static readonly string GetEmployee = "Usp_GetEmployee";
        public static readonly string GetEmployeeByEmpid = "Usp_GetEmployeeId";
        #endregion

        #region OrderStoredProcedures
        public static readonly string AddOrder = "Usp_AddOrder";
        public static readonly string UpdateOrder = "Usp_UpdateOrder";
        public static readonly string DeleteOrder = "Usp_DeleteOrder";
        public static readonly string GetOrder = "Usp_GetOrder";
        public static readonly string GetOrderById = "Usp_GetOrderById";
        #endregion
    }
}
