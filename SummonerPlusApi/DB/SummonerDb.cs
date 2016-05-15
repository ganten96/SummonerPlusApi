using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SummonerPlusApi.Models;
using System.Data.SqlClient;

namespace SummonerPlusApi.DB
{
    public class SummonerDb
    {
        private DynamicDb db;
        public SummonerDb()
        {
            db = new DynamicDb();
        }

        public bool LogIn(LeagueUser user)
        {
            try
            {
                return db.RunProcedure<bool>("splus.usp_CheckUserCredentials").FirstOrDefault();
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public long CreateAccount(LeagueUser u)
        {
            try
            {
                return db.RunProcedure<long>("splus.usp_InsertSummoner", new
                {
                    SummonerID = u.SummonerID,
                    Username = u.SummonerName,
                    Password = u.Password
                }).FirstOrDefault();
            }
            catch(SqlException ex)
            {
                throw;
            }
        }
    }
}