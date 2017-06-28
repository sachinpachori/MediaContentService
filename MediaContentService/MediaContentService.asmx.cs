using System;
using System.Web.Services;
using MediaContentService.BL;
using System.Web.Script.Services;

namespace MediaContentService
{
    /// <summary>
    /// Summary description for MediaContentService
    /// </summary>
    [WebService(Namespace = "http://channel9.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Following line of code will allow this Web Service to be called from script, using ASP.NET AJAX. 
    [System.Web.Script.Services.ScriptService]
    public class MediaContentService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetContent(string oRqst)
        {
            string strResp = String.Empty;
            MediaContentBL oMedCnt = new MediaContentBL();
            try
            {
                if (!String.IsNullOrEmpty(oRqst))
                {                    
                    strResp = oMedCnt.ProcessMediaContent(oRqst);
                    return strResp;
                }                
            }
            catch(Exception ex)
            {
                //Log Error at service level
                Console.WriteLine(ex);
            }
            return oMedCnt.GetErrorMsg();
        }

        
    }
}
