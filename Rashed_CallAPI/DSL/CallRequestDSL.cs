using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Enum;
using DAL;
using Enums;

namespace DSL
{
    public class CallRequestDSL
    {
        public RashedEntities rashedEntities;
        public CallRequestDSL()
        {
            rashedEntities = new RashedEntities();
        }

        public CallAckDTO SendCallRequest(CallRequestDTO callRequestDTO)
        {
            try
            {
                if (callRequestDTO.UserId == null || callRequestDTO.CalleeId == null)
                {
                    throw new InvalidOperationException();
                }
                Request request = new Request()
                {
                    CalleeId = callRequestDTO.CalleeId,
                    UserId = callRequestDTO.UserId,
                    Image = callRequestDTO.Image,
                    Latitude = callRequestDTO.Latitude,
                    Longitude =callRequestDTO.Longitude,
                    Message = callRequestDTO.Message,
                    RequestTime = DateTime.Now,
                    ID = 0
                };
                rashedEntities.Requests.Add(request);
                rashedEntities.SaveChanges();
                return new CallAckDTO()
                {
                    Data = new CallAckDataDTO()
                    {
                        CalleeId = callRequestDTO.CalleeId,
                        UserId = callRequestDTO.UserId,
                        OperationNo = request.ID
                    },
                    Status = new StatusDTO()
                    {
                        Message = "Message Sent Successfully",
                        Type = MessageTypeEnum.Success.GetHashCode()
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CallRequestDetailsDTO> GetAllRequestCalls()
        {
            try
            {
                var requests = rashedEntities.Requests.ToList();
                var users = rashedEntities.UserDatas.ToList();

                List<CallRequestDetailsDTO> response = new List<CallRequestDetailsDTO>();
                foreach (var item in requests)
                {
                    var user = users.FirstOrDefault(u => u.ID == item.UserId);
                    response.Add(new CallRequestDetailsDTO()
                    {
                        CalleeName = ((CalleesEnum) item.CalleeId).ToString(),
                        CallerName = user != null ? user.FName + " " + user.LName  : null,
                        Image = item.Image,
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        Message = item.Message,
                        RequestTime = item.RequestTime.HasValue ? (DateTime) item.RequestTime : DateTime.Now
                    });

                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
