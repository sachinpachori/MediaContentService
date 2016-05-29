using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MediaContentService.DTO;

namespace MediaContentService.BL
{
    class MediaContentBL
    {
        public string ProcessMediaContent(string oRqst)
        {
            ResponseDTO oResp = new ResponseDTO();
            oResp.response = new List<ResponseDTO.Response>();
            RequestDTO oReq = JsonConvert.DeserializeObject<RequestDTO>(oRqst);
            if(oReq!= null && oReq.payload!=null)
            {                
                foreach (RequestDTO.Payload oPyld in oReq.payload)
                {                        
                    if (oPyld.drm == true && oPyld.episodeCount > 0)
                    {                           
                        ResponseDTO.Response oRes = new ResponseDTO.Response();
                        if (oPyld.image != null)
                            oRes.image = oPyld.image.showImage;
                        else
                            oRes.image = string.Empty;
                        oRes.slug = oPyld.slug;
                        oRes.title = oPyld.title;
                        oResp.response.Add(oRes);
                    }                        
                }
                if(oResp.response.Count > 0)
                {
                    oResp.status = "success";
                    oResp.error = null;                   
                }

            }
            return JsonConvert.SerializeObject(oResp);
        }



        public string GetErrorMsg()
        {
            ResponseDTO oRsp = new ResponseDTO();
            oRsp.response = null;
            oRsp.status = "400 Bad Request";
            oRsp.error = "Could not decode request: JSON parsing failed";
            return JsonConvert.SerializeObject(oRsp);
        }
    }
}
