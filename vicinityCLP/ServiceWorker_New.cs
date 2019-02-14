using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClpConnection;

namespace VicinityCLP
{
    public class ServiceWorker_New
    {
        #region CLP variables
        CLP_Connection clp_connection;
        CLP_Parameters clp_parameters;
        CLP_Objects clp_objects;

        string clp_user = "vicinity@test.com";
        string clp_pass = "Vicinity2020!";

        LoginData clp_login_token;

        DateTime clp_login_token_expire;
        #endregion

        public Action<string> log;
        public Action<Exception> exception;

        public ServiceWorker_New()
        {
            clp_connection = new CLP_Connection();
            clp_parameters = new CLP_Parameters();
            clp_objects = new CLP_Objects();

            clp_login_token = null;
            clp_login_token_expire = DateTime.Now;

            log = null;
            exception = null;
        }

        public List<string> GetObjectsAUIDs()
        {
            //returns list of AUIDs
            return clp_objects.JSON_GetAUIDs(clp_connection.GetCLPObjects(clp_user, CLPtokenToString()));
        }

        public void RF_SetSuperCool(string auid, string value)
        {
            clp_connection.RF_SetSuperCool(clp_user, CLPtokenToString(), auid, value);
        }

        public void RF_SetFastFreeze(string auid, string value)
        {
            clp_connection.RF_SetFastFreeze(clp_user, CLPtokenToString(), auid, value);
        }

        public void RF_SetChildLock(string auid, string value)
        {
            clp_connection.RF_SetChildLock(clp_user, CLPtokenToString(), auid, value);
        }

        public void RF_SetFreezerTemp(string auid, int temp)
        {
            clp_connection.RF_SetFreezerTemp(clp_user, CLPtokenToString(), auid, temp);
        }

        public void RF_SetFridgeTemp(string auid, int temp)
        {
            clp_connection.RF_SetFridgeTemp(clp_user, CLPtokenToString(), auid, temp);
        }

        public void OV_SetLight(string auid, string value)
        {
            clp_connection.OV_SetOvenLight(clp_user, CLPtokenToString(), auid, value);
        }

        public void OV_SetChildLock(string auid, string value)
        {
            clp_connection.OV_SetChildLock(clp_user, CLPtokenToString(), auid, value);
        }

        public void OV_SetBake(string auid, int duration, string heater, int temp)
        {
            clp_connection.OV_SetProgressType(clp_user, CLPtokenToString(), auid, "NONE");
            clp_connection.OV_SetBakeSettings(clp_user, CLPtokenToString(), auid, "OVEN_SET", duration, heater, temp);
            clp_connection.OV_SetProgressType(clp_user, CLPtokenToString(), auid, "OVEN_SET");
        }

        public void OV_SetBakePreheat(string auid, int duration, string heater, int temp)
        {
            clp_connection.OV_SetProgressType(clp_user, CLPtokenToString(), auid, "NONE");
            clp_connection.OV_SetBakeSettings(clp_user, CLPtokenToString(), auid, "OVEN_SET", duration, heater, temp);
            clp_connection.OV_SetPreheat(clp_user, CLPtokenToString(), auid);
            clp_connection.OV_SetProgressType(clp_user, CLPtokenToString(), auid, "OVEN_SET");
        }

        public void OV_SetBakeDelayStart(string auid, int duration, string heater, int temp, int hour, int min)
        {
            clp_connection.OV_SetProgressType(clp_user, CLPtokenToString(), auid, "NONE");
            clp_connection.OV_SetBakeSettings(clp_user, CLPtokenToString(), auid, "OVEN_SET", duration, heater, temp);
            clp_connection.OV_SetBakeStartTime(clp_user, CLPtokenToString(), auid, min, hour);
            clp_connection.OV_SetProgressType(clp_user, CLPtokenToString(), auid, "OVEN_SET");
        }

        public void OV_SetStart(string auid)
        {
            clp_connection.OV_ActionStart(clp_user, CLPtokenToString(), auid);
        }

        public void OV_SetStop(string auid)
        {
            clp_connection.OV_ActionStop(clp_user, CLPtokenToString(), auid);
        }

        public IDictionary<string, string> GetStatus(string auid)
        {
            string json_response = clp_connection.GetCLPObject(clp_user, CLPtokenToString(), auid);

            clp_parameters.Parse(json_response);

            return clp_parameters.GetParams(auid);
        }

        private string CLPtokenToString()
        {
            if (clp_login_token == null || clp_login_token_expire < DateTime.Now)
            {
                clp_login_token = clp_connection.getValidCLPToken(clp_user, clp_pass);
                if (clp_login_token.token != null)
                {
                    DateTime utc_time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    utc_time = utc_time.AddMilliseconds(clp_login_token.expirationDate);

                    clp_login_token_expire = utc_time.ToLocalTime();
                }
                else
                {
                    return null;
                }
            }

            return clp_login_token.token;
        }

    
    }
}
