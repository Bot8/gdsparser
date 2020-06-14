using System;

namespace InfrastuctureLayer.Gds.Sirena
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
                case RequestName.Trips:
                   response = @"<Trips>
                        <Trip>
                            <Supplier>SU</Supplier>
                            <Fligth>10</Fligth>
                        </Trip>
                        <Trip>
                            <Supplier>S7</Supplier>
                            <Fligth>11</Fligth>
                        </Trip>
                        <Trip>
                            <Supplier>N4</Supplier>
                            <Fligth>15</Fligth>
                        </Trip>
                        <Trip>
                            <Supplier>XX</Supplier>
                            <Fligth>20</Fligth>
                            <variants>
                                <variant>
                                    <segment operating_supplier='SU' marketing_supplier='S7'></segment>
                                    <segment operating_supplier='SU' marketing_supplier='S7'></segment>
                                </variant>
                                <variant>
                                    <segment operating_supplier='AA' marketing_supplier='BB'></segment>
                                    <segment operating_supplier='AA' marketing_supplier='BB'></segment>
                                </variant>
                            </variants>
                        </Trip>
                    </Trips>";
                    break;
                case RequestName.FareRules:
                    response = @"<fareremark>
                        <remark new_fare='true'>some text 1</remark>
                        <remark new_fare='true'>some text 2</remark>
                        <remark new_fare='true'>some text 3</remark>
                        <remark new_fare='true'>some text 4</remark>
                    </fareremark>";
                    break;
                default:
                    throw new Exception($"Unknown request name {requestName}");
            }
            
            _logger.Info($"Response {response}");
            
            return response;
        }
    }
}