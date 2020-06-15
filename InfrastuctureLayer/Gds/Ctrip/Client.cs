using System;

namespace InfrastuctureLayer.Gds.Ctrip
{
    public class Client
    {
        private readonly Logger _logger;

        public Client(Logger logger)
        {
            _logger = logger;
        }

        public string Request(RequestName requestName)
        {
            _logger.Info($"Request {requestName}");

            string response;

            switch (requestName)
            {
                case RequestName.Flights:
                    response = @"{
                        ""flights"":[
                            {
                                ""segments"":[
                                    {
                                        ""operating_supplier"":""SU"",
                                        ""marketing_supplier"":""SU""
                                    }
                                ]
                            }
                        ]
                    }";
                    break;
                case RequestName.FareConditions:
                    response = @"{
                        ""fare_conditions"": [
                            ""text_1"",
                            ""text_2""
                        ]
                    }";
                    break;
                default:
                    throw new Exception($"Unknown request name {requestName}");
            }

            _logger.Info($"Response {response}");

            return response;
        }
    }
}