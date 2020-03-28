using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class StateData : IStateData
    {

        private const string FetchStates = "SPC_FetchAllStates";
        private const string FetchState = "SPC_FetchState";
        private const string AddState = "SPC_AddState";
        public StateData()
        {

        }
        public string Add(StateRequest state)
        {
            try
            {
                string stProc = AddState;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@State_gov_code", state.State_Gov_Code ?? state.State_Gov_Code),
                    new SqlParameter("@Statename", state.StateName ?? state.StateName),
                    new SqlParameter("@Shortname", state.Shortname ?? state.Shortname),
                    new SqlParameter("@Isactive", state.IsActive ?? state.IsActive),
                    new SqlParameter("@Latitude", state.Latitude ?? state.Latitude),
                    new SqlParameter("@Longitude", state.Longitude ?? state.Longitude),
                    new SqlParameter("@Comments", state.Comments ?? state.Comments),
                    new SqlParameter("@Createdby", state.CreatedBy),
                    new SqlParameter("@Updatedby", state.UpdatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "State added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<State> Retreive(int code)
        {
            string stProc = FetchState;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<State>(stProc, pList);
            return allData;
        }
        public List<State> Retreive()
        {
            string stProc = FetchStates;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<State>(stProc, pList);
            return allData;
        }
    }
}
